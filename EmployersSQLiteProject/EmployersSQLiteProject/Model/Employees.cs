using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployersSQLiteProject.Model
{
    public class Employees
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int employeeId { get; set; }
        public string empName { get; set; }
        public int empAge { get; set; }
        public string empPhoneNumber { get; set; }
        public string empEmail { get; set; }
        public decimal empSalary { get; set; }
        public string CreationDate { get; set; }

        public Employees()
        {
        }
        public Employees(string name, int age, string phone_no, string email, decimal salary)
        {
            empName = name;
            empAge = age;
            empPhoneNumber = phone_no;
            empEmail = email;
            empSalary = salary;
            CreationDate = DateTime.Now.ToString();
        }
    }
}
