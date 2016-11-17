using EmployersSQLiteProject.Model;
using SQLite;
using System;
using System.Collections.Generic;
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
 
        public Employees ReadEmployee(int empId)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingEmployee = dbConn.Query<Employees>("select * from Employees where Id =" + empId).FirstOrDefault();
                return existingEmployee;
            }
        }
    } //DatabaseHelperClass
}
