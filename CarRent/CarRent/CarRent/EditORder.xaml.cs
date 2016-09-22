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
    /// Interaction logic for EditORder.xaml
    /// </summary>
    public partial class EditORder : Window
    {
        public EditORder()
        {
            InitializeComponent();
        }

        public EditORder(CarRentalCenterDBEntities context_inpt, FuncOrders1_Result selectedRow_inpt)
        {
            InitializeComponent();
            this.context=context_inpt;

            this.selectedRow = selectedRow_inpt;
            this.context = context_inpt;

            this.LabelAmountCurr.Content=selectedRow.Amount.ToString();
            this.LabelCarCurr.Content=selectedRow_inpt.Maker+selectedRow_inpt.Model;
            this.LabelDateCurr.Content=selectedRow_inpt.Date;
            this.LabelPersonCurr1.Content=selectedRow_inpt.FirstName+selectedRow_inpt.LastName;
            
            this.LabelStatusCurr.Content=selectedRow_inpt.Status;

            this.ComboBoxEditStatus.ItemsSource = (from c in context.TableStatus select c).ToArray();
            this.ComboBoxEditStatus.DisplayMemberPath = "Status";

        }

        CarRentalCenterDBEntities context;
        FuncOrders1_Result selectedRow;

        public static int editedCarID;
        public static int editedPersonID;
        
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            TableOrders editedOrder = new TableOrders();
            editedOrder = (TableOrders)(from c in context.TableOrders where c.Id == selectedRow.id select c).First();

            editedOrder.idPerson = editedPersonID;
            editedOrder.idCar = editedCarID;
            editedOrder.Date = this.DatePickedDateEdited.SelectedDate;
            editedOrder.Amount = Convert.ToDecimal(this.TextBoxAmountEdited.Text);

            TableStatus editedStatus = new TableStatus();

            editedStatus = (from c in context.TableStatus
                              where c.Status == this.ComboBoxEditStatus.Text
                              select c).First();
            editedOrder.StatusID = editedStatus.Id;

            context.SaveChanges();
            this.Close();
        }

        private void ButtunEditPerson_Click(object sender, RoutedEventArgs e)
        {
            new SelectPerson("Editing").ShowDialog();
            this.ButtunEditPerson.Content = "Selected!";
        }

        private void ButtonEditCar_Click(object sender, RoutedEventArgs e)
        {
            new SelectCar("Editing").ShowDialog();
            this.ButtonEditCar.Content = "Edited!";
        }
    }
}
