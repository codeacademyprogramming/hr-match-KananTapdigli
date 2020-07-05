namespace HrMatchApp
{
    partial class EmployerMenuForm
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
            this.addAnnouncement = new System.Windows.Forms.Button();
            this.applies = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addAnnouncement
            // 
            this.addAnnouncement.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addAnnouncement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addAnnouncement.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAnnouncement.Location = new System.Drawing.Point(80, 83);
            this.addAnnouncement.Name = "addAnnouncement";
            this.addAnnouncement.Size = new System.Drawing.Size(314, 139);
            this.addAnnouncement.TabIndex = 2;
            this.addAnnouncement.Text = "ADD ANNOUNCEMENT";
            this.addAnnouncement.UseVisualStyleBackColor = false;
            this.addAnnouncement.Click += new System.EventHandler(this.addAnnouncement_Click);
            // 
            // applies
            // 
            this.applies.BackColor = System.Drawing.SystemColors.ControlLight;
            this.applies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.applies.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applies.Location = new System.Drawing.Point(80, 263);
            this.applies.Name = "applies";
            this.applies.Size = new System.Drawing.Size(314, 136);
            this.applies.TabIndex = 3;
            this.applies.Text = "APPLIES";
            this.applies.UseVisualStyleBackColor = false;
            this.applies.Click += new System.EventHandler(this.applies_Click);
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.SystemColors.ControlLight;
            this.search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(448, 83);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(272, 139);
            this.search.TabIndex = 4;
            this.search.Text = "SEARCH";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // logOut
            // 
            this.logOut.BackColor = System.Drawing.SystemColors.ControlLight;
            this.logOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOut.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut.Location = new System.Drawing.Point(448, 263);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(272, 136);
            this.logOut.TabIndex = 5;
            this.logOut.Text = "LOG OUT";
            this.logOut.UseVisualStyleBackColor = false;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.title.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.Window;
            this.title.Location = new System.Drawing.Point(287, 24);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(0, 27);
            this.title.TabIndex = 6;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.title);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.search);
            this.Controls.Add(this.applies);
            this.Controls.Add(this.addAnnouncement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form5";
            this.ShowIcon = false;
            this.Text = "EMPLOYER MENU";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addAnnouncement;
        private System.Windows.Forms.Button applies;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Label title;
    }
}