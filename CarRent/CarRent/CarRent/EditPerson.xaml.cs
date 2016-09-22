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
    /// Interaction logic for EditPerson.xaml
    /// </summary>
    public partial class EditPerson : Window
    {
        //public EditPerson()
        //{
        //    InitializeComponent();
        //    context = new CarRentalCenterDBEntities();           
        //}

        public EditPerson(TablePersons row_input, CarRentalCenterDBEntities context_input)
        {
            InitializeComponent();
            context = new CarRentalCenterDBEntities();
            row = row_input;
            context = context_input;
            LoadData();
        }

        CarRentalCenterDBEntities context;
        TablePersons row;

        void LoadData()
        { 
            //TablePersons row = (TablePersons) from c in context.TablePersons select c;
            this.TextBoxFNameCurr.Text = row.FirstName;
            this.TextBoxLNameCurr.Text = row.LastName;
            this.TextBoxBirthCurr.Text = row.DateOfBirth.ToString();
            this.TextBoxAddressCurr.Text = row.Address.ToString();
            this.TextBoxPhoneCurr.Text = row.Phone;
            this.TextBoxEmailCurr.Text = row.E_mail.ToString();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            try 
            {                
                row.FirstName = this.TextBoxFNameNew.Text;
                row.LastName = this.TextBoxLNameNew.Text;
                row.DateOfBirth = this.DatePikerNew.DisplayDate;
                row.Address = this.TextBoxAddressNew.Text;
                row.Phone = this.TextBoxPhoneNew.Text;
                row.E_mail = this.TextBoxEmailNew.Text;

                context.SaveChanges();
                this.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }
    }
}
