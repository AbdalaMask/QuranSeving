using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuranSeving.DB
{
    public partial class Frm_db_User : KryptonForm
    {
        public DataSet ds = new DataSet();
        public DataSet ds1 = new DataSet();
        public DataTable ds2 = new DataTable();
        public BindingSource BS = new BindingSource();
        public string[] c2 = { "سورة الفاتحة", "سورة البقرة", "سورة ال عمران", "سورة النساء", "سورة المائدة", "سورة الانعام", "سورة الاعراف", "سورة الانفال", "سورة التوبة", "سورة يونس", "سورة هود", "سورة يوسف", "سورة الرعد", "سورة ابراهيم", "سورة الحجر", "سورة النحل", "سورة الاسراء", "سورة الكهف", "سورة مريم", "سورة طه", "سورة الانبياء", "سورة الحج", "سورة المؤمنون", "سورة النور", "سورة الفرقان", "سورة الشعراء", "سورة النمل", "سورة القصص", "سورة العنكبوت", "سورة الروم", "سورة لقمان", "سورة السجدة", "سورة الاحزاب", "سورة سبا", "سورة فاطر", "سورة يس", "سورة الصافات", "سورة ص", "سورة الزمر", "سورة غافر", "سورة فصلت", "سورة الشورى", "سورة الزخرف", "سورة الدخان", "سورة الجاثية", "سورة الاحقاف", "سورة محمد", "سورة الفتح", "سورة الحجرات", "سورة ق", "سورة الزاريات", "سورة الطور", "سورة النجم", "سورة القمر", "سورة الرحمن", "سورة الواقعة", "سورة الحديد", "سورة المجادلة", "سورة الحشر", "سورة الممتحنة", "سورة الصف", "سورة الجمعة", "سورة المنافقون", "سورة التغابن", "سورةالطلاق", "سورة التحريم", "سورة الملك", "سورة القلم", "سورة الحاقة", "سورة المعارج", "سورة نوح", "سورة الجن", "سورة المزمل", "سورة المدثر", "سورة القيامة", "سورة الانسان", "سورة المرسلات", "سورة النبا", "سورة النازعات", "سورة عبس", "سورة التكوير", "سورة الانفطار ", "سورة المطففين", "سورة الانشقاق", "سورة البروج ", "سورة الطارق", "سورة الاعلى", "سورة الغاشية", "سورة الفجر", "سورة البلد", "سورة الشمس", "سورة الليل", "سورة الضحى", "سورةالشرح", "سورةالتين", "سورة العلق", "سورة القدر", "سورة البينة", "سورةالزلزلة", "سورة العاديات", "سورة القارعة", "سورة التكاثر", "سورة العصر", "سورة الهمزة", "سورة الفيل", "سورة قريش", "سورة الماعون", "سورة الكوثر", "سورة الكافرون", "سورة النصر", "سورة المسد", "سورة الاخلاص", "سورة الفلق", "سورة الناس" };
        public string[] c7 = { "السبت", "الاحد", "الاثنين", "الثلاثاء", "الاربعاء", "الخميس", "الجمعة" };
        public string[] c8 = { "السورة كاملة", "ايات", "صفحات", "ارباع" };
        string sqlLiteFileName = string.Empty;
        public Frm_db_User()
        {
            InitializeComponent();
        }

        private void Frm_db_User_Load(object sender, EventArgs e)
        {
            com_sname.Items.AddRange(c2);
            com_dey1.Items.AddRange(c7);
            com_hkeep.Items.AddRange(c8);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_date.Text = DateTime.Now.ToShortDateString();
            txt_tim.Text = DateTime.Now.ToShortTimeString();
            //  tsStatus.Text = Microsoft.VisualBasic.Right(tsStatus.Text, 1) & Microsoft.VisualBasic.Left(tsStatus.Text, tsStatus.Text.Length - 1);

            tsStatus.Left = tsStatus.Left + 10;
            if (tsStatus.Left > this.Width)
            {
                tsStatus.Left = 0 - tsStatus.Width;
            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (sqlLiteFileName == "")
            {
                MessageBox.Show("من فضلك ادخل اسم قاعدة البيانات", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sqlLiteFileName = string.Format("{0}.sqlite", txt_open_db.Text);


            string ConString3 = "Data Source =" + Application.StartupPath + string.Format("\\DatabaseUserSevaing\\{0}", sqlLiteFileName);
            SQLiteConnection conn3 = new SQLiteConnection(ConString3);
            if (conn3.State == System.Data.ConnectionState.Open)
                conn3.Close();
            string SQL3str = "SELECT * FROM quran";

            using (SQLiteCommand cmd = new SQLiteCommand(conn3))
            {
                conn3.Open();
                cmd.CommandText = SQL3str;
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            string output = reader["nday"].ToString();

                            com_dey1.Items.Add(output);
                        }
                    }
                }
            }

            MessageBox.Show("تم الاتصال بقاعدة البيانات", "رسالة تاكيد");
            conn3.Close();

        }

        private void btn_seva_db_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(com_sname.Text))
            {
                MessageBox.Show("يجب اختيار السورة", "تنبية");
                return;
            }
            if (string.IsNullOrEmpty(com_hkeep.Text))
            {
                MessageBox.Show("يجب اختيار طريقة حفظك", "تنبية");
                return;
            }
            if (string.IsNullOrEmpty(txt_dey.Text))
            {
                MessageBox.Show("يجب ادخال اليوم", "تنبية");
                return;

            }
            if (string.IsNullOrEmpty(com_dey1.Text))
            {
                MessageBox.Show("يجب اختيار اليوم", "تنبية");
                return;
            }
            if (string.IsNullOrEmpty(txt_dc.Text))
            {
                DialogResult d = MessageBox.Show("هل تريد الحفظ بدون كتابة اى ملاحظات", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {

                }
                return;
            }
            string ConString3 = "Data Source =" + Application.StartupPath + string.Format("\\DatabaseUserSevaing\\{0}", sqlLiteFileName);
            SQLiteConnection conn3 = new SQLiteConnection(ConString3);

            string SQL3str = "SELECT * FROM quran where nday = @nday";
            if (conn3.State == System.Data.ConnectionState.Open)
            {
                conn3.Close();
            }
            else
            {
                conn3.Open();
            }


            SQLiteDataAdapter adp = new SQLiteDataAdapter(SQL3str, conn3);
            adp.SelectCommand.Parameters.AddWithValue("@nday", txt_dey.Text);
            adp.Fill(ds, "quran");

            conn3.Close();
            //seva
            SQL3str = "insert into quran (sname,hkeep,mayat,paamount,ropamount,nday,rdate,Nwday,RTime,Hput,ayafrm,ayato,papfrm,papto,ropfrm,ropto)VALUES(@sname,@hkeep,@mayat,@paamount,@ropamount,@nday,@rdate,@Nwday,@RTime,@Hput,@ayafrm,@ayato,@papfrm,@papto,@ropfrm,@ropto)";
            SQLiteCommand cmd = new SQLiteCommand(SQL3str, conn3);
            cmd.Parameters.AddWithValue("@sname", com_sname.Text);
            cmd.Parameters.AddWithValue("@hkeep", com_hkeep.Text);
            cmd.Parameters.AddWithValue("@mayat", txt_num_ayet.Text);
            cmd.Parameters.AddWithValue("@paamount", txt_num_Page.Text);
            cmd.Parameters.AddWithValue("@ropamount", txt_num_R.Text);
            cmd.Parameters.AddWithValue("@nday", txt_dey.Text);
            cmd.Parameters.AddWithValue("@rdate", txt_date.Text);
            cmd.Parameters.AddWithValue("@Nwday", com_dey1.Text);
            cmd.Parameters.AddWithValue("@RTime", txt_tim.Text);
            cmd.Parameters.AddWithValue("@Hput", txt_dc.Text);
            cmd.Parameters.AddWithValue("@ayafrm", txt_num_M.Text);
            cmd.Parameters.AddWithValue("@ayato", txt_num_l.Text);
            cmd.Parameters.AddWithValue("@papfrm", txt_num_mp.Text);
            cmd.Parameters.AddWithValue("@papto", txt_num_lp.Text);
            cmd.Parameters.AddWithValue("@ropfrm", txt_mr.Text);
            cmd.Parameters.AddWithValue("@ropto", txt_ml.Text);
            conn3.Open();
            cmd.ExecuteNonQuery();
            conn3.Close();

        }



        public void filltext() //حدث ملئ مربعات النصوص في التاب الأول والثاني
        {
            try
            {



                //txthkeep.Text = ds1.Tables["quran"].Rows[BS.Position]["hkeep"].ToString();
                //txtsname.Text = ds1.Tables["quran"].Rows[BS.Position]["sname"].ToString();
                //txtmayat.Text = ds1.Tables["quran"].Rows[BS.Position]["mayat"].ToString();
                //txtayafrm.Text = ds1.Tables["quran"].Rows[BS.Position]["ayafrm"].ToString();
                //txtayato.Text = ds1.Tables["quran"].Rows[BS.Position]["ayato"].ToString();
                //txtpaamount.Text = ds1.Tables["quran"].Rows[BS.Position]["paamount"].ToString();
                //txtpapfrm.Text = ds1.Tables["quran"].Rows[BS.Position]["papfrm"].ToString();
                //txtpapto.Text = ds1.Tables["quran"].Rows[BS.Position]["papto"].ToString();
                //txtropamount.Text = ds1.Tables["quran"].Rows[BS.Position]["ropamount"].ToString();
                //txtropfrm.Text = ds1.Tables["quran"].Rows[BS.Position]["ropfrm"].ToString();
                //txtropto.Text = ds1.Tables["quran"].Rows[BS.Position]["ropto"].ToString();
                //txtnwday.Text = ds1.Tables["quran"].Rows[BS.Position]["nwday"].ToString();
                //txtrdate.Text = ds1.Tables["quran"].Rows[BS.Position]["rdate"].ToString();
                //txtrtime.Text = ds1.Tables["quran"].Rows[BS.Position]["rtime"].ToString();
                //txthput.Text = ds1.Tables["quran"].Rows[BS.Position]["hput"].ToString();



            }
            catch (Exception ex)
            {

            }
        }
        public void filllistbox()
        {
            string ConString4 = "Data Source =" + Application.StartupPath + string.Format("\\DatabaseUserSevaing\\{0}", sqlLiteFileName);
            SQLiteConnection conn4 = new SQLiteConnection(ConString4);
            //فتح الأتصال
            conn4.Open();
            //عبارة أستعلام وهي أختيار البيانات عندما تتساوى قيمة الكمبوبكس مع عمود القسم
            string str = "SELECT * FROM quran where nday = '" + com_dey1.Text + "'";
            //تعريف كائن وفق الأستعلام والأتصال
            SQLiteDataAdapter adp1 = new SQLiteDataAdapter(str, conn4);
            //تفريغ الداتا ست
            ds.Clear();
            //ملئ الدتا ست بالبيانات
            adp1.Fill(ds1, "quran");
            //سحب البينات من الدتا ست
            BS.DataSource = ds1;
            BS.DataMember = "quran";
            //ملئ الليست بوكس بالجدول المراد

            adp1.Dispose();
            //أغلاق الأتصال
            conn4.Close();
        }

        private void com_hkeep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_hkeep.Text == c8[1])
            {
                txt_num_ayet.Enabled = true;
                txt_num_l.Enabled = true;
                txt_num_M.Enabled = true;
                txt_num_ayet.BackColor = Color.Yellow;
                txt_num_l.BackColor = Color.Yellow;
                txt_num_M.BackColor = Color.Yellow;
                //=============================================================
                txt_num_Page.Enabled = false;
                txt_num_lp.Enabled = false;
                txt_num_mp.Enabled = false;
                //================================================================
                txt_num_R.Enabled = false;
                txt_ml.Enabled = false;
                txt_mr.Enabled = false;
            }

            else if (com_hkeep.Text == c8[2])
            {
                txt_num_ayet.Enabled = false;
                txt_num_l.Enabled = false;
                txt_num_M.Enabled = false;
                //=============================================================
                txt_num_Page.Enabled = true;
                txt_num_lp.Enabled = true;
                txt_num_mp.Enabled = true;
                //================================================================
                txt_num_R.Enabled = false;
                txt_ml.Enabled = false;
                txt_mr.Enabled = false;
            }

            else if (com_hkeep.Text == c8[3])
            {
                txt_num_ayet.Enabled = false;
                txt_num_l.Enabled = false;
                txt_num_M.Enabled = false;
                //=============================================================
                txt_num_Page.Enabled = false;
                txt_num_lp.Enabled = false;
                txt_num_mp.Enabled = false;
                //================================================================
                txt_num_R.Enabled = true;
                txt_ml.Enabled = true;
                txt_mr.Enabled = true;
            }

            else if (com_hkeep.Text == c8[0])
            {
                txt_num_ayet.Enabled = false;
                txt_num_l.Enabled = false;
                txt_num_M.Enabled = false;
                //=============================================================
                txt_num_Page.Enabled = false;
                txt_num_lp.Enabled = false;
                txt_num_mp.Enabled = false;
                //================================================================
                txt_num_R.Enabled = false;
                txt_ml.Enabled = false;
                txt_mr.Enabled = false;
            }
        }

        private void com_dey1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filllistbox();
            filltext();
        }
    }
}
