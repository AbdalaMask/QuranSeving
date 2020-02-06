namespace QuranSeving
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuranSeving.Properties.Resources.فكرة_وبرمجة_موقع_القرآن_حياتنا_لا_تنسونا_من_صالح_دعائكم;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 275);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.Location = new System.Drawing.Point(55, 293);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kryptonLabel1.Size = new System.Drawing.Size(549, 122);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "النسخة الاولى من البرناامج كانت بلغة الفجول بيسك 6  \r\nوكانت البرمجة من موقع  القر" +
    "اءان حياتنا \r\n\r\nثم تم السماح لى بتطوير البرانامج من قبل المبرمج  \r\n\r\nشكرا  لة عل" +
    "ى الفكرة  وعلى جهودة \r\n";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 427);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAbout";
            this.Text = "FormAbout";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}