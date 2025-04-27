using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Log_On_and_Off_time
{
    public partial class Sub_Window_02 : Window
    {
        private bool index = true;
        private DispatcherTimer timer = new DispatcherTimer();
        private MediaPlayer musicPlayer;
        private bool isDragging = false;
        public Sub_Window_02()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(100); // 设置计时器的间隔为100毫秒
            timer.Tick += Timer_Tick;
        }
        public void InitializeMusic(MediaPlayer player)
        {
            musicPlayer = player;
            musicPlayer.MediaOpened += MusicPlayer_MediaOpened;
            musicPlayer.MediaEnded += MusicPlayer_MediaEnded;
        }
        private void MusicPlayer_MediaOpened(object sender, EventArgs e)
        {
            Progress_Bar1.Maximum = musicPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            timer.Start();
        }
        private void MusicPlayer_MediaEnded(object sender, EventArgs e)
        {
            timer.Stop();
            Progress_Bar1.Value = 0;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (musicPlayer != null)
            {
                Progress_Bar1.Value = musicPlayer.Position.TotalSeconds;
                timeText.Text = $"{musicPlayer.Position:mm\\:ss} / {musicPlayer.NaturalDuration.TimeSpan:mm\\:ss}";
            }
        }
        private void Button_Stop(object sender, RoutedEventArgs e)
        {
            MainWindow.music.Stop();
            MainWindow.frm2.Hide();
        }
        private void Button_Pause(object sender, RoutedEventArgs e)
        {
            if(index)
            {
                MainWindow.music.Pause();
                timer.Stop();
                Button_01.Content = "继续";
                index = !index;
            }
            else
            {
                MainWindow.music.Play();
                timer.Start();
                Button_01.Content = "暂停";
                index= !index;
            }
        }
    }
}