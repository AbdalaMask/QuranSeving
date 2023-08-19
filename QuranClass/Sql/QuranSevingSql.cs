using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuranLibrary.Sql
{
    public class QuranSevingSql
    {
        public QuranSevingSql()
        {
           // InitializeDatabase();
        }
        private async void InitializeDatabase()
        {


            await TryCreateDatabase("");
        }
        #region الحقول العامة
        public SQLiteConnection con;

        public SQLiteCommand comm;
        #endregion الحقول العامة

      

        public async Task<SQLiteConnection> TryCreateDatabase(string DatabaseName)
        {


            
            try
            {

                
                if (File.Exists(DatabaseName))
                {
                    con = new SQLiteConnection(DatabaseName);
                }
                else
                {
                }
            }
            catch (System.Exception ex)
            {

            }
            return con;
        }


        public async Task<List<DatabaseUserSevaing>> GET_ALL_nday(string DatabaseName)
        {
            try
            {
                using (var db = await TryCreateDatabase(DatabaseName))
                {
                    return db.Table<DatabaseUserSevaing>().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;

        }
    }

    [Table("de")]
    public class SevaUser
    {
        [PrimaryKey, AutoIncrement, NotNullAttribute]
        public int ID { get; set; }
        [NotNullAttribute]
        public string pass { get; set; }
        public string ppass { get; set; }
        public string mname { get; set; }
        public string hkeep { get; set; }
        public string hapday { get; set; }
        public string timerec { get; set; }
        public string dayrec { get; set; }
        public string morec { get; set; }
        public string yearrec { get; set; }
      



    }

    [Table("quran")]
    public class DatabaseUserSevaing
    {
        [PrimaryKey, AutoIncrement, NotNullAttribute]
        public int ID { get; set; }
        [NotNullAttribute]
        public string Sname { get; set; }
        public string Hkeep { get; set; }
        public string mayat { get; set; }
        public string paamount { get; set; }
        public string ropamount { get; set; }
        public string nday { get; set; }
        public string RDate { get; set; }
        public string Nwday { get; set; }
        public string RTime { get; set; }

        public string Hput { get; set; }
        public string ayafrm { get; set; }
        public string ayato { get; set; }
        public string papfrm { get; set; }
        public string papto { get; set; }

        public string ropfrm { get; set; }
        public string ropto { get; set; }


    }
}
  