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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
            RefreshWindow();            
        }
        CarRentalCenterDBEntities context;

        void RefreshWindow()
        {
            //this.DataGridUsers.ItemsSource = new CarRentalCenterDBEntities().FuncUsers();
            context = new CarRentalCenterDBEntities();
            this.DataGridUsers.ItemsSource = from c in context.FuncUsers() select c;
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddUser().ShowDialog();
            RefreshWindow();
        }

        private void ButtonDelUser_Click(object sender, RoutedEventArgs e)
        {
            int id_del;
            string usrnm_del;
            int grpid_del;
            string lgn_del;
            string pass_del;

            //===========Selecting ID of current user in selected row in the DataGrid
            FuncUsers_Result  row = (FuncUsers_Result) DataGridUsers.SelectedItems[0];  // !!!

            id_del = (int) row.Id;
            usrnm_del = row.Usr;
            lgn_del = row.Lgin;
            pass_del = row.Pass;
            string nameGroup = row.NameGrp.ToString();
            
            //========================Searching the id of group, by name
            CarRentalCenterDBEntities context = new CarRentalCenterDBEntities();
            var row2 = (from c in context.TableGroups where c.NameGrp == nameGroup select c).First();   //select from table (LINQ)
            grpid_del = row2.Id;//

            //context.TableUsers.Find(id_del);

            //TableUsers user_del = new TableUsers() { Id = id_del, GroupsID = grpid_del, Lgin = lgn_del, Pass = pass_del, Usr = usrnm_del };

            context.TableUsers.Remove(context.TableUsers.Find(id_del));
            context.SaveChanges();
            RefreshWindow();
        }
    }
}
