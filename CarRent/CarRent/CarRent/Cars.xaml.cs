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
    /// Interaction logic for Cars.xaml
    /// </summary>
    public partial class Cars : Window
    {
        public Cars()
        {
            InitializeComponent();
            context = new CarRentalCenterDBEntities();
            RefreshWindow();

        }

        void RefreshWindow()
        {
            this.DataGridCars.ItemsSource = context.FuncCars();
        }
        CarRentalCenterDBEntities context;

        private void ButtonAddCar_Click(object sender, RoutedEventArgs e)
        {
            new AddCar().ShowDialog();
            RefreshWindow();

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonShowOrders_Click(object sender, RoutedEventArgs e)
        {
            FuncCars_Result row = new FuncCars_Result();
            row = (FuncCars_Result) this.DataGridCars.SelectedItems[0];

            string vinSelectedCar = "";
            vinSelectedCar = (string)row.VIN;

            new Orders(vinSelectedCar).ShowDialog();
        }
    }
}
