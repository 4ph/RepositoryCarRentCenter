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
    /// Interaction logic for SelectCar.xaml
    /// </summary>
    public partial class SelectCar : Window
    {
        public SelectCar()
        {
            InitializeComponent();
            RefreshWindow();
        }

        public SelectCar(string str_inpt)
        {
            InitializeComponent();
            RefreshWindow();
            caller = str_inpt;
            this.row = new FuncCars_Result();
        }

        string caller;
        FuncCars_Result row;

        void ReturnVal()
        {
            if (caller == "Adding") { Add_order.selectedCarVIN = row.VIN; }
            if (caller == "Editing") { EditORder.editedCarID = row.id; }
        }

        void RefreshWindow()
        { 
            this.DataGridSelectCar.ItemsSource = from c in new CarRentalCenterDBEntities().FuncCars().ToArray() select c;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {            
            this.Close();
        }
        
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            row = (FuncCars_Result) this.DataGridSelectCar.SelectedItems[0];    //  !!!
            ReturnVal();
            
            this.Close();
        }
    }
}
