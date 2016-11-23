using EmployersSQLiteProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployersSQLiteProject.Helpers
{
    public class ReadAllEmployeesList
    {
        //create an instance of the dbhelper class
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();

        //get all employees method
        //pass it an observable coleection
        public ObservableCollection<Employees> GetAllEmployees()
        {
            //use read employees method in dbhelper class
            return Db_Helper.ReadEmployees();
        }
    }
}
