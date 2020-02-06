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

namespace QuranSeving.Mushaf
{
    public partial class Frm_Kep : KryptonForm
    {
        string[] c1 = { "سورة البقرة ", "سورة ال عمران", "سورة النساء", "سورة الانعام", "سورة الاعراف", "سورة الانفال", "سورة التوبة", "سورة يونس", "سورة هود", "سورة يوسف", "سورة الرعد", "سورة الحجر", "سورة النحل", "سورة الاسراء", "سورة الكهف", "سورة مريم", "سورة طه", "سورة الانبياء", "سورة الحج", "سورة المؤمنون", "سورة النور", "سورة النمل", "سورة القصص", "سورة الاحزاب", "سورة ص", "سورة الزمر", "سورة غافر", "سورة فصلت", "سورة الطور", "سورة المجادلة" };
        string[] c2 = { "سورة البقرة ", "سورة ال عمران", "سورة النساء", "سورة الانعام", "سورة الاعراف", "سورة الانفال", "سورة التوبة", "سورة يونس", "سورة هود", "سورة يوسف", "سورة الرعد", "سورة الحجر", "سورة النحل", "سورة الاسراء", "سورة الكهف", "سورة مريم", "سورة طه", "سورة الانبياء", "سورة الحج", "سورة الشعراء", "سورة الصافات", "سورة الزمر", "سورة غافر", "سورة الواقة", "سورة الحديد", "سورة الحشر", "سورة نوح" };
        string[] c3 = { "سورة البقرة ", "سورة ال عمران", "سورة النساء", "سورة الانعام", "سورة الاعراف", "سورة الانفال", "سورة التوبة", "سورة يونس", "سورة هود", "سورة يوسف", "سورة الرعد", "سورة الحجر", "سورة النحل", "سورة الاسراء", "سورة الكهف", "سورة مريم", "سورة طه", "سورة الانبياء", "سورة الحج", "سورة المؤمنون", "سورة الاحزاب", "سورة العنكبوت", "سورة الصافات", "سورة غافر", "سورة الفتح", "سورة ق", "سورة الواقعة", "سورة الحديد" };
        string[] c44 = { "سورة البقرة ", "سورة ال عمران", "سورة النساء", "سورة الانعام", "سورة الاعراف", "سورة الانفال", "سورة التوبة", "سورة يونس", "سورة هود", "سورة يوسف", "سورة الرعد", "سورة الحجر", "سورة النحل", "سورة الاسراء", "سورة الكهف", "سورة مريم", "سورة طه", "سورة الانبياء", "سورة الحج", "سورة النور", "سورة الفرقان", "سورة الشعراء", "سورة النمل", "سورة الروم", "سورة الزمر", "سورة فصلت", "سورة الشورى", "سورة الذاريات", "سورة الحديد", "سورة المدثر" };
        string[] c5 = { "سورة البقرة ", "سورة ال عمران", "سورة النساء", "سورة الانعام", "سورة الاعراف", "سورة التوبة", "سورة هود", "سورة يوسف", "سورة الرعد", "سورة ابراهيم", "سورة الحجر", "سورة الاسراء", "سورة الكهف", "سورة طه", "سورة الانبياء", "سورة الحج", "سورة النور", "سورة الشعراء", "سورة النمل", "سورة القصص يس", "سورة الصافات", "سورة الزمر", "سورة غافر", "سورة فصلت", "سورة الشورى", "سورة محمد", "سورة الفتح", "سورة النجم", "سورة الحديد", "سورة المجادلة", "سورة الطلاق" };
        string[] c6 = { "سورة البقرة ", "سورة ال عمران", "سورة النساء", "سورة الانعام", "سورة الاعراف", "سورة الانفال", "سورة التوبة", "سورة يونس", "سورة هود", "سورة يوسف", "سورة الرعد", "سورة الحجر", "سورة النحل", "سورة الاسراء", "سورة الكهف", "سورة مريم", "سورة طه", "سورة الانبياء", "سورة الحج", "سورة المؤمنون", "سورة النور", "سورة النمل", "سورة القصص", "سورة الاحزاب", "سورة ص", "سورة الزمر", "سورة غافر", "سورة فصلت", "سورة الطور", "سورة المجادلة" };
        string[] ct = { "القسم الاول", "القسم الثانى", "القسم الثالث", "القسم الرابع", "القسم الخامس", "الخاتمة" };

        public Frm_Kep()
        {
            InitializeComponent();
        }

        private void Frm_Kep_Load(object sender, EventArgs e)
        {
            com_Teyp.Items.AddRange(ct);
        }

        private void com_Teyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (com_Teyp.Text)
            {
                case "القسم الاول":
                    Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\sar7.rtf");
                    c4.Items.Clear();
                    c4.Items.AddRange(c1);


                    c4.Enabled = true;
                    break;
                case "القسم الثانى":
                    Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\sar7.rtf");
                    c4.Items.Clear();
                    c4.Items.AddRange(c2);

                    c4.Enabled = true;

                    break;
                case "القسم الثالث":
                    Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\sar7.rtf");
                    c4.Enabled = true;
                    c4.Items.Clear();
                    c4.Items.AddRange(c3);

                    break;
                case "الخاتمة":
                    Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\sar7.rtf");
                    c4.Enabled = true;
                    c4.Items.Clear();
                    c4.Items.AddRange(c44);

                    break;
                case "القسم الخامس":
                    Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\sar7.rtf");
                    c4.Enabled = true;
                    c4.Items.Clear();
                    c4.Items.AddRange(c5);

                    break;
                case "الخاتمة ":
                    Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\sar7.rtf");
                    c4.Enabled = true;
                    c4.Items.Clear();
                    c4.Items.AddRange(c6);


                    break;
            }
        }

        private void c4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c4.Text == c1[0] && com_Teyp.Text == ct[0])
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\q.rtf");
            }
            else if (c4.Text == "سورة ال عمران" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\al.rtf");
            }
            else if (c4.Text == "سورة النساء" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\ne.rtf");
            }
            else if (c4.Text == "سورة الانعام" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\an3.rtf");
            }
            else if (c4.Text == "سورة الاعراف" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\a3.rtf");
            }
            else if (c4.Text == "سورة الانفال" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\anf.rtf");
            }
            else if (c4.Text == "سورة التوبة" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\alt.rtf");
            }
            else if (c4.Text == "سورة يونس" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\uw.rtf");
            }
            else if (c4.Text == "سورة هود" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\ho.rtf");
            }
            else if (c4.Text == "سورة يوسف" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\uos.rtf");
            }
            else if (c4.Text == "سورة الرعد" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\r3.rtf");
            }
            else if (c4.Text == "سورة الحجر" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\7gr.rtf");
            }
            else if (c4.Text == "سورة النحل" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\aln.rtf");
            }
            else if (c4.Text == "سورة الاسراء" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\alsr.rtf");
            }
            else if (c4.Text == "سورة الكهف" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\alka.rtf");
            }
            else if (c4.Text == "سورة مريم" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\mr.rtf");
            }
            else if (c4.Text == "سورة طه" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\ta.rtf");
            }
            else if (c4.Text == "سورة الانبياء" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\bya.rtf");
            }
            else if (c4.Text == "سورة الحج" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\7g.rtf");
            }
            else if (c4.Text == "سورة المؤمنون" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\mom.rtf");
            }
            else if (c4.Text == "سورة النور" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\nor.rtf");
            }
            else if (c4.Text == "سورة النمل" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\nml.rtf");
            }
            else if (c4.Text == "سورة القصص" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\kas.rtf");
            }
            else if (c4.Text == "سورة الاحزاب" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\hzb.rtf");
            }
            else if (c4.Text == "سورة ص" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\sd.rtf");
            }
            else if (c4.Text == "سورة الزمر" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\zmr.rtf");
            }
            else if (c4.Text == "سورة غافر" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\gaf.rtf");
            }
            else if (c4.Text == "سورة فصلت" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\fslt.rtf");
            }
            else if (c4.Text == "سورة الطور" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\tor.rtf");
            }
            else if (c4.Text == "سورة المجادلة" && com_Teyp.Text == "القسم الاول")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p1\\mog.rtf");
                //انتهى القسم الاول'''''''''''''''''''''''''''''''''
            }
            else if (c4.Text == "سورة البقرة " && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\q.rtf");
            }
            else if (c4.Text == "سورة ال عمران" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\al.rtf");
            }
            else if (c4.Text == "سورة النساء" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\ne.rtf");
            }
            else if (c4.Text == "سورة الانعام" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\an3.rtf");
            }
            else if (c4.Text == "سورة الاعراف" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\a3.rtf");
            }
            else if (c4.Text == "سورة الانفال" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\anf.rtf");
            }
            else if (c4.Text == "سورة التوبة" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\alt.rtf");
            }
            else if (c4.Text == "سورة يونس" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\uw.rtf");
            }
            else if (c4.Text == "سورة هود" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\ho.rtf");
            }
            else if (c4.Text == "سورة يوسف" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\uos.rtf");
            }
            else if (c4.Text == "سورة الرعد" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\r3.rtf");
            }
            else if (c4.Text == "سورة الحجر" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\7gr.rtf");
            }
            else if (c4.Text == "سورة النحل" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\aln.rtf");
            }
            else if (c4.Text == "سورة الاسراء" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\alsr.rtf");
            }
            else if (c4.Text == "سورة الكهف" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\alka.rtf");
            }
            else if (c4.Text == "سورة مريم" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\mr.rtf");
            }
            else if (c4.Text == "سورة طه" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\ta.rtf");
            }
            else if (c4.Text == "سورة الانبياء" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\bya.rtf");
            }
            else if (c4.Text == "سورة الحج" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\7g.rtf");
            }
            else if (c4.Text == "سورة المؤمنون" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\mom.rtf");
            }
            else if (c4.Text == "سورة النور" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\nor.rtf");
            }
            else if (c4.Text == "سورة النمل" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\nml.rtf");
            }
            else if (c4.Text == "سورة القصص" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\kas.rtf");
            }
            else if (c4.Text == "سورة الاحزاب" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\hzb.rtf");
            }
            else if (c4.Text == "سورة ص" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\sd.rtf");
            }
            else if (c4.Text == "سورة الزمر" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\zmr.rtf");
            }
            else if (c4.Text == "سورة غافر" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\gaf.rtf");
            }
            else if (c4.Text == "سورة فصلت" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\fslt.rtf");
            }
            else if (c4.Text == "سورة الطور" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\tor.rtf");
            }
            else if (c4.Text == "سورة المجادلة" && com_Teyp.Text == "القسم الثانى")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p2\\mog.rtf");
                //انتهى القسم الثانى '''''''''''''''''''''''''''''''''''''
            }
            else if (c4.Text == "سورة البقرة " && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\q.rtf");
            }
            else if (c4.Text == "سورة ال عمران" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\al.rtf");
            }
            else if (c4.Text == "سورة النساء" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\ne.rtf");
            }
            else if (c4.Text == "سورة الانعام" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\an3.rtf");
            }
            else if (c4.Text == "سورة الاعراف" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\a3.rtf");
            }
            else if (c4.Text == "سورة الانفال" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\anf.rtf");
            }
            else if (c4.Text == "سورة التوبة" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\alt.rtf");
            }
            else if (c4.Text == "سورة يونس" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\uw.rtf");
            }
            else if (c4.Text == "سورة هود" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\ho.rtf");
            }
            else if (c4.Text == "سورة يوسف" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\uos.rtf");
            }
            else if (c4.Text == "سورة الرعد" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\r3.rtf");
            }
            else if (c4.Text == "سورة الحجر" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\7gr.rtf");
            }
            else if (c4.Text == "سورة النحل" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\aln.rtf");
            }
            else if (c4.Text == "سورة الاسراء" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\alsr.rtf");
            }
            else if (c4.Text == "سورة الكهف" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\alka.rtf");
            }
            else if (c4.Text == "سورة مريم" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\mr.rtf");
            }
            else if (c4.Text == "سورة طه" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\ta.rtf");
            }
            else if (c4.Text == "سورة الانبياء" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\bya.rtf");
            }
            else if (c4.Text == "سورة الحج" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\7g.rtf");
            }
            else if (c4.Text == "سورة المؤمنون" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\mom.rtf");
            }
            else if (c4.Text == "سورة النور" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\nor.rtf");
            }
            else if (c4.Text == "سورة النمل" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\nml.rtf");
            }
            else if (c4.Text == "سورة القصص" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\kas.rtf");
            }
            else if (c4.Text == "سورة الاحزاب" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\hzb.rtf");
            }
            else if (c4.Text == "سورة ص" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\sd.rtf");
            }
            else if (c4.Text == "سورة الزمر" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\zmr.rtf");
            }
            else if (c4.Text == "سورة غافر" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\gaf.rtf");
            }
            else if (c4.Text == "سورة فصلت" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\fslt.rtf");
            }
            else if (c4.Text == "سورة الطور" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\tor.rtf");
            }
            else if (c4.Text == "سورة المجادلة" && com_Teyp.Text == "القسم الثالث")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p3\\mog.rtf");
                //انتهى القسم الثالث '''''''''''''''''''''''''''''''''
            }
            else if (c4.Text == "سورة البقرة " && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\q.rtf");
            }
            else if (c4.Text == "سورة ال عمران" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\al.rtf");
            }
            else if (c4.Text == "سورة النساء" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\ne.rtf");
            }
            else if (c4.Text == "سورة الانعام" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\an3.rtf");
            }
            else if (c4.Text == "سورة الاعراف" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\a3.rtf");
            }
            else if (c4.Text == "سورة الانفال" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\anf.rtf");
            }
            else if (c4.Text == "سورة التوبة" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\alt.rtf");
            }
            else if (c4.Text == "سورة يونس" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\uw.rtf");
            }
            else if (c4.Text == "سورة هود" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\ho.rtf");
            }
            else if (c4.Text == "سورة يوسف" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\uos.rtf");
            }
            else if (c4.Text == "سورة الرعد" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\r3.rtf");
            }
            else if (c4.Text == "سورة الحجر" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\7gr.rtf");
            }
            else if (c4.Text == "سورة النحل" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\aln.rtf");
            }
            else if (c4.Text == "سورة الاسراء" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\alsr.rtf");
            }
            else if (c4.Text == "سورة الكهف" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\alka.rtf");
            }
            else if (c4.Text == "سورة مريم" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\mr.rtf");
            }
            else if (c4.Text == "سورة طه" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\ta.rtf");
            }
            else if (c4.Text == "سورة الانبياء" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\bya.rtf");
            }
            else if (c4.Text == "سورة الحج" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\7g.rtf");
            }
            else if (c4.Text == "سورة المؤمنون" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\mom.rtf");
            }
            else if (c4.Text == "سورة النور" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\nor.rtf");
            }
            else if (c4.Text == "سورة النمل" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\nml.rtf");
            }
            else if (c4.Text == "سورة القصص" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\kas.rtf");
            }
            else if (c4.Text == "سورة الاحزاب" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\hzb.rtf");
            }
            else if (c4.Text == "سورة ص" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\sd.rtf");
            }
            else if (c4.Text == "سورة الزمر" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\zmr.rtf");
            }
            else if (c4.Text == "سورة غافر" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\gaf.rtf");
            }
            else if (c4.Text == "سورة فصلت" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\fslt.rtf");
            }
            else if (c4.Text == "سورة الطور" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\tor.rtf");
            }
            else if (c4.Text == "سورة المجادلة" && com_Teyp.Text == "القسم الرابع")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p4\\mog.rtf");
                //'انتهى القسم الرابع''''''''''''''''''''''''''''''


            }
            else if (c4.Text == "سورة البقرة " && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\q.rtf");
            }
            else if (c4.Text == "سورة ال عمران" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\al.rtf");
            }
            else if (c4.Text == "سورة النساء" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\ne.rtf");
            }
            else if (c4.Text == "سورة الانعام" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\an3.rtf");
            }
            else if (c4.Text == "سورة الاعراف" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\a3.rtf");
            }
            else if (c4.Text == "سورة الانفال" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\anf.rtf");
            }
            else if (c4.Text == "سورة التوبة" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\alt.rtf");
            }
            else if (c4.Text == "سورة يونس" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\uw.rtf");
            }
            else if (c4.Text == "سورة هود" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\ho.rtf");
            }
            else if (c4.Text == "سورة يوسف" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\uos.rtf");
            }
            else if (c4.Text == "سورة الرعد" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\r3.rtf");
            }
            else if (c4.Text == "سورة الحجر" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\7gr.rtf");
            }
            else if (c4.Text == "سورة النحل" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\aln.rtf");
            }
            else if (c4.Text == "سورة الاسراء" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\alsr.rtf");
            }
            else if (c4.Text == "سورة الكهف" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\alka.rtf");
            }
            else if (c4.Text == "سورة مريم" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\mr.rtf");
            }
            else if (c4.Text == "سورة طه" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\ta.rtf");
            }
            else if (c4.Text == "سورة الانبياء" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\bya.rtf");
            }
            else if (c4.Text == "سورة الحج" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\7g.rtf");
            }
            else if (c4.Text == "سورة المؤمنون" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\mom.rtf");
            }
            else if (c4.Text == "سورة النور" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\nor.rtf");
            }
            else if (c4.Text == "سورة النمل" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\nml.rtf");
            }
            else if (c4.Text == "سورة القصص" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\kas.rtf");
            }
            else if (c4.Text == "سورة الاحزاب" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\hzb.rtf");
            }
            else if (c4.Text == "سورة ص" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\sd.rtf");
            }
            else if (c4.Text == "سورة الزمر" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\zmr.rtf");
            }
            else if (c4.Text == "سورة غافر" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\gaf.rtf");
            }
            else if (c4.Text == "سورة فصلت" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\fslt.rtf");
            }
            else if (c4.Text == "سورة الطور" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\tor.rtf");
            }
            else if (c4.Text == "سورة المجادلة" && com_Teyp.Text == "القسم الخامس")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p5\\mog.rtf");
                //'انتهى القسم الخامس''''''''''''''''''''''''''''''

            }
            else if (c4.Text == "سورة البقرة " && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\q.rtf");
            }
            else if (c4.Text == "سورة ال عمران" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\al.rtf");
            }
            else if (c4.Text == "سورة النساء" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\ne.rtf");
            }
            else if (c4.Text == "سورة الانعام" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\an3.rtf");
            }
            else if (c4.Text == "سورة الاعراف" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\a3.rtf");
            }
            else if (c4.Text == "سورة الانفال" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\anf.rtf");
            }
            else if (c4.Text == "سورة التوبة" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\alt.rtf");
            }
            else if (c4.Text == "سورة يونس" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\uw.rtf");
            }
            else if (c4.Text == "سورة هود" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\ho.rtf");
            }
            else if (c4.Text == "سورة يوسف" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\uos.rtf");
            }
            else if (c4.Text == "سورة الرعد" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\r3.rtf");
            }
            else if (c4.Text == "سورة الحجر" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\7gr.rtf");
            }
            else if (c4.Text == "سورة النحل" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\aln.rtf");
            }
            else if (c4.Text == "سورة الاسراء" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\alsr.rtf");
            }
            else if (c4.Text == "سورة الكهف" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\alka.rtf");
            }
            else if (c4.Text == "سورة مريم" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\mr.rtf");
            }
            else if (c4.Text == "سورة طه" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\ta.rtf");
            }
            else if (c4.Text == "سورة الانبياء" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\bya.rtf");
            }
            else if (c4.Text == "سورة الحج" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\7g.rtf");
            }
            else if (c4.Text == "سورة المؤمنون" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\mom.rtf");
            }
            else if (c4.Text == "سورة النور" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\nor.rtf");
            }
            else if (c4.Text == "سورة النمل" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\nml.rtf");
            }
            else if (c4.Text == "سورة القصص" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\kas.rtf");
            }
            else if (c4.Text == "سورة الاحزاب" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\hzb.rtf");
            }
            else if (c4.Text == "سورة ص" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\sd.rtf");
            }
            else if (c4.Text == "سورة الزمر" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\zmr.rtf");
            }
            else if (c4.Text == "سورة غافر" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\gaf.rtf");
            }
            else if (c4.Text == "سورة فصلت" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\fslt.rtf");
            }
            else if (c4.Text == "سورة الطور" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\tor.rtf");
            }
            else if (c4.Text == "سورة المجادلة" && com_Teyp.Text == "الخاتمة")
            {
                Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Similarities in the Quran\\p6\\mog.rtf");
                //'انتهى الخاتمة''''''''''''''''''''''''''''''
            }
        }
    }
}
