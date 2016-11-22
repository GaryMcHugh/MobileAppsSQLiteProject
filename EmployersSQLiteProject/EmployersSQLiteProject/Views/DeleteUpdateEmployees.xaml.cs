using EmployersSQLiteProject.Helpers;
using EmployersSQLiteProject.Model;
using System;
using System.Collections.Generic;
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
    public sealed partial class DeleteUpdateEmployees : Page
    {
        int Selected_EmployeeId = 0;
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        Employees currentEmployee = new Employees();

        public DeleteUpdateEmployees()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //get the selected employee Id so it can be used to load other fields
            Selected_EmployeeId = int.Parse(e.Parameter.ToString());
            //call the readEmployee method on the selected employee
            currentEmployee = Db_Helper.ReadEmployee(Selected_EmployeeId);

            //set the textbox's to the values retrieved from ReadEmployee
            NametxtBx.Text = currentEmployee.empName;
            AgetxtBx.Text = currentEmployee.empAge;
            PhoneNumbertxtBx.Text = currentEmployee.empPhoneNumber;
            EmailtxtBx.Text = currentEmployee.empEmail;
            SalarytxtBx.Text = currentEmployee.empSalary;
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
