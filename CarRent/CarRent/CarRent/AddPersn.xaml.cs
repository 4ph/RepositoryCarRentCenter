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
    /// Interaction logic for AddPersn.xaml
    /// </summary>
    public partial class AddPersn : Window
    {
        public AddPersn()
        {
            InitializeComponent();
        }
        

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CarRentalCenterDBEntities context = new CarRentalCenterDBEntities();
                context.TablePersons.Add(
                    new TablePersons()
                    {
                        FirstName = this.TextBoxFName.Text,
                        LastName = this.TextBoxLname.Text,
                        DateOfBirth = this.DatePicked.SelectedDate,
                        Address = this.TextBoxAddress.Text,
                        Phone = this.TextBoxPhone.Text,
                        E_mail = this.TextBoxEmail.Text
                    });

                context.SaveChanges();
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }            
        }
    }
}
