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
    /// Interaction logic for PricingWindow.xaml
    /// </summary>
    public partial class PricingWindow : Window
    {
        private readonly ShopContext context = new ShopContext();
        private readonly DbOperations dbOperations = new DbOperations();

        private List<TbBill_Items> dglist = new List<TbBill_Items>();

        public PricingWindow()
        {
            InitializeComponent();
            SetComboBoxItems();

            SetDateGridItems(DateTime.Today);
        }

        private void SetComboBoxItems()
        {
            comboDialyItemType.ItemsSource = context.TbItemTypes.Select(c => c.ItemName).ToList();
        }

        private void BtnAddItemToDialy_Click(object sender, RoutedEventArgs e)
        {          
            try
            {
                decimal quantity;
                decimal price;

                if (!String.IsNullOrEmpty(tbDialyItemType.Text) && decimal.TryParse(tbDialyItemPrice.Text, out price) && decimal.TryParse(tbDialyItemQuantity.Text, out quantity))
                {
                    dbOperations.AddingNewItems(tbDialyItemType.Text, price , quantity);
                    MessageBox.Show("تمت العملية بنجاح","اضافة عنصر",MessageBoxButton.OK,MessageBoxImage.Information);
                    SetDateGridItems(DateTime.Today);
                }
                else
                {
                    MessageBox.Show("البيانات غير مكتملة","اضافة عنصر",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            catch (Exception )
            {
                MessageBox.Show("لم يتم اضافة العنصر", "اضافة عنصر", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboDialyItemType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (sender as ComboBox).SelectedItem as string;
                tbDialyItemType.Text = selected;
            }
            catch (Exception )
            {
                MessageBox.Show("لم يتم اضافة العنصر", "اضافة عنصر", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        void SetDateGridItems(DateTime dateTime )
        {
            try
            {
                if (context.TbBill_Items.FirstOrDefault(c => c.TodayItem.Day == dateTime.Day && c.TodayItem.Month == dateTime.Month && c.TodayItem.Year == dateTime.Year) != null)
                {
                    dglist = context.TbBill_Items.Where(c => c.TodayItem.Day == dateTime.Day && c.TodayItem.Month == dateTime.Month && c.TodayItem.Year == dateTime.Year).
                        OrderByDescending(d=>d.TodayItem).ToList();
                    dgStock.ItemsSource = dglist;
                }
                else
                {
                    MessageBox.Show("لا يوجد عناصر لهذا التاريخ","error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnStockGetDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnCalender.SelectedDate.Value != null)
                    SetDateGridItems(btnCalender.SelectedDate.Value);
                else
                    MessageBox.Show("لم يتم تحديد التاريخ", "Date not set", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDeleteItemFromStock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = dgStock.SelectedItem as TbBill_Items;
                if (dbOperations.DeleteItemFromTbItems(selected.ItemIDPK))
                {
                    MessageBox.Show("done");
                }SetDateGridItems(DateTime.Today);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditItemInStock_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var selected = dgStock.SelectedValue as TbBill_Items;
                if (dbOperations.EditItemInTBItems(selected.ItemIDPK, selected.Price, selected.Quantity, selected.TbItemType.ItemName))
                {
                    MessageBox.Show("تم تعديل العنصر", "done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("لم تم تعديل العنصر", "error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("لم يتم تحديد العنصر", "error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
