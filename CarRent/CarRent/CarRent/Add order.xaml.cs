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
    /// Interaction logic for Add_order.xaml
    /// </summary>
    public partial class Add_order : Window
    {
        public Add_order(CarRentalCenterDBEntities context_input)
        {
            InitializeComponent();
            context = context_input;
            this.ComboBoxStatus.ItemsSource = new DataSet1TableAdapters.TableStatusTableAdapter().GetData();
            this.ComboBoxStatus.DisplayMemberPath = "Status";
        }

        CarRentalCenterDBEntities context;

        public static string selectedCarVIN = "initialized"; //????????
        public static int selectedPersonID; //??????

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSelectCar_Click(object sender, RoutedEventArgs e)
        {
            SelectCar selCarWindow = new SelectCar("Adding");
            selCarWindow.ShowDialog();
            this.ButtonSelectCar.Content = "Selected!";
        }

        private void ButtonSelectPerson_Click(object sender, RoutedEventArgs e)
        {
            new SelectPerson("Adding").ShowDialog();
            this.ButtonSelectPerson.Content = "Selected!";
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            TableCars selectedCar = new TableCars();
            selectedCar = (TableCars)(from c in context.TableCars 
                                      where c.VIN == selectedCarVIN 
                                      select c).First();

            TableStatus selectedStatus = new TableStatus();
            selectedStatus = (TableStatus)(from c in context.TableStatus
                                           where c.Status == this.ComboBoxStatus.Text
                                           select c).First();

            TableOrders newRow = new TableOrders();
            newRow.idCar= selectedCar.Id;
            newRow.idPerson=selectedPersonID;
            newRow.Date=this.DatePickerBirth.SelectedDate;
            newRow.Amount= Convert.ToDecimal(this.TextBoxAmount.Text);  //!!!
            newRow.StatusID=selectedStatus.Id;

            context.TableOrders.Add(newRow);
            context.SaveChanges();
            this.Close();
        }
    }
}
