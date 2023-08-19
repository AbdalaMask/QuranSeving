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
using QuranLibrary.Sql;
using System.Text.RegularExpressions;

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
        private  QuranSevingSql database;
        private void Frm_db_User_Load(object sender, EventArgs e)
        {
            database = new QuranSevingSql();
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
   
        private async void btn_Open_Click(object sender, EventArgs e)
        {
            if (sqlLiteFileName == "")
            {
                MessageBox.Show("من فضلك ادخل اسم قاعدة البيانات", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sqlLiteFileName = string.Format("{0}.db", txt_open_db.Text);


            string ConString3 =  Application.StartupPath + string.Format("\\DatabaseUserSevaing\\{0}", sqlLiteFileName);


            using (var db = await database.TryCreateDatabase(ConString3))
            {
                
                var nday = db.Table<DatabaseUserSevaing>().Select(s => s.nday).ToList();

                foreach (var item in nday)
                {
                    com_dey1.Items.Add(item);
                }
                

            }

            

            MessageBox.Show("تم الاتصال بقاعدة البيانات", "رسالة تاكيد");
            

        }

        private async void btn_seva_db_Click(object sender, EventArgs e)
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
            string ConString3 =  Application.StartupPath + string.Format("\\DatabaseUserSevaing\\{0}", sqlLiteFileName);
          

            using (var db = await database.TryCreateDatabase(ConString3))
            {

                var nday = db.Table<DatabaseUserSevaing>().Where(s => s.nday == txt_dey.Text).ToList();

                db.Insert(new DatabaseUserSevaing
                {
                    Sname = com_sname.Text,
                    Hkeep = com_hkeep.Text,
                    mayat = txt_num_ayet.Text,
                    paamount = txt_num_Page.Text,
                    ropamount = txt_num_R.Text,
                    nday = txt_dey.Text,
                    RDate = txt_date.Text,
                    Nwday = com_dey1.Text,
                    RTime = txt_tim.Text,
                    Hput = txt_dc.Text,
                    ayafrm = txt_num_M.Text,
                    ayato = txt_num_l.Text,
                    papfrm = txt_num_mp.Text,
                    papto = txt_num_lp.Text,
                    ropfrm = txt_mr.Text,
                    ropto = txt_ml.Text,

                }, typeof(DatabaseUserSevaing));


            }


           
          
        }



        public async void filltext() //حدث ملئ مربعات النصوص في التاب الأول والثاني
        {
            try
            {
                string ConString3 = Application.StartupPath + string.Format("\\DatabaseUserSevaing\\{0}", sqlLiteFileName);

                using (var db = await database.TryCreateDatabase(ConString3))
                {

                    var nday = db.Table<DatabaseUserSevaing>().Where(s => s.nday == txt_dey.Text).ToList();

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






            }
            catch (Exception ex)
            {

            }
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
           
            filltext();
        }
    }
}
