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
    /// Interaction logic for AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        public AddCar()
        {
            InitializeComponent();

            this.ComboBoxMaker.ItemsSource = (from c in context.TableMakers select c).ToArray();
            this.ComboBoxMaker.DisplayMemberPath = "Maker";

            this.ComboBoxModel.ItemsSource = (from d in context.TableModels select d).ToArray();
            this.ComboBoxModel.DisplayMemberPath = "Model";

        }

        CarRentalCenterDBEntities context = new CarRentalCenterDBEntities();

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            TableCars newCar = new TableCars();
            var row1 = (TableMakers)(from c in context.TableMakers
                                where c.Maker == this.ComboBoxMaker.Text
                                select c).First();
            newCar.MakerID = (int) row1.Id;

            var row2 = (TableModels)(from c in context.TableModels
                                     where c.Model == this.ComboBoxModel.Text
                                     select c).First();
            newCar.ModelID = (int) row2.Id;

            newCar.Year = this.DatePicketYear.SelectedDate;
            newCar.VIN = this.TextBoxVIN.Text;

            context.TableCars.Add(newCar);
            context.SaveChanges();
            this.Close();
        }
    }
}
