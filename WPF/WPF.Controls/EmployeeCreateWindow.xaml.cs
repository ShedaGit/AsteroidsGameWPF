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
using WPF.Communication.WpfService;

namespace WPF.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeCreateWindow.xaml
    /// </summary>
    public partial class EmployeeCreateWindow : Window
    {
        public EmployeeCreateWindow()
        {
            InitializeComponent();

            employeeControl.Employee = Employee;
        }

        public Employee Employee { get; set; } = new Employee();

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
