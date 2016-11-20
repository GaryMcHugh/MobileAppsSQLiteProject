using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployersSQLiteProject.Model
{
    public class Employees
    {
        //The Id property is marked as the Primary Key
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int employeeId { get; set; }

        //get and set for Specific employee details
        public string empName { get; set; }
        public string empAge { get; set; }
        public string empPhoneNumber { get; set; }
        public string empEmail { get; set; }
        public string empSalary { get; set; }
        //to show when the record was made
        public string CreationDate { get; set; }

        //empty constructor
        public Employees()
        {
            
        }

        //constructor to initialise the employee details
        public Employees(string name, string age, string phone_no, string email, string salary)
        {
            //initialise the variables
            empName = name;
            empAge = age;
            empPhoneNumber = phone_no;
            empEmail = email;
            empSalary = salary;

            //set the currentDate to the current time (when the value was created)
            CreationDate = DateTime.Now.ToString();
        }
    }
}
