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
    /// Interaction logic for SelectPerson.xaml
    /// </summary>
    public partial class SelectPerson : Window
    {
        public SelectPerson()
        {
            InitializeComponent();
            RefrWindow();
        }
        public SelectPerson(string str_inpt)
        {
            InitializeComponent();
            RefrWindow();
            caller = str_inpt;
        }

        string caller;
        System.Data.DataRowView row;

        void ReturnVal()
        {
            if (caller == "Editing")
            {
                EditORder.editedPersonID = (int)row[0];
            }
            if (caller == "Adding") 
            {
                Add_order.selectedPersonID = (int)row[0];
            }
        }

        void RefrWindow()
        {
            this.DataGridPerson.ItemsSource = new DataSet1TableAdapters.TablePersonsTableAdapter().GetData();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {            
            row = (System.Data.DataRowView) this.DataGridPerson.SelectedItems[0];

            ReturnVal();

            this.Close();
        }
    }
}
