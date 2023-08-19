namespace QuranSeving.DB
{
    partial class FrmCreateDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateDatabase));
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.txtCreateDatabase = new Krypton.Toolkit.KryptonTextBox();
            this.btnCreateDatabase = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(319, 52);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(113, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "اختار اسم لقاعدة البيانات:";
            // 
            // txtCreateDatabase
            // 
            this.txtCreateDatabase.Location = new System.Drawing.Point(33, 52);
            this.txtCreateDatabase.Name = "txtCreateDatabase";
            this.txtCreateDatabase.Size = new System.Drawing.Size(257, 20);
            this.txtCreateDatabase.TabIndex = 1;
            this.txtCreateDatabase.Text = " ";
            // 
            // btnCreateDatabase
            // 
            this.btnCreateDatabase.Location = new System.Drawing.Point(12, 92);
            this.btnCreateDatabase.Name = "btnCreateDatabase";
            this.btnCreateDatabase.Size = new System.Drawing.Size(134, 25);
            this.btnCreateDatabase.TabIndex = 2;
            this.btnCreateDatabase.Values.Text = "انشاء قاعدة بيانات للحفظ";
            this.btnCreateDatabase.Click += new System.EventHandler(this.btnCreateDatabase_Click);
            // 
            // FrmCreateDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 129);
            this.Controls.Add(this.btnCreateDatabase);
            this.Controls.Add(this.txtCreateDatabase);
            this.Controls.Add(this.kryptonLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCreateDatabase";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إنشاء قاعدة البيانات";
            this.Load += new System.EventHandler(this.FrmCreateDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox txtCreateDatabase;
        private Krypton.Toolkit.KryptonButton btnCreateDatabase;
    }
}