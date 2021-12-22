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
using System.Security.Cryptography;


namespace MKT
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public PCShopContext dbcontext = new PCShopContext();
        public Window1()
        {
            InitializeComponent();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = (screenHeight - this.Height) / 2.0;
            this.Left = (screenWidth - this.Width) / 2.0;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string hash;
            hash = Hash(passwordBox.Password.ToString());
           
            Users users = new Users();
            users.user_login = loginTextBox.Text;
            users.user_password = hash;
            dbcontext.Users.Add(users);
            dbcontext.SaveChanges();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private string Hash(string ha)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                string base64string = Convert.ToBase64String(Encoding.UTF8.GetBytes(ha));
                byte[] buffer = Convert.FromBase64String(base64string);

                var sb = new StringBuilder();
                for (var i = 0; i < buffer.Length; i++)
                {
                    sb.Append(buffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
