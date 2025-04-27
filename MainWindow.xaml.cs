using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Log_On_and_Off_time
{
    public partial class MainWindow : Window
    {
        private int i ;
        public static Sub_Window_01 frm = new Sub_Window_01();
        public static Sub_Window_02 frm2 = new Sub_Window_02();
        public static MediaPlayer music = new MediaPlayer();
        Thread th1;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void C1(object sender, RoutedEventArgs e)
        {
            i = 1;
        }

        private void C2(object sender, RoutedEventArgs e)
        {
            i = 2;
        }
        private void C3(object sender, RoutedEventArgs e)
        {
            i = 3;
        }
        private void C4(object sender, RoutedEventArgs e)
        {
            i = 4;
        }
        private void CE(object sender, RoutedEventArgs e)
        {
            i = 5;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            switch(i)
            {
                case 1:
                    Program.LogTime_All();
                    break;
                case 2:
                    Program.LogTime_All_Re();
                    break;
                case 3:
                    Program.LogTime_Partial();
                    break;
                case 4:
                    frm2.Show();
                    music.Open(new Uri("丁真新曲[大 大 大].mp3", UriKind.RelativeOrAbsolute));
                    music.Play();
                    frm2.InitializeMusic(music);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
        void Pro1()
        {           
            int count = 0;
            while(true)
            {
                lock (this)
                {
                    frm2.Progress_Bar1.Value = count;
                    count += 10;
                    if (count == 100)
                        break;
                }
            }
        }
    }
}
