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
using Windows.UI.Popups;
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

            if (DB_EmployeeList.Count > 0)
            {
                Btn_Delete.IsEnabled = true;
            }
            //bind db record to list box and display the latest record
            //(new records weill be put at the end... so by ordering by desending we get the latest record first)
            listBoxobj.ItemsSource = DB_EmployeeList.OrderByDescending(i => i.employeeId).ToList();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            //navigate to the AddEmployees page when this button is clicked
            Frame.Navigate(typeof(AddEmployee));
        }

        private async void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            //ask the user if they are sure using dialog boxes
            //use async and await as dialogue boxs take a while to load
            var dialog = new MessageDialog("Are you sure you want to remove all your data ?");
            dialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(Command)));
            dialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(Command)));
            await dialog.ShowAsync();
        }
        private void Command(IUICommand command)
        {
            //if they answered yes
            if (command.Label.Equals("Yes"))
            {
                DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
                //delete all employees from the databse
                Db_Helper.DeleteAllEmployees();
                //clear the view so the user knows the employees were deleted
                DB_EmployeeList.Clear();
                //did=sabel the delete buton as there are not employees to delete
                Btn_Delete.IsEnabled = false;
                //set the listbox equal to the empty list
                listBoxobj.ItemsSource = DB_EmployeeList;
            }
        }

        private void listBoxobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedEmployeeID = 0;
            //make sure that an item is selected
            if (listBoxobj.SelectedIndex != -1)
            {
                //get the selected listbox items employeeId
                Employees listitem = listBoxobj.SelectedItem as Employees;
                //show the delete update page with the selected employeeID
                Frame.Navigate(typeof(DeleteUpdateEmployees), SelectedEmployeeID = listitem.employeeId);

            }
        }

        //provides the user with an alternative way to add and delete

        private void AddEmp_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddEmployee));
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            //ask the user if they are sure using dialog boxes
            //use async and await as dialogue boxs take a while to load
            var dialog = new MessageDialog("Are you sure you want to remove all your data ?");
            dialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(Command)));
            dialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(Command)));
            await dialog.ShowAsync();
        }
    }
}
