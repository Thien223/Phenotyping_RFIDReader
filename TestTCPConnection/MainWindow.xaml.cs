using RFID.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RFID
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBoxOutputter outputter;
        public MainWindow()
        {
            InitializeComponent(); 
            outputter = new TextBoxOutputter(Log);
            Console.SetOut(outputter);
            Console.WriteLine("Started");

            var timer1 = new Timer(TimerTick, "Timer1", 0, 1000);
            var timer2 = new Timer(TimerTick, "Timer2", 0, 500);
        }

        void TimerTick(object state)
        {
            var who = state as string;
            Console.WriteLine(who);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                GetWindow(this).DragMove();
            }
        }


        private void Label_MouseLeftButtonDown(object sender, EventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// toggle maximized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseLeftButtonDown_Resize(object sender, EventArgs e)
        {
            Window.GetWindow(this).WindowState = Window.GetWindow(this).WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
        
        /// <summary>
        /// toggle maximized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseLeftButtonDown_Close(object sender, EventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Title.Equals("MainWindow"))
                {
                    window.Close();
                }
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        ///// <summary>
        ///// exit program
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Border_MouseLeftButtonDown_2(object sender, EventArgs e)
        //{
        //    if(pwd.Password.Equals("ain7679!"))
        //    {

        //        foreach (Window window in Application.Current.Windows)
        //        {
        //            if (window.Title.Equals("MainWindow"))
        //            {
        //                window.Close();
        //            }
        //        }
        //        System.Diagnostics.Process.GetCurrentProcess().Kill();
        //    }
        //    else
        //    {
        //        SharedPreferences.Instance.StatusMessage = "정확한 관리자의 password 입력하세요.";
        //        return;
        //    }

        //}
    }
}
