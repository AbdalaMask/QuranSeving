using Krypton.Toolkit;
using QuranSeving.Seveing;
using QuranSeving.Tag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuranSeving
{
    public partial class FrmMain : KryptonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void barButtonExit1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void barButtonCreateUse_Click(object sender, EventArgs e)
        {
            Frm_SevaUser frm = new Frm_SevaUser();
            frm.Show();
        }

        private void barButtonOther_Save_Click(object sender, EventArgs e)
        {
            Frm_other_red frm = new Frm_other_red();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonTag_Click(object sender, EventArgs e)
        {
            Frm_Teg frm = new Frm_Teg();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btn_Frm_Seva_Click(object sender, EventArgs e)
        {
            Frm_Seva frm = new Frm_Seva();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btn_FormAbout_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.Show();
        }
    }
}
