

using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Environment = System.Environment;

namespace data
{
    class tabledatabase
    {

        public static string DBname = "SQLite.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBname);

        SQLiteConnection sqliteConnection;

        public tabledatabase()
        {
            try
            {
                Console.WriteLine(DBPath);
                sqliteConnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Succefully Database Created!....");



            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }
        }

        public void dataTable()
        {
            try
            {
                var created = sqliteConnection.CreateTable<datatable>();
                Console.WriteLine("Succefully Table Created!....");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }

        }

        public bool InstertData(datatable task)
        {
           long result = sqliteConnection.Insert(task);
            if (result == -1)
            { 
                return false;
            }
            else
            {
                Console.WriteLine("Succefully Inserted Data ");
                return true;
            }
        }
        public datatable GetByUserId(int studentId)
        {
            var userId = sqliteConnection.Table<datatable>().Where(u => u.Id == studentId).FirstOrDefault();

            return userId;

        }
        public List<datatable> ReadTask()
        {
            try
            {
                var taskdata = sqliteConnection.Table<datatable>().ToList();
                return taskdata;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                return null;
            }


        }

        public bool DeleteStudents(datatable data)
        {


            long result = sqliteConnection.Delete(data);
            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Deleted Data ");
                return true;
            }


        }







    }
}
