using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Gradebook;

namespace Gradebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page classPage;

        public MainWindow main;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void WinFormButtonClick1(object sender, RoutedEventArgs e)
        {
            MainMDI main = new MainMDI(this);
            main.Show();
            this.Visibility = Visibility.Collapsed;
        }

        private void BtnClassViewClick(object sender, RoutedEventArgs e)
        {
            if (classPage == null)
            {
                classPage = new ClassPage();
                PageFrame.Content = classPage;
            } 
                else 
                    classPage.Visibility = Visibility.Visible;

        }
    }
}
