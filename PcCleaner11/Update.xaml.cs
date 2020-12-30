using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO.Compression;
using System.Threading;

namespace PcCleaner11
{
    /// <summary>
    /// Logique d'interaction pour Update.xaml
    /// </summary>
    public partial class Update : Window
    {


        string comprPath = @"C:\Users\youcode\Desktop\PcCleaner11\PcCleaner11\bin\Release";

        string comprLocal = @"C:\Users\youcode\Desktop\PcCleaner11\PcCleaner11\bin\old_version.zip";

        string extractPath = @"C:\Users\youcode\Desktop\PcCleaner11\PcCleaner11\bin\Release";


        public Update()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();

            string url = "https://updatecleaner.weebly.com/uploads/1/3/5/3/135386260/upd-cleaner.zip";
            string path = @"C:\Users\youcode\Desktop\update\Release.zip";

            /*string zipPath = path;
            string extractPath = @"C:\Users\youcode\Desktop\PcCleaner11\PcCleaner11\bin\Release";*/


            /* client.DownloadFile((url), (path));

             string zipPath = @".\Release.zip";
             string extractPath = @".\";
             ZipFile.ExtractToDirectory(zipPath, extractPath);

             client.Dispose();
             Process.Start(@".\Release.zip");
             MessageBox.Show("Doawnolad ended");*/
           
            Task.Run(() =>
            {
                try
                {
                    /*ZipFile.ExtractToDirectory(zipPath, extractPath);*/

                  

                    for (int i = 0; i <= 100; i++)
                    {

                        Thread.Sleep(10);
                        this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                        {
                            
                            progress1.Value = i;
                            progress1_pre.Text = i.ToString() + "%";

                           /* client.DownloadFile(url,path);
                            string zipPath = path;
                            string extractPath = @"C:\Users\youcode\Desktop\PcCleaner11\PcCleaner11\bin\Release";*/

                            if (progress1.Value==100)
                            {
                                ZipFile.CreateFromDirectory(comprPath, comprLocal);
                            }
                 

                           


                        });

                    }

                    client.DownloadFile(url, path);

                   
                    string zipPath = path;
                   
                    Process.Start(path);
                    ZipFile.ExtractToDirectory(zipPath, extractPath);
                    MessageBox.Show("Download finished");
                    prog1_grid.Visibility = Visibility.Hidden;

                }
                catch (Exception)
                {
                   
                    Environment.Exit(0);
                }
                client.Dispose();


            });
        }

       /* private void Button_Click1(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();

            string url = "https://github.com/douja-amr/pc-cleaner.git";
            string path = @"C:\Users\youcode\Desktop\update\Release.zip";
            *//*string zipPath = path;
            string extractPath = @"C:\Users\youcode\Desktop\PcCleaner11\PcCleaner11\bin\Release";*/


            /* client.DownloadFile((url), (path));

             string zipPath = @".\Release.zip";
             string extractPath = @".\";
             ZipFile.ExtractToDirectory(zipPath, extractPath);

             client.Dispose();
             Process.Start(@".\Release.zip");
             MessageBox.Show("Doawnolad ended");*//*
            Thread.Sleep(30);
            Task.Run(() =>
            {
                try
                {
                    *//*ZipFile.ExtractToDirectory(zipPath, extractPath);*//*

                    for (int i = 0; i <= 100; i++)
                    {

                        Thread.Sleep(10);
                        this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                        {

                            progress1.Value = i;
                            progress1_pre.Text = i.ToString() + "%";

                            client.DownloadFile(url, path);
                            string zipPath = path;
                            string extractPath = @"C:\Users\youcode\Desktop\PcCleaner11\PcCleaner11\bin\Release";
                            





                            Process.Start(@" C:\Users\youcode\Desktop\PcCleaner11\PcCleaner11\bin\Release\upd\PcCleaner11.exe");

                            if (progress1.Value == 100)
                            {
                                MessageBox.Show("Download finished");
                                ZipFile.ExtractToDirectory(zipPath, extractPath);

                            }


                        });

                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to download");
                    Environment.Exit(0);
                }
                client.Dispose();


            });
        }*/
    }
}
