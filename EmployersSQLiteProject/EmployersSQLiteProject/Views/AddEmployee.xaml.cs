using EmployersSQLiteProject.Helpers;
using EmployersSQLiteProject.Model;
using System;
using System.Collections.Generic;
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
    public sealed partial class AddEmployee : Page
    {
        public AddEmployee()
        {
            this.InitializeComponent();
        }

        private async void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
            if (NametxtBx.Text != "" & AgetxtBx.Text != "" & PhoneNumbertxtBx.Text != "" & EmailtxtBx.Text != "" & SalarytxtBx.Text != "")
            {
                Db_Helper.Insert(new Employees(NametxtBx.Text, AgetxtBx.Text, PhoneNumbertxtBx.Text, EmailtxtBx.Text, SalarytxtBx.Text));
                Frame.Navigate(typeof(ReadEmployeesList));
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Please fill in all fields"); 
                await messageDialog.ShowAsync();
            }
        }
    }
}
