using BLL.Interfaces;
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
using System.Configuration;
using Ninject;
using Ninject.Modules;
using BLL;
using MKT.Util;

namespace MKT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IAuthorizationService authorizationService;

        public MainWindow()
        {
            string connection = ConfigurationManager.ConnectionStrings["PcshopContext"].ConnectionString;
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule(connection));
            authorizationService = kernel.Get<IAuthorizationService>();

            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = (screenHeight - this.Height) / 2.0;
            this.Left = (screenWidth - this.Width) / 2.0;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            EntryWindow entryWindow = new EntryWindow();
            entryWindow.Show();
            this.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow(authorizationService);
            createAccountWindow.Show();
            this.Close();    
        }
    }
}
