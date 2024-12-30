namespace LibraryManagment
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
            this.btnSignInSignUp = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnPeople = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSignInSignUp
            // 
            this.btnSignInSignUp.Location = new System.Drawing.Point(233, 106);
            this.btnSignInSignUp.Name = "btnSignInSignUp";
            this.btnSignInSignUp.Size = new System.Drawing.Size(133, 33);
            this.btnSignInSignUp.TabIndex = 0;
            this.btnSignInSignUp.Text = "Sign In / Sign Up";
            this.btnSignInSignUp.UseVisualStyleBackColor = true;
            this.btnSignInSignUp.Click += new System.EventHandler(this.btnSignInSignUp_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.Location = new System.Drawing.Point(80, 106);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(78, 33);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.Text = "Books";
            this.btnBooks.UseVisualStyleBackColor = true;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // btnPeople
            // 
            this.btnPeople.Location = new System.Drawing.Point(291, 227);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(75, 34);
            this.btnPeople.TabIndex = 2;
            this.btnPeople.Text = "People";
            this.btnPeople.UseVisualStyleBackColor = true;
            this.btnPeople.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(80, 227);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(79, 34);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 381);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnPeople);
            this.Controls.Add(this.btnBooks);
            this.Controls.Add(this.btnSignInSignUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSignInSignUp;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnReports;
    }
}

