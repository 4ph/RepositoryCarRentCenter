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
    /// Interaction logic for WorkPlace.xaml
    /// </summary>
    public partial class WorkPlace : Window
    {
        public WorkPlace()
        {
            InitializeComponent();
        }

        public WorkPlace(string strLogin)
        {
            InitializeComponent();
            this.currentUser = strLogin;

            if (currentUser == "admin") { new WorkPlace().ShowDialog(); }
        }
        string currentUser;

        CarRentalCenterDBEntities context = new CarRentalCenterDBEntities();

        private void MenuItemCars2_Click(object sender, RoutedEventArgs e)
        {
            new Cars().ShowDialog();            
        }

        private void MenuItemPersons_Click(object sender, RoutedEventArgs e)
        {
            new Persons().ShowDialog();
        }

        private void MenuItemUsers_Click(object sender, RoutedEventArgs e)
        {
            new Users().ShowDialog();
        }

        private void MenuItemGroups_Click(object sender, RoutedEventArgs e)
        {
            new Groups().ShowDialog();
        }

        private void MenuItemMakers_Click(object sender, RoutedEventArgs e)
        {
            new Makers().ShowDialog();
        }

        private void MenuItemModels_Click(object sender, RoutedEventArgs e)
        {
            new Models().ShowDialog();
        }

        private void MenuItemStatus_Click(object sender, RoutedEventArgs e)
        {
            new Status().ShowDialog();
        }

        private void MenuItemOrders_Click(object sender, RoutedEventArgs e)
        {
            new Orders().ShowDialog();
        }
    }
}
