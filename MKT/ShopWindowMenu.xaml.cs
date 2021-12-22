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
using System.Windows.Shapes;

namespace MKT
{
    /// <summary>
    /// Логика взаимодействия для ShopWindowMenu.xaml
    /// </summary>
    public partial class ShopWindowMenu : Window
    {
        public ShopWindowMenu()
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = (screenHeight - this.Height) / 2.0;
            this.Left = (screenWidth - this.Width) / 2.0;
        }

        private void cashRegisterButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void queryButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void filterButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void exitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
