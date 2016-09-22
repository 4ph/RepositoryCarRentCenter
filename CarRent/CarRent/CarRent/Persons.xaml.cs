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
    /// Interaction logic for Persons.xaml
    /// </summary>
    public partial class Persons : Window
    {
        public Persons()
        {
            InitializeComponent();
            RefreshWindow();
        }
        
        void RefreshWindow()
        {
            context = new CarRentalCenterDBEntities();
            this.DataGridPersons.ItemsSource = (from c in context.TablePersons select c).ToArray();
        }

        CarRentalCenterDBEntities context;

        private void ButtonAddPerson_Click(object sender, RoutedEventArgs e)
        {
            new AddPersn().ShowDialog();
            RefreshWindow();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            TablePersons row = new TablePersons();
            row = (TablePersons) this.DataGridPersons.SelectedItems[0];
            int id_del = row.Id;
            
            context.TablePersons.Remove(context.TablePersons.Find(id_del));
            context.SaveChanges();
            RefreshWindow();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            TablePersons row = new TablePersons();
            row = (TablePersons)this.DataGridPersons.SelectedItems[0];
            new EditPerson(row, context).ShowDialog();
            RefreshWindow();
        }
    }
}
