namespace BackgammonClient
{
    partial class SignUpWindow
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
            UserNameTextBox = new System.Windows.Forms.TextBox();
            PasswordTextBox = new System.Windows.Forms.TextBox();
            FirstNameTextBox = new System.Windows.Forms.TextBox();
            LastNameTextBox = new System.Windows.Forms.TextBox();
            EmailTextBox = new System.Windows.Forms.TextBox();
            CityComboBox = new System.Windows.Forms.ComboBox();
            GenderComboBox = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            SignUpButton = new System.Windows.Forms.Button();
            LogInButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new System.Drawing.Point(218, 32);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new System.Drawing.Size(263, 23);
            UserNameTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new System.Drawing.Point(218, 68);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new System.Drawing.Size(263, 23);
            PasswordTextBox.TabIndex = 1;
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Location = new System.Drawing.Point(218, 110);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new System.Drawing.Size(263, 23);
            FirstNameTextBox.TabIndex = 2;
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Location = new System.Drawing.Point(218, 152);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new System.Drawing.Size(263, 23);
            LastNameTextBox.TabIndex = 3;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new System.Drawing.Point(218, 194);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new System.Drawing.Size(263, 23);
            EmailTextBox.TabIndex = 4;
            // 
            // CityComboBox
            // 
            CityComboBox.FormattingEnabled = true;
            CityComboBox.Location = new System.Drawing.Point(218, 238);
            CityComboBox.Name = "CityComboBox";
            CityComboBox.Size = new System.Drawing.Size(263, 23);
            CityComboBox.TabIndex = 5;
            // 
            // GenderComboBox
            // 
            GenderComboBox.FormattingEnabled = true;
            GenderComboBox.Location = new System.Drawing.Point(218, 290);
            GenderComboBox.Name = "GenderComboBox";
            GenderComboBox.Size = new System.Drawing.Size(263, 23);
            GenderComboBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(139, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 7;
            label1.Text = "user name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(139, 71);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 15);
            label2.TabIndex = 8;
            label2.Text = "password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(139, 112);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 15);
            label3.TabIndex = 9;
            label3.Text = "first name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(139, 154);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(58, 15);
            label4.TabIndex = 10;
            label4.Text = "last name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(139, 196);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(36, 15);
            label5.TabIndex = 11;
            label5.Text = "email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(139, 241);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(26, 15);
            label6.TabIndex = 12;
            label6.Text = "city";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(139, 292);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(44, 15);
            label7.TabIndex = 13;
            label7.Text = "gender";
            // 
            // SignUpButton
            // 
            SignUpButton.Location = new System.Drawing.Point(218, 329);
            SignUpButton.Name = "SignUpButton";
            SignUpButton.Size = new System.Drawing.Size(262, 28);
            SignUpButton.TabIndex = 14;
            SignUpButton.Text = "Sign up";
            SignUpButton.UseVisualStyleBackColor = true;
            SignUpButton.Click += SignUpButton_Click;
            // 
            // LogInButton
            // 
            LogInButton.Location = new System.Drawing.Point(218, 363);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new System.Drawing.Size(262, 28);
            LogInButton.TabIndex = 15;
            LogInButton.Text = "Log in";
            LogInButton.UseVisualStyleBackColor = true;
            LogInButton.Click += LogInButton_Click_1;
            // 
            // SignUpWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 422);
            Controls.Add(LogInButton);
            Controls.Add(SignUpButton);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GenderComboBox);
            Controls.Add(CityComboBox);
            Controls.Add(EmailTextBox);
            Controls.Add(LastNameTextBox);
            Controls.Add(FirstNameTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserNameTextBox);
            Name = "SignUpWindow";
            Text = "SignUpForm";
            FormClosed += SignUpWindow_FormClosed;
            Load += SignUpWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.ComboBox CityComboBox;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Button LogInButton;
    }
}