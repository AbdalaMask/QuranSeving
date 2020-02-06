using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace QuranSeving
{
    public partial class Frm_SevaUser : KryptonForm
    {
        public string ConString1 = "Data Source =" + Application.StartupPath + "\\DatabaseUser\\DatabaseUser.db3";
        public SQLiteConnection conn;
        public Frm_SevaUser()
        {
            InitializeComponent();
        }
        //' دالة ملء خانات الوقت فى المشروع
        public void tim_data(ref TextBox txt_timerec, ref TextBox txt_dayrec, ref TextBox txt_morec, ref TextBox txt_yearrec)
        {
            txt_timerec.Text = DateTime.Today.ToShortTimeString();
            txt_dayrec.Text = DateTime.Today.ToShortDateString();
            txt_morec.Text = DateTime.Today.Month.ToString();
            txt_yearrec.Text = DateTime.Today.Year.ToString();
        }
        private void btn_seva_Click(object sender, EventArgs e)
        {
            if (txt_mname.Text == string.Empty || txt_pass.Text == string.Empty || txt_ppass.Text == string.Empty || com_hkeep.Text == string.Empty || txt_hapday.Text == string.Empty)
            {
                MessageBox.Show("يجب ملاء جميع الخانات", "إعلام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            conn = new SQLiteConnection(ConString1);
            SQLiteCommand cmd = new SQLiteCommand("insert into de (mname,pass,ppass,hkeep,hapday,timerec,dayrec,morec,yearrec)values(@mname,@pass,@ppass,@hkeep,@hapday,@timerec,@dayrec,@morec,@yearrec)", conn);
            cmd.Parameters.AddWithValue("@mname", txt_mname.Text);
            cmd.Parameters.AddWithValue("@pass", txt_pass.Text);
            cmd.Parameters.AddWithValue("@ppass", txt_ppass.Text);
            cmd.Parameters.AddWithValue("@hkeep", com_hkeep.Text);
            cmd.Parameters.AddWithValue("@hapday", txt_hapday.Text);
            cmd.Parameters.AddWithValue("@timerec", txt_timerec.Text);
            cmd.Parameters.AddWithValue("@dayrec", txt_dayrec.Text);
            cmd.Parameters.AddWithValue("@morec", txt_morec.Text);
            cmd.Parameters.AddWithValue("@yearrec", txt_yearrec.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("تم الحفظ", "إعلام", MessageBoxButtons.OK);
        }

        private void Frm_SevaUser_Load(object sender, EventArgs e)
        {
            com_hkeep.Items.Add("ولا جزء");
            com_hkeep.Items.Add("جزء");
            com_hkeep.Items.Add("جزئين");
            com_hkeep.Items.Add("3 اجزاء");
            com_hkeep.Items.Add("4 اجزاء");
            com_hkeep.Items.Add("5 اجزاء");
            com_hkeep.Items.Add("6 اجزاء");
            com_hkeep.Items.Add("7 اجزاء");
            com_hkeep.Items.Add("8 اجزاء");
            com_hkeep.Items.Add("9 اجزاء");
            com_hkeep.Items.Add("10 اجزاء");
            com_hkeep.Items.Add("11 جزء");
            com_hkeep.Items.Add("12 جزء");
            com_hkeep.Items.Add("13 جزء");
            com_hkeep.Items.Add("14 جزء");
            com_hkeep.Items.Add("15 جزء");
            com_hkeep.Items.Add("16 جزء");
            com_hkeep.Items.Add("17 جزء");
            com_hkeep.Items.Add("18 جزء");
            com_hkeep.Items.Add("19 جزء");
            com_hkeep.Items.Add("20 جزء");
            com_hkeep.Items.Add("21 جزء");
            com_hkeep.Items.Add("22 جزء");
            com_hkeep.Items.Add("23 جزء");
            com_hkeep.Items.Add("24 جزء");
            com_hkeep.Items.Add("25 جزء");
            com_hkeep.Items.Add("26 جزء");
            com_hkeep.Items.Add("27 جزء");
            com_hkeep.Items.Add("28 جزء");
            com_hkeep.Items.Add("29 جزء");


            txt_timerec.Text = DateTime.Today.ToShortTimeString();
            txt_dayrec.Text = DateTime.Today.ToShortDateString();
            txt_morec.Text = DateTime.Today.Month.ToString();
            txt_yearrec.Text = DateTime.Today.Year.ToString();
        }
    }
}
