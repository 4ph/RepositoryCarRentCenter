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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();

            this.ComboBoxGroup.ItemsSource = new DataSet1TableAdapters.TableGroupsTableAdapter().GetData();            
            this.ComboBoxGroup.DisplayMemberPath = "NameGrp";
            //this.ComboBoxGroup.SelectedValue = "NameGrp";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string username = this.TextBoxUsername.Text.ToString();
            string login = this.TextBoxLogin.Text.ToString();
            string password = this.TextBoxPassword.Text.ToString();
            string grup = this.ComboBoxGroup.Text.ToString();
            //========================Searching id by the name of user group in the tabe TabeGroups
            CarRentalCenterDBEntities context = new CarRentalCenterDBEntities();
            var row = (from c in context.TableGroups where c.NameGrp == grup select c).First(); // !!!!
            int idGroup = row.Id;//
            //==========================Adding new user
 
            context.TableUsers.Add(new TableUsers(){Usr = username, GroupsID=idGroup, Lgin=login, Pass=password});

            context.SaveChanges();
            this.Close();        
        }
    }
}
