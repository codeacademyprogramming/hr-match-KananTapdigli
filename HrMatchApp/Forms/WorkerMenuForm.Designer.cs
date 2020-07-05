namespace HrMatchApp
{
    partial class WorkerMenuForm
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
            this.addCV = new System.Windows.Forms.Button();
            this.information = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.suitableAnnouncements = new System.Windows.Forms.Button();
            this.appliedAnnouncements = new System.Windows.Forms.Button();
            this.allAnnouncements = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addCV
            // 
            this.addCV.BackColor = System.Drawing.SystemColors.Window;
            this.addCV.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCV.Location = new System.Drawing.Point(105, 63);
            this.addCV.Name = "addCV";
            this.addCV.Size = new System.Drawing.Size(231, 73);
            this.addCV.TabIndex = 1;
            this.addCV.Text = "ADD CV";
            this.addCV.UseVisualStyleBackColor = false;
            this.addCV.Click += new System.EventHandler(this.addCV_Click);
            // 
            // information
            // 
            this.information.BackColor = System.Drawing.SystemColors.Window;
            this.information.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.information.Location = new System.Drawing.Point(105, 159);
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(231, 76);
            this.information.TabIndex = 2;
            this.information.Text = "CV INFORMATIONS";
            this.information.UseVisualStyleBackColor = false;
            this.information.Click += new System.EventHandler(this.information_Click);
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.SystemColors.Window;
            this.search.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(105, 258);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(231, 78);
            this.search.TabIndex = 4;
            this.search.Text = "SEARCH";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // suitableAnnouncements
            // 
            this.suitableAnnouncements.BackColor = System.Drawing.SystemColors.Window;
            this.suitableAnnouncements.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suitableAnnouncements.Location = new System.Drawing.Point(466, 63);
            this.suitableAnnouncements.Name = "suitableAnnouncements";
            this.suitableAnnouncements.Size = new System.Drawing.Size(242, 73);
            this.suitableAnnouncements.TabIndex = 3;
            this.suitableAnnouncements.Text = "SUITABLE ANNOUNCEMENTS";
            this.suitableAnnouncements.UseVisualStyleBackColor = false;
            this.suitableAnnouncements.Click += new System.EventHandler(this.suitableAnnouncements_Click);
            // 
            // appliedAnnouncements
            // 
            this.appliedAnnouncements.BackColor = System.Drawing.SystemColors.Window;
            this.appliedAnnouncements.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appliedAnnouncements.Location = new System.Drawing.Point(466, 159);
            this.appliedAnnouncements.Name = "appliedAnnouncements";
            this.appliedAnnouncements.Size = new System.Drawing.Size(242, 76);
            this.appliedAnnouncements.TabIndex = 5;
            this.appliedAnnouncements.Text = "APPLIED ANNOUNCEMENTS";
            this.appliedAnnouncements.UseVisualStyleBackColor = false;
            this.appliedAnnouncements.Click += new System.EventHandler(this.appliedAnnouncements_Click);
            // 
            // allAnnouncements
            // 
            this.allAnnouncements.BackColor = System.Drawing.SystemColors.Window;
            this.allAnnouncements.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allAnnouncements.Location = new System.Drawing.Point(466, 258);
            this.allAnnouncements.Name = "allAnnouncements";
            this.allAnnouncements.Size = new System.Drawing.Size(242, 78);
            this.allAnnouncements.TabIndex = 6;
            this.allAnnouncements.Text = "ALL ANNOUNCEMENTS";
            this.allAnnouncements.UseVisualStyleBackColor = false;
            this.allAnnouncements.Click += new System.EventHandler(this.allAnnouncements_Click);
            // 
            // logOut
            // 
            this.logOut.BackColor = System.Drawing.SystemColors.Window;
            this.logOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOut.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut.Location = new System.Drawing.Point(289, 360);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(231, 78);
            this.logOut.TabIndex = 7;
            this.logOut.Text = "LOG OUT";
            this.logOut.UseVisualStyleBackColor = false;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.Window;
            this.title.Location = new System.Drawing.Point(311, 27);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(0, 23);
            this.title.TabIndex = 8;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.title);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.allAnnouncements);
            this.Controls.Add(this.appliedAnnouncements);
            this.Controls.Add(this.search);
            this.Controls.Add(this.suitableAnnouncements);
            this.Controls.Add(this.information);
            this.Controls.Add(this.addCV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form4";
            this.ShowIcon = false;
            this.Text = "WORKER MENU";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addCV;
        private System.Windows.Forms.Button information;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button suitableAnnouncements;
        private System.Windows.Forms.Button allAnnouncements;
        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button appliedAnnouncements;
    }
}