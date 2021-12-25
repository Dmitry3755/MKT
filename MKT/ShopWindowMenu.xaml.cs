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
using System.Configuration;
using Ninject;
using Ninject.Modules;
using BLL.Interfaces;
using BLL;
using MKT.Util;

namespace MKT
{
    /// <summary>
    /// Логика взаимодействия для ShopWindowMenu.xaml
    /// </summary>
    public partial class ShopWindowMenu : Window
    {
        IChequeService chequeService;
        IChequeCreate chequeCreate;
        public ShopWindowMenu()
        {
            string connection = ConfigurationManager.ConnectionStrings["PcshopContext"].ConnectionString;
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule(connection));
            chequeService = kernel.Get<IChequeService>();
            chequeCreate = kernel.Get<IChequeCreate>();

            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = (screenHeight - this.Height) / 2.0;
            this.Left = (screenWidth - this.Width) / 2.0;
        }

        private void cashRegisterButtonClick(object sender, RoutedEventArgs e)
        {
            PurchaseWindow purchaseWindow = new PurchaseWindow(chequeService, chequeCreate);
            purchaseWindow.ShowDialog();
        }

        private void queryButtonClick(object sender, RoutedEventArgs e)
        {
            QueryWindow queryWindow = new QueryWindow(chequeService);
            queryWindow.ShowDialog();
        }

        private void filterButtonClick(object sender, RoutedEventArgs e)
        {
            FilterWindow filterWindow = new FilterWindow(chequeService);
            filterWindow.ShowDialog();
        }

        private void exitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
