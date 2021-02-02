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
    /// Interaction logic for WorkerManipolute.xaml
    /// </summary>
    public partial class WorkerManipolute : Window
    {
        private ShopContext context = new ShopContext();
        public WorkerManipolute()
        {
            InitializeComponent();
            tbWorkerName.Focus();
        }

        private void BtnWorkerCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnWorkerNameConfirm_Click(object sender, RoutedEventArgs e)
        {
            try { 
                if (!String.IsNullOrEmpty(tbWorkerName.Text))
                {
                    var worker = new TbWorker() { WorkerName = tbWorkerName.Text };
                    if (context.TbWorkers.SingleOrDefault(w => w.WorkerName == worker.WorkerName) != null)
                    {
                        MessageBox.Show("يوجد عامل بنفس الاسم","error",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                    else
                    {
                        context.TbWorkers.Add(worker);
                        context.SaveChanges();
                        MessageBox.Show("تم اضافة العامل بنجاح", "success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
