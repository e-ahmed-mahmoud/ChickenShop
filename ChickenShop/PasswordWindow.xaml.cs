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

namespace ChickenShop
{
    /// <summary>
    /// Interaction logic for PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public bool State { get; set; }
        public PasswordWindow()
        {
            InitializeComponent();
            pbItemsAccesses.Focus();
         
            btnPasswordAccessesCancel.Click += BtnPasswordAccessesCancel_Click;
        }
        private void BtnPasswordAccessesCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnPasswordAccessesConfirm_Click(object sender, RoutedEventArgs e)
        {
            var context = new ShopContext();

            if (pbItemsAccesses.Password == context.TbPasswords.Find(1).Password.Trim('\''))
            {
                MessageBox.Show("true password", "My App", MessageBoxButton.OK, MessageBoxImage.Information);
                State = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("WrongPassword");
            }
        }
        
    }
}
