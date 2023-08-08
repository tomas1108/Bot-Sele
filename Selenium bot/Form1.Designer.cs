namespace Selenium_bot
{
    partial class Form1
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
            this.dbSele = new System.Windows.Forms.DataGridView();
            this.btnRun = new System.Windows.Forms.Button();
            this.comboSele = new System.Windows.Forms.ComboBox();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.btnAddStep = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbSele)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbSele
            // 
            this.dbSele.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbSele.Location = new System.Drawing.Point(12, 59);
            this.dbSele.Name = "dbSele";
            this.dbSele.RowHeadersWidth = 51;
            this.dbSele.RowTemplate.Height = 24;
            this.dbSele.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dbSele.Size = new System.Drawing.Size(550, 167);
            this.dbSele.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(492, 8);
            this.btnRun.Margin = new System.Windows.Forms.Padding(5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(174, 55);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "UpLoad";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // comboSele
            // 
            this.comboSele.FormattingEnabled = true;
            this.comboSele.Location = new System.Drawing.Point(12, 29);
            this.comboSele.Name = "comboSele";
            this.comboSele.Size = new System.Drawing.Size(514, 24);
            this.comboSele.TabIndex = 2;
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(310, 8);
            this.btnCreateFile.Margin = new System.Windows.Forms.Padding(5);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(174, 55);
            this.btnCreateFile.TabIndex = 12;
            this.btnCreateFile.Text = "CreateFile";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            // 
            // btnAddStep
            // 
            this.btnAddStep.Location = new System.Drawing.Point(532, 28);
            this.btnAddStep.Name = "btnAddStep";
            this.btnAddStep.Size = new System.Drawing.Size(30, 24);
            this.btnAddStep.TabIndex = 13;
            this.btnAddStep.Text = "........";
            this.btnAddStep.UseVisualStyleBackColor = true;
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 55);
            this.button1.TabIndex = 14;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 55);
            this.button2.TabIndex = 15;
            this.button2.Text = "Open";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(675, 94);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 55);
            this.button3.TabIndex = 16;
            this.button3.Text = "Đăng xuất";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button3);
            this.panelControl1.Controls.Add(this.btnRun);
            this.panelControl1.Controls.Add(this.btnCreateFile);
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.button2);
            this.panelControl1.Location = new System.Drawing.Point(20, 365);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(856, 156);
            this.panelControl1.TabIndex = 17;
            // 
            // txtUser
            // 
            this.txtUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUser.Location = new System.Drawing.Point(12, 0);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.ShortcutsEnabled = false;
            this.txtUser.Size = new System.Drawing.Size(550, 23);
            this.txtUser.TabIndex = 18;
            this.txtUser.Text = "mamon@gmail.com";
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.Click += new System.EventHandler(this.txtUser_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(454, 242);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(108, 41);
            this.btnUpload.TabIndex = 19;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(330, 242);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 41);
            this.button4.TabIndex = 20;
            this.button4.Text = "Create";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(200, 242);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 41);
            this.button5.TabIndex = 21;
            this.button5.Text = "Open";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(71, 242);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 41);
            this.button6.TabIndex = 22;
            this.button6.Text = "Test";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 347);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnAddStep);
            this.Controls.Add(this.comboSele);
            this.Controls.Add(this.dbSele);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbSele)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbSele;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ComboBox comboSele;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.Button btnAddStep;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

