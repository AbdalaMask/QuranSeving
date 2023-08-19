using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuranSeving.DB
{
    public partial class FrmCreateDatabase : KryptonForm
    {
        public FrmCreateDatabase()
        {
            InitializeComponent();
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            string sqlLiteFileName = string.Format("{0}.sqlite", txtCreateDatabase.Text);
            string ConString1 = Application.StartupPath + string.Format("\\DatabaseUserSevaing\\{0}", sqlLiteFileName);
            string createQuery = @"CREATE TABLE IF NOT EXISTS quran(Sname TEXT (15) ,Hkeep TEXT (30),mayat TEXT (30),paamount TEXT (9),ropamount TEXT(15),nday  TEXT (20),RDate date ,Nwday TEXT (10),RTime TEXT (15),Hput memo,ayafrm TEXT (10),ayato TEXT (10),papfrm TEXT (10),papto TEXT (10),ropfrm TEXT (10),ropto TEXT (10))";
            //                   @"CREATE TABLE IF NOT EXISTS
            //                    [Mytable] (
            //                    [Id]     INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            //                    [NAME]   NVARCHAR(2048) NULL,
            //                    [GENDER] NVARCHAR(2048) NULL)";
            try
            {
                //SQLiteConnection.CreateFile(ConString1);


                //using (SQLiteConnection conn = new SQLiteConnection("data source =" + ConString1))
                //{
                //    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                //    {
                //        conn.Open();
                //        cmd.CommandText = createQuery;
                //        cmd.ExecuteNonQuery();


                //    }

                //}
                MessageBox.Show("تم إنشاء قاعدة البيانات", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FrmCreateDatabase_Load(object sender, EventArgs e)
        {

        }
    }
}
