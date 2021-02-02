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
using System.Printing;
using System.Drawing;

namespace ChickenShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ShopContext context = new ShopContext ();
        private readonly DbOperations dbOperations = new DbOperations();
        private List<BillItems> listCustomerDgItems = new List<BillItems>();
        private List<BillItems> listTreaderDgItems = new List<BillItems>();

        public MainWindow()
        {
            InitializeComponent();
            SetComboCustomerNames();
            SetComboTreaderNames();
            SetComboItems();
            SetTotalCustomerBillPrice();
            dgBill.IsReadOnly = true;
            SetComboWorkerNames();
            SetPrintersDevicesCombo();
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (Tabs.SelectedItem == TabTreader )
            {
                dgBill.ItemsSource = null;
                listCustomerDgItems.Clear();
            }
             else if(Tabs.SelectedItem == TabCustomerBill)
            {
                dgTreaderBill.ItemsSource = null;
                listTreaderDgItems.Clear();
            }
        }

        #region items methods
        private void SetComboItems()
        {
            try
            {
                comboCustomerItemType.ItemsSource = dbOperations.SetItemsList();
                comboTreaderItemType.ItemsSource = dbOperations.SetItemsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboItemType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as ComboBox).SelectedValue as string;
            try
            {
                dbOperations.GetItemsList(selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region pricing window password settings
        private void BtnPricingSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var passWindow = new PasswordWindow();
                passWindow.ShowDialog();
                if (passWindow.State)
                {
                    var pricingWindow = new PricingWindow();
                    pricingWindow.ShowDialog();
                    SetComboItems();
                }
                else
                {
                    MessageBox.Show("wrong Password");
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.ToString());
            }
        }
        #endregion


        #region treader methods region


        private void SetComboTreaderNames()
        {
            comboTreaderNames.ItemsSource = context.TbTreaders.Select(t =>string.Concat(t.TreaderName + "\t\t\t\t\t" + t.TreaderMobileNumber + "\t\t\t\t\t" + t.TreaderAddress)).ToList();
        }
        private void ComboTreaderName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (sender as ComboBox).SelectedValue as string;
                var str = selected.Split('\t');
                var treader = dbOperations.LoadTreader(selected.Split('\t').ElementAt(0), selected.Split('\t').ElementAt(5));
                tbTreaderName.Text = treader.TreaderName;
                tbTreaderPhone.Text = treader.TreaderMobileNumber;
                tbTreaderAddress.Text = treader.TreaderAddress;

            }
            catch (Exception)
            {
                MessageBox.Show("error", "اضافة عنصر", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TbTreaderPhone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbTreaderPhone.Clear();
        }
        private void TbTreaderAddress_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbTreaderAddress.Clear();
        }

        private void btnTreaderBillPrint_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            try
            {
                if (!String.IsNullOrEmpty(tbTreaderName.Text) && !String.IsNullOrEmpty(tbTreaderPhone.Text) && !String.IsNullOrEmpty(tbTreaderAddress.Text))
                {
                    SetTreaderFields(tbTreaderName.Text, tbTreaderPhone.Text, tbTreaderAddress.Text);
                    flag = true;
                }
                else if (!String.IsNullOrEmpty(tbTreaderName.Text) && !String.IsNullOrEmpty(tbTreaderPhone.Text))
                {
                    SetCustomerFields(tbTreaderName.Text, tbTreaderPhone.Text);
                    flag = true;
                }
                else if (!String.IsNullOrEmpty(tbTreaderName.Text))
                {
                    SetTreaderFields(tbTreaderName.Text);
                    flag = true;
                }
                else
                {
                    MessageBox.Show("ادخل اسم التاجر على الاقل", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    flag = false;
                }
                if (flag)
                {
                    decimal quantity;
                    decimal.TryParse(tbTreaderItemQuantity.Text, out quantity);
                    dbOperations.UpdateItemQuantityAfterPrinting(quantity);
                    SetComboTreaderNames();
                    SetComboItems();
                    PrintringTreaderBill();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PrintringTreaderBill()
        {
            try
            {

                BillData billData = new BillData();
                billData.SetBillData(listTreaderDgItems, dbOperations.WorkerName, dbOperations.TreaderPK, dbOperations.TreaderPK);
                PrintBill printBill = new PrintBill(billData);
                printBill.SetBill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SetTreaderFields(string name, string mobile = "بدون", string address = "بدون")
        {
            MessageBox.Show(name + mobile + address);
            if (dbOperations.CheckOnTreader(name, mobile, address))
            {
                MessageBox.Show("تم اضافة تاجر جديد الى قاعدة البيانات", "عملية ناجحة", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var treader = dbOperations.LoadTreader(name, mobile);
                tbTreaderName.Text = treader.TreaderMobileNumber;
                tbTreaderPhone.Text = treader.TreaderMobileNumber;
                tbTreaderAddress.Text = treader.TreaderAddress;
            }
        }

        #endregion

        #region treader items


        private void tbTreaderIncomeMoney_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbTreaderIncomeMoney.Clear();
        }

        private void TbTreaderItemQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                decimal quantity;
                decimal res;
                if (decimal.TryParse(tbTreaderItemQuantity.Text, out quantity))
                {
                    if (dbOperations.CheckOnItemQuantity(quantity))
                    {
                        tbTreaderItemPrice.Text = (quantity * dbOperations.GetItemPrice()).ToString();
                    }
                    else
                        MessageBox.Show("الكمية المدخلة غير متوفرة بالمخزن");
                }
                else if (!(decimal.TryParse(tbTreaderItemQuantity.Text, out res)) && res == 0)
                {
                }
                else
                    MessageBox.Show("خطأ فى الكمية المدخلة");
            }

            catch (Exception)
            {
            }
        }

        private void btnAddItemToTreaderBill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = new BillItems(dbOperations.ItemPk);
                listTreaderDgItems.Add(item.GetBillItems(decimal.Parse(tbTreaderItemQuantity.Text)));
                DataGridTreaderUpdateBillItems();
                SetTotalTreaderBillPrice();
                MessageBox.Show(listTreaderDgItems.LastOrDefault().Item.TbItemType.ItemName);
                tbTreaderItemQuantity.Text = "0"; tbItemPrice.Text = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DataGridTreaderUpdateBillItems()
        {
            dgTreaderBill.ItemsSource = listTreaderDgItems.ToList();
            SetTotalTreaderBillPrice();
        }

        private void SetTotalTreaderBillPrice()
        {
            decimal remind;
            decimal income;
            decimal total;

            decimal.TryParse(tbTreaderIncomeMoney.Text, out income);

            try
            {
                if (listTreaderDgItems.Count != 0)
                {
                    total = listTreaderDgItems.Sum(c => c.ItemBillPrice);
                    tbTreaderBillTotalMoney.Text = total.ToString();
                    remind = total - income;
                    tbTotalTreaderReminderPrice.Text = remind.ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnDeleteItemFromTreaderBill_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                var selected = dgTreaderBill.SelectedItem as BillItems;
                listTreaderDgItems.RemoveAt(listTreaderDgItems.FindIndex(item => item.Item.ItemIDPK == selected.Item.ItemIDPK));
                dgTreaderBill.ClearDetailsVisibilityForItem(dgTreaderBill.SelectedItem);
                DataGridTreaderUpdateBillItems();
            }
            catch (Exception)
            {
                MessageBox.Show("لم يتم تحديد العنصر ", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tbTreaderIncomeMoney_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetTotalTreaderBillPrice();
        }

        #endregion


        #region customer window methods
        private void ComboCustomerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (sender as ComboBox).SelectedValue as string;
                var str = selected.Split('\t');
                var customer = dbOperations.LoadCustomer(selected.Split('\t').ElementAt(0), selected.Split('\t').ElementAt(4));
                tbCustomerName.Text = customer.CustomerName;
                tbCustomerPhone.Text = customer.CustomerMobileNumber;
                tbCustomerAddress.Text = customer.CustomerAddress;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               // MessageBox.Show("لا توجد بيناتات للعميل","error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetComboCustomerNames()
        {
            comboCustomerNames.ItemsSource = context.TbCustomers.Select(c=> String.Concat(c.CustomerName + "\t\t\t\t" + c.CustomerMobileNumber + "\t\t\t\t\t" + c.CustomerAddress)).ToList();
        }

        private void BtnCustomerBillPrint_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            try
            {
                if (!String.IsNullOrEmpty(tbCustomerName.Text) && !String.IsNullOrEmpty(tbCustomerPhone.Text) && !String.IsNullOrEmpty(tbCustomerAddress.Text))
                {
                    SetCustomerFields(tbCustomerName.Text , tbCustomerPhone.Text, tbCustomerAddress.Text);
                    flag = true;
                }
                else if (!String.IsNullOrEmpty(tbCustomerName.Text) && !String.IsNullOrEmpty(tbCustomerPhone.Text))
                {
                    SetCustomerFields(tbCustomerName.Text, tbCustomerPhone.Text);
                    flag = true;
                }
                else if (!String.IsNullOrEmpty(tbCustomerName.Text))
                {
                    SetCustomerFields(tbCustomerName.Text);
                    flag = true;
                }
                else
                {
                    MessageBox.Show("ادخل اسم العميل على الاقل", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    flag = false;
                }
                if (flag)
                {
                    decimal quantity;
                    decimal.TryParse(tbItemQuantity.Text, out quantity);
                    dbOperations.UpdateItemQuantityAfterPrinting(quantity);
                    SetComboCustomerNames();
                    SetComboItems();
                    PrintringCustomerBill();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SetCustomerFields(string name, string mobile="بدون", string address ="بدون")
        {
            MessageBox.Show(name + mobile + address);
            if (dbOperations.CheckOnCustomer(name , mobile , address))
            {
                MessageBox.Show("تم اضافة عميل جديد الى قاعدة البيانات", "عملية ناجحة", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var customer = dbOperations.LoadCustomer(name, mobile);
                tbCustomerName.Text = customer.CustomerName;
                tbCustomerPhone.Text = customer.CustomerMobileNumber;
                tbCustomerAddress.Text = customer.CustomerAddress;

            }
        }

        private void TbCustomerPhone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbCustomerPhone.Clear();
        }
        private void TbCustomerAddress_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbCustomerAddress.Clear();
        }
        #endregion


        #region customer items 
        private void TbItemQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                decimal quantity;
                decimal res;
                if (decimal.TryParse(tbItemQuantity.Text, out quantity))
                {
                    if (dbOperations.CheckOnItemQuantity(quantity))
                    {
                        tbItemPrice.Text = (quantity * dbOperations.GetItemPrice()).ToString();
                    }
                    else
                        MessageBox.Show("الكمية المدخلة غير متوفرة بالمخزن");
                }
                else if (!(decimal.TryParse(tbItemPrice.Text, out res)) && res == 0)
                {
                }
                else
                    MessageBox.Show("خط فى الكمية المدخلة");
            }

            catch (Exception)
            {
            }    
        }

        private void BtnAddItemToBill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = new BillItems(dbOperations.ItemPk);
                listCustomerDgItems.Add(item.GetBillItems(decimal.Parse(tbItemQuantity.Text)));
                DataGridUpdateBillItems();
                SetTotalCustomerBillPrice();
                MessageBox.Show(listCustomerDgItems.LastOrDefault().Item.TbItemType.ItemName);
                tbItemQuantity.Text = "0" ; tbItemPrice.Text = "0" ;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DataGridUpdateBillItems()
        {
            dgBill.ItemsSource = listCustomerDgItems.ToList();
            SetTotalCustomerBillPrice();
        }

        private void SetTotalCustomerBillPrice()
        {
            if (listCustomerDgItems.Count == 0)
            {
                tbTotalCustomerBillPrice.Text = "0" ;
            }
            else 
                tbTotalCustomerBillPrice.Text = listCustomerDgItems.Sum(c => c.ItemBillPrice).ToString();
        }
        
        private void BtnDeleteItemFromBill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = dgBill.SelectedItem as BillItems;
                listCustomerDgItems.RemoveAt(listCustomerDgItems.FindIndex(item => item.Item.ItemIDPK == selected.Item.ItemIDPK));
                dgBill.ClearDetailsVisibilityForItem(dgBill.SelectedItem);
                DataGridUpdateBillItems();
            }
            catch (Exception)
            {
                MessageBox.Show("لم يتم تحديد العنصر ","error", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        #endregion

        #region workers

        private void SetComboWorkerNames()
        {
            try
            {
                comboWorkerName.ItemsSource = dbOperations.GetWorkersNames().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BtnConfirmWorker_Click(object sender, RoutedEventArgs e)
        {
            SelectComboWorkerName();
        }

        private void SelectComboWorkerName()
        {
            try
            {
                PasswordWindow passwordWindow = new PasswordWindow();
                passwordWindow.ShowDialog();
                if (passwordWindow.State)
                {
                    dbOperations.WorkerName = comboWorkerName.SelectedValue as string;
                }
                else
                {
                    comboWorkerName.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PasswordWindow passwordWindow = new PasswordWindow();
                passwordWindow.ShowDialog();

                if (passwordWindow.State)
                {
                    passwordWindow.Close();
                    WorkerManipolute workerManipolute = new WorkerManipolute();
                    workerManipolute.ShowDialog();
                    workerManipolute.Close();
                }
                else
                {
                    MessageBox.Show("كلمة مرور خاطئة", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                SetComboWorkerNames();
            }
            catch (Exception)
            {
                MessageBox.Show("خطأ", "error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void BtnDeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboWorkerName.SelectedItem as string))
            {
                PasswordWindow passwordWindow = new PasswordWindow();
                passwordWindow.ShowDialog();
                if (passwordWindow.State)
                {
                    if (dbOperations.DeleteWorker(comboWorkerName.SelectedItem as string))
                    {
                        MessageBox.Show("تم حذف العامل", "success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("لم حذف العامل", "success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                    MessageBox.Show("كلمة مرور خاطئة", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("لم يتم تحديد اسم العامل", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            SetComboWorkerNames();
        }

        #endregion


        #region printing
        private void SetPrintersDevicesCombo()
        {
            try
            {
                var printers = new LocalPrintServer().GetPrintQueues().Select(p => p.Name);
                comboPrinterType.ItemsSource = printers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintringCustomerBill()
        {
            try
            {

                BillData billData = new BillData();
                billData.SetBillData(listCustomerDgItems, dbOperations.WorkerName, dbOperations.CustomerPk, dbOperations.CustomerPk);
                PrintBill printBill = new PrintBill(billData);
                printBill.SetBill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnPrinterTypeConfirm_Click(object sender, RoutedEventArgs e)
        {
            var printers = new LocalPrintServer().GetPrintQueues().Select(p => p.Name);
            var printer = new LocalPrintServer().GetPrintQueues().ElementAt(3);
           // var doc = new FlowDocument();
            try
            {
 //               PrintBill printedBill = new PrintBill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //wind.ShowDialog();

        }



        #endregion


    }
}
