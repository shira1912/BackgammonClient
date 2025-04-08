namespace BackgammonClient
{
    partial class LogInWindow
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
            LogInButton = new System.Windows.Forms.Button();
            SignUpButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            SkipButton = new System.Windows.Forms.Button();
            checkBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new System.Drawing.Point(196, 116);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new System.Drawing.Size(263, 23);
            UserNameTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new System.Drawing.Point(196, 154);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new System.Drawing.Size(263, 23);
            PasswordTextBox.TabIndex = 1;
            // 
            // LogInButton
            // 
            LogInButton.Location = new System.Drawing.Point(196, 208);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new System.Drawing.Size(262, 28);
            LogInButton.TabIndex = 2;
            LogInButton.Text = "Log in";
            LogInButton.UseVisualStyleBackColor = true;
            LogInButton.Click += LogInButton_Click;
            // 
            // SignUpButton
            // 
            SignUpButton.Location = new System.Drawing.Point(196, 249);
            SignUpButton.Name = "SignUpButton";
            SignUpButton.Size = new System.Drawing.Size(262, 28);
            SignUpButton.TabIndex = 3;
            SignUpButton.Text = "Sign up";
            SignUpButton.UseVisualStyleBackColor = true;
            SignUpButton.Click += SignUpButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(116, 119);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "user name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(116, 154);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 15);
            label2.TabIndex = 5;
            label2.Text = "password";
            // 
            // SkipButton
            // 
            SkipButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            SkipButton.Location = new System.Drawing.Point(583, 339);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new System.Drawing.Size(75, 23);
            SkipButton.TabIndex = 6;
            SkipButton.Text = "Skip";
            SkipButton.UseVisualStyleBackColor = false;
            SkipButton.Click += SkipButton_Click;
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new System.Drawing.Point(196, 283);
            checkBox.Name = "checkBox";
            checkBox.Size = new System.Drawing.Size(105, 19);
            checkBox.TabIndex = 7;
            checkBox.Text = "I'm not a robot";
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            // 
            // LogInWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 422);
            Controls.Add(checkBox);
            Controls.Add(SkipButton);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(SignUpButton);
            Controls.Add(LogInButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserNameTextBox);
            Name = "LogInWindow";
            Text = "Form1";
            Load += LogInWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.CheckBox checkBox;
    }
}

