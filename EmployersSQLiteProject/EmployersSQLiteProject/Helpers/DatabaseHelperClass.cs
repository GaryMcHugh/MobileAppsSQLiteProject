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
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
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
    } //DatabaseHelperClass
}
