using System;
using System.Collections.Generic;
using System.Data;
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
using BLL;
using BLL.Interfaces;

namespace MKT
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        IChequeService chequeService;

        List<CategoryModel> allCategory;
        List<ProductsModel> allProducts;
        CategoryModel CategoryDTO = new CategoryModel();    
        public ProductsModel selectedProduct = new ProductsModel();

        public AddProductWindow(IChequeService service)
        {
            chequeService = service;
            InitializeComponent();

            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = (screenHeight - this.Height) / 2.0;
            this.Left = (screenWidth - this.Width) / 2.0;

            loadData();
        }

        private void countOfProductTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void acceptButtonClick(object sender, RoutedEventArgs e)
        {
            object product = 0;
            int id = 0;

            if (dataGrid.SelectedItems.Count > 0)
            {
                product = dataGrid.SelectedItem;
            }
            else
            {
                MessageBox.Show("Вы не выбрали товар");
                return;
            }
            id = Convert.ToInt32(product.GetType().GetProperty("Id").GetValue(product, null));
            selectedProduct = chequeService.GetProduct(id);

            if (Convert.ToInt32(countOfProductTextBox.Text) > Convert.ToInt32(selectedProduct.count_of_products))
            {
                MessageBox.Show("Вы не можете выбрать количество большее, чем есть на складе");
            }
            else
            {
                selectedProduct.count_of_products = Convert.ToInt32(countOfProductTextBox.Text);
                this.Close();
            }
        }

        private void loadData()
        {
            allCategory = chequeService.GetCategories();
            allProducts = chequeService.GetAllProducts();
            dataGrid.ItemsSource = allProducts
            .Join(allCategory, pr => pr.category_FK, ct => ct.category_id, (pr, ct) => new
            {
                Id = pr.product_id,
                Название = pr.product_name,
                Характеристика = pr.technical_specifications,
                Количество = pr.count_of_products,
                Цена = pr.product_price,
                Скидка = pr.discount,
                Категория = ct.category_name
            }).ToList();
        }
    }
}
