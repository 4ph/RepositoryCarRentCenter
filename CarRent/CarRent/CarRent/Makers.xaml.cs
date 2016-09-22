﻿using System;
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
    /// Interaction logic for Makers.xaml
    /// </summary>
    public partial class Makers : Window
    {
        public Makers()
        {
            InitializeComponent();
            this.DataGridMakers.ItemsSource = new CarRentalCenterDBEntities().TableMakers.ToArray();
        }
    }
}
