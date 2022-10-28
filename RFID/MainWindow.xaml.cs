using RFID.Cores;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RFID
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
        private void Label_MouseLeftButtonDown_1(object sender, EventArgs e)
        {
            Window.GetWindow(this).WindowState = Window.GetWindow(this).WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        /// <summary>
        /// exit program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseLeftButtonDown_2(object sender, EventArgs e)
        {
            if(pwd.Password.Equals("ain7679!"))
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
            else
            {
                SharedPreferences.Instance.StatusMessage = "정확한 관리자의 password 입력하세요.";
                return;
            }
            
        }
    }
}
