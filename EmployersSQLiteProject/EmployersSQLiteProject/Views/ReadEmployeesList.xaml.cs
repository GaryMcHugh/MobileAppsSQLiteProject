using EmployersSQLiteProject.Helpers;
using EmployersSQLiteProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EmployersSQLiteProject.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReadEmployeesList : Page
    {
        ObservableCollection<Employees> DB_EmployeeList = new ObservableCollection<Employees>();

        public ReadEmployeesList()
        {
            this.InitializeComponent();
            this.Loaded += ReadEmployeesList_Loaded;
        }

        private void ReadEmployeesList_Loaded(object sender, RoutedEventArgs e)
        {
            ReadAllEmployeesList dbEmployees = new ReadAllEmployeesList();
            DB_EmployeeList = dbEmployees.GetAllEmployees();
            listBoxobj.ItemsSource = DB_EmployeeList.OrderByDescending(i => i.employeeId).ToList();
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddEmployee));
        }
    }
}
