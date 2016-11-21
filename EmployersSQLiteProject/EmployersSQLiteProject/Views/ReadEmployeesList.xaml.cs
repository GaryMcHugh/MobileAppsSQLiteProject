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
        //create an observable collection to take the list and display it
        ObservableCollection<Employees> DB_EmployeeList = new ObservableCollection<Employees>();

        public ReadEmployeesList()
        {
            this.InitializeComponent();
            //start the load method when this class is initialised
            this.Loaded += ReadEmployeesList_Loaded;
        }

        private void ReadEmployeesList_Loaded(object sender, RoutedEventArgs e)
        {
            //create a list to get the meployees from the db
            ReadAllEmployeesList dbEmployees = new ReadAllEmployeesList();
            //get all employees using the list and put them in the observable collection
            DB_EmployeeList = dbEmployees.GetAllEmployees();
            //bind db record to list box and display the latest record
            //(new records weill be put at the end... so by ordering by desending we get the latest record first)
            listBoxobj.ItemsSource = DB_EmployeeList.OrderByDescending(i => i.employeeId).ToList();
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddEmployee));
        }
    }
}
