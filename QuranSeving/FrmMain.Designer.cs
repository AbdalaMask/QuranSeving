namespace QuranSeving
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.barButtonExit = new System.Windows.Forms.ToolStripMenuItem();
            this.barButtonExit1 = new System.Windows.Forms.ToolStripMenuItem();
            this.خياراتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barButtonCreateUse = new System.Windows.Forms.ToolStripMenuItem();
            this.حولToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_FormAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.barButtonTag = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.barButtonOther_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Frm_Seva = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Frm_Mushaf = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Location = new System.Drawing.Point(0, 598);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1132, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barButtonExit,
            this.خياراتToolStripMenuItem,
            this.حولToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1132, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // barButtonExit
            // 
            this.barButtonExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barButtonExit1});
            this.barButtonExit.Name = "barButtonExit";
            this.barButtonExit.Size = new System.Drawing.Size(36, 20);
            this.barButtonExit.Text = "ملف";
            // 
            // barButtonExit1
            // 
            this.barButtonExit1.Name = "barButtonExit1";
            this.barButtonExit1.Size = new System.Drawing.Size(99, 22);
            this.barButtonExit1.Text = "خروج";
            this.barButtonExit1.Click += new System.EventHandler(this.barButtonExit1_Click);
            // 
            // خياراتToolStripMenuItem
            // 
            this.خياراتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barButtonCreateUse});
            this.خياراتToolStripMenuItem.Name = "خياراتToolStripMenuItem";
            this.خياراتToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.خياراتToolStripMenuItem.Text = "خيارات";
            // 
            // barButtonCreateUse
            // 
            this.barButtonCreateUse.Name = "barButtonCreateUse";
            this.barButtonCreateUse.Size = new System.Drawing.Size(163, 22);
            this.barButtonCreateUse.Text = "اضافة مستخدم جديد";
            this.barButtonCreateUse.Click += new System.EventHandler(this.barButtonCreateUse_Click);
            // 
            // حولToolStripMenuItem
            // 
            this.حولToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_FormAbout});
            this.حولToolStripMenuItem.Name = "حولToolStripMenuItem";
            this.حولToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.حولToolStripMenuItem.Text = "حول";
            // 
            // btn_FormAbout
            // 
            this.btn_FormAbout.Name = "btn_FormAbout";
            this.btn_FormAbout.Size = new System.Drawing.Size(133, 22);
            this.btn_FormAbout.Text = "حول البرنامج";
            this.btn_FormAbout.Click += new System.EventHandler(this.btn_FormAbout_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barButtonTag,
            this.toolStripSeparator1,
            this.barButtonOther_Save,
            this.toolStripSeparator2,
            this.btn_Frm_Seva,
            this.toolStripSeparator3,
            this.ts_Frm_Mushaf});
            this.toolStrip2.Location = new System.Drawing.Point(0, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1132, 55);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // barButtonTag
            // 
            this.barButtonTag.Image = global::QuranSeving.Properties.Resources.iconfinder_minber_56317__1_;
            this.barButtonTag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barButtonTag.Name = "barButtonTag";
            this.barButtonTag.Size = new System.Drawing.Size(90, 52);
            this.barButtonTag.Text = "التجويد";
            this.barButtonTag.Click += new System.EventHandler(this.barButtonTag_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // barButtonOther_Save
            // 
            this.barButtonOther_Save.Image = global::QuranSeving.Properties.Resources.iconfinder_seccade_56318__1_;
            this.barButtonOther_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.barButtonOther_Save.Name = "barButtonOther_Save";
            this.barButtonOther_Save.Size = new System.Drawing.Size(107, 52);
            this.barButtonOther_Save.Text = "طرق الحفظ";
            this.barButtonOther_Save.Click += new System.EventHandler(this.barButtonOther_Save_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btn_Frm_Seva
            // 
            this.btn_Frm_Seva.Image = global::QuranSeving.Properties.Resources.iconfinder_kuran_56315__2_;
            this.btn_Frm_Seva.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Frm_Seva.Name = "btn_Frm_Seva";
            this.btn_Frm_Seva.Size = new System.Drawing.Size(84, 52);
            this.btn_Frm_Seva.Text = "الحفظ";
            this.btn_Frm_Seva.Click += new System.EventHandler(this.btn_Frm_Seva_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // ts_Frm_Mushaf
            // 
            this.ts_Frm_Mushaf.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_Frm_Mushaf.Image = global::QuranSeving.Properties.Resources.elforkane;
            this.ts_Frm_Mushaf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Frm_Mushaf.Name = "ts_Frm_Mushaf";
            this.ts_Frm_Mushaf.Size = new System.Drawing.Size(96, 52);
            this.ts_Frm_Mushaf.Text = "المصحف";
            this.ts_Frm_Mushaf.Click += new System.EventHandler(this.ts_Frm_Mushaf_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 623);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "المحفظ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem barButtonExit;
        private System.Windows.Forms.ToolStripMenuItem barButtonExit1;
        private System.Windows.Forms.ToolStripMenuItem خياراتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barButtonCreateUse;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton barButtonTag;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton barButtonOther_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_Frm_Seva;
        private System.Windows.Forms.ToolStripMenuItem حولToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btn_FormAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ts_Frm_Mushaf;
    }
}

