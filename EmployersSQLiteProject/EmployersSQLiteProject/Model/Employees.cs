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
        public int empAge { get; set; }
        public string empPhoneNumber { get; set; }
        public string empEmail { get; set; }
        public decimal empSalary { get; set; }
        //to show when the record was made
        public string CreationDate { get; set; }

        //empty constructor
        public Employees()
        {
            
        }

        //constructor to initialise the employee details
        public Employees(string name, int age, string phone_no, string email, decimal salary)
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
