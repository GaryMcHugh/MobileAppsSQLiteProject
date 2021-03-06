﻿using EmployersSQLiteProject.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployersSQLiteProject.Helpers
{
    public class DatabaseHelperClass
    {
        SQLiteConnection dbConn;

        //Create Table 
        public async Task<bool> onCreate(string DB_PATH)
        {
            //have to use async and await as the task runs for a while
            try
            {
                //Create the table if it doesn't exist(happens when CheckFileExists returns false)
                if (!CheckFileExists(DB_PATH).Result)
                {
                    //create a new connection to the db at the path specified in app.cs
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        //create the table from the employees.cs in the model
                        dbConn.CreateTable<Employees>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        } //onCreate

        //check if the file exists(for the database)
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                //return false if the file doesnt exist, so we can create the table (above and in dbHelper)
                return false;
            }
        }
        
        //get one employee when its selected

        //get back the employee that has been selected from the db
        //pass the method the employee id that the suer wants
        public Employees ReadEmployee(int employeeId)
        {
            //get a connection to the database
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //execute the select statement on the employee table where the id is equal to the empId selected
                var existingEmployee = dbConn.Query<Employees>("select * from Employees where employeeId =" + employeeId).FirstOrDefault();
                return existingEmployee;
                //reurn the employee that was returned
            }
        }

        //retrieve all employees to be displayed in a list

        //pass the method an observable colelction of employees
        public ObservableCollection<Employees> ReadEmployees()
        {
            //get a connection to the database
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //create a list of employees from the data in the table
                List<Employees> myCollection = dbConn.Table<Employees>().ToList<Employees>();
                //make an observable collection out of the list
                ObservableCollection<Employees> EmployeesList = new ObservableCollection<Employees>(myCollection);
                //return the observable collection
                return EmployeesList;
            }
        }

        //pass the method a new employee from the model
        public void Insert(Employees newEmployee)
        {
            //get a connexction to the database
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //use the SQLite insert method to add a new employee to the table
                 dbConn.Insert(newEmployee);
            }
        }

        //same as read except check for not being null
        public void DeleteEmployee(int employeeId)
        {
            //get connection
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //execute the select statement on the employee table where the id is equal to the empId selected
                var existingEmployee = dbConn.Query<Employees>("select * from Employees where employeeId =" + employeeId).FirstOrDefault();

                //check that the record is not null
                if (existingEmployee != null)
                {
                    //use the SQLite method to delete the employee
                    dbConn.Delete(existingEmployee);
                }
            }
        }

        //combination of insert and read method
        public void UpdateEmployee(Employees employee)
        {
            //get a conenction to the db
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //execute the select statement on the employee table where the id is equal to the empId selected
                var existingEmployee = dbConn.Query<Employees>("select * from Employees where employeeId =" + employee.employeeId).FirstOrDefault();
                //if the record is not empty
                if (existingEmployee != null)
                {
                    //set the new values entered to the variables in the model
                    existingEmployee.empName = employee.empName;
                    existingEmployee.empAge = employee.empAge;
                    existingEmployee.empPhoneNumber = employee.empPhoneNumber;
                    existingEmployee.empEmail = employee.empEmail;
                    existingEmployee.empSalary = employee.empSalary;
                    existingEmployee.CreationDate = employee.CreationDate;

                    //use the SQLite update method to update the record
                    dbConn.Update(existingEmployee);
                }
            }
        }

        //remove all records
        public void DeleteAllEmployees()
        {
            //get a connection
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //drop the table
                dbConn.DropTable<Employees>();
                //create a new one so that the user can add more employees
                dbConn.CreateTable<Employees>();

                //drop the connection
                dbConn.Dispose();
                //clsoe the connection
                dbConn.Close();
            }
        }

    } //DatabaseHelperClass
}
