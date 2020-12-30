using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace PcCleaner11
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*private object timeSpan;*/
        long sizeRet;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Path

      
        DirectoryInfo winTemp = new DirectoryInfo(System.IO.Path.GetTempPath());


        //*****************************************METHODS*******************************************************

        // ANALYSIS METHOD

        public void GetFile()
        {
            DirectoryInfo winTemp = new DirectoryInfo(System.IO.Path.GetTempPath());
            long size = 0;
            

        

            foreach (FileInfo fi in winTemp.GetFiles("*", SearchOption.AllDirectories))
            {
                size += fi.Length;

            }
              sizeRet = (size/1024)/1024;
             label_content.Content= $"Cleaned space is : {sizeRet} MB";

            

        }


        //Delete Method
        public void DeleteFile()
        {
           


            foreach (FileInfo file in winTemp.GetFiles("*", SearchOption.AllDirectories))
            {

                file.Delete();
            }

        }


        // Reader Method

        public void ReadFromFile()
        {
            using (StreamReader sr = File.OpenText("History.txt"))
            {
                sr.ReadLine();
                string data = null;

                while ((data= sr.ReadLine()) != null)
                {
                    MessageBox.Show(data);
                }
              

               /* sr.WriteLine("Date of analyse: " + DateTime.Now.ToString());
                sr.WriteLine("==================");*/

            }
        }


          //******************************************Button***************************************************************************


        // ANALYSE BUTTON
        private void Button_Click(object sender, RoutedEventArgs e)
        {
               

            MessageBox.Show("Analyse begins now");

           
            prog_grid.Visibility = Visibility.Visible;
            btn_analyse1.IsEnabled = false;
            btn_Nettoyer.IsEnabled = false;
            btn_Historique.IsEnabled = false;
            btn_MTJ.IsEnabled = false;
            btn_Option.IsEnabled = false;


            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                   /* Duration duration = new Duration(TimeSpan.FromMilliseconds(1));
                    DoubleAnimation doubleAnimation = new DoubleAnimation(progress.Value = i, duration);
                    progress.BeginAnimation(ProgressBar.ValueProperty, doubleAnimation); */

                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() =>  
                    {
                        

                        progress.Value = i;
                        prog_percentage.Text = i.ToString() + "%";

                        if (progress.Value == 100)
                        {
                            MessageBox.Show("Analyse ended");
                            prog_grid.Visibility = Visibility.Hidden;
                            btn_analyse1.IsEnabled = true;
                            btn_Nettoyer.IsEnabled = true;
                            btn_Historique.IsEnabled = true;
                            btn_MTJ.IsEnabled = true;
                            btn_Option.IsEnabled = true;
                            GetFile();
                            using (StreamWriter sw = File.AppendText("History.txt"))
                            {
                                sw.WriteLine($"Size of analyse is {sizeRet} MB");
                                sw.WriteLine("Date of analyse: " + DateTime.Now.ToString());
                                sw.WriteLine("==================");

                            }

                        }

                        

                    });
                }
            });
           
        }


        // CLEAN BUTTON
        private void btn_Nettoyer_Click(object sender, RoutedEventArgs e)
        {
           if(sizeRet != 0) 
           {
                var Messageanswer = MessageBox.Show("do you want to delete files ?", "Warning",
                     MessageBoxButton.YesNo, MessageBoxImage.Information);
               
                    btn_analyse1.IsEnabled = false;
                    btn_Nettoyer.IsEnabled = false;
                    btn_Historique.IsEnabled = false;
                    btn_MTJ.IsEnabled = false;
                    btn_Option.IsEnabled = false;

                   
                    if (Messageanswer == MessageBoxResult.Yes)
                    {
                        DeleteFile();
                        MessageBox.Show("Your computer is clean now");
                    }
                    else
                    {
                        prog_grid.Visibility = Visibility.Hidden;
                        btn_analyse1.IsEnabled = true;
                        btn_Nettoyer.IsEnabled = true;
                        btn_Historique.IsEnabled = true;
                        btn_MTJ.IsEnabled = true;
                        btn_Option.IsEnabled = true;
                    }
                    
           }


            else
            {
                MessageBox.Show("you need to analyse you computer first ?");
            }

           

        }


        // Button History
       

        private void btn_Historique_Click(object sender, RoutedEventArgs e)
        {
           
            ReadFromFile();


        }

        private void btn_MTJ_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();

            /*progress_update.Visibility = Visibility.Visible;*/


            if (!client.DownloadString("https://pastebin.com/raw/37G1ihDt").Contains("1.0.1"))
            {
                var answer = MessageBox.Show("there is an availabale update, would you like to downoald it","compuetr scan",MessageBoxButton.YesNo, MessageBoxImage.Information) ;
                   
                if (answer == MessageBoxResult.Yes)
                {
                   
                   this.Hide();
                    Update update = new Update();
                    update.ShowDialog();
                }
                else
                {
                        prog_grid.Visibility = Visibility.Hidden;
                        btn_analyse1.IsEnabled = true;
                        btn_Nettoyer.IsEnabled = true;
                        btn_MTJ.IsEnabled = true;
                        btn_Historique.IsEnabled = true;
                        btn_Option.IsEnabled = true;
                 }
               


            }
            else
            {
                MessageBox.Show("evrything is updated");
            }


        }


    }
}
