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

namespace CarRent
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders()
        {
            InitializeComponent();
            context = new CarRentalCenterDBEntities();
            this.DataGridOrders.ItemsSource = context.FuncOrders1();
        }

        string vinOfselectedCar;

        public Orders(string vinCar_inpt)
        {
            InitializeComponent();
            vinOfselectedCar = vinCar_inpt;
            context = new CarRentalCenterDBEntities();
            this.DataGridOrders.ItemsSource = (from c in context.FuncOrders1()
                                              where c.VIN == vinOfselectedCar
                                              select c).ToArray();

        }

        CarRentalCenterDBEntities context;

        void RefreshWindow()
        { 
            this.DataGridOrders.ItemsSource = from c in context.FuncOrders1() select c;
        }

        private void ButtonAddPerson_Click(object sender, RoutedEventArgs e)
        {
            new Add_order(context).ShowDialog();
            RefreshWindow();
        }

        private void RemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            FuncOrders1_Result selectedRow = new FuncOrders1_Result();
            selectedRow = (FuncOrders1_Result) this.DataGridOrders.SelectedItems[0];

            TableOrders rowForDel = new TableOrders();
            rowForDel = (from c in context.TableOrders where c.Id == selectedRow.id select c).First();

            context.TableOrders.Remove(rowForDel);
            context.SaveChanges();
            RefreshWindow();
        }

        private void ButtonEditOrder_Click(object sender, RoutedEventArgs e)
        {
            FuncOrders1_Result selectedRow = new FuncOrders1_Result();
            selectedRow = (FuncOrders1_Result)this.DataGridOrders.SelectedItems[0];
            new EditORder(context, selectedRow).ShowDialog();
            RefreshWindow();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
