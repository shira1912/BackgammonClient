﻿namespace BackgammonClient
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
            label3 = new System.Windows.Forms.Label();
            ForgotPassLinkL = new System.Windows.Forms.LinkLabel();
            forgotPassEmailT = new System.Windows.Forms.TextBox();
            sendFPEmailB = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.BackColor = System.Drawing.SystemColors.Window;
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
            LogInButton.BackColor = System.Drawing.Color.SaddleBrown;
            LogInButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            LogInButton.ForeColor = System.Drawing.Color.Tan;
            LogInButton.Location = new System.Drawing.Point(196, 208);
            LogInButton.Name = "LogInButton";
            LogInButton.Size = new System.Drawing.Size(262, 28);
            LogInButton.TabIndex = 2;
            LogInButton.Text = "LOG IN";
            LogInButton.UseVisualStyleBackColor = false;
            LogInButton.Click += LogInButton_Click;
            // 
            // SignUpButton
            // 
            SignUpButton.BackColor = System.Drawing.Color.SaddleBrown;
            SignUpButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SignUpButton.ForeColor = System.Drawing.Color.Tan;
            SignUpButton.Location = new System.Drawing.Point(196, 249);
            SignUpButton.Name = "SignUpButton";
            SignUpButton.Size = new System.Drawing.Size(262, 28);
            SignUpButton.TabIndex = 3;
            SignUpButton.Text = "SIGN UP";
            SignUpButton.UseVisualStyleBackColor = false;
            SignUpButton.Click += SignUpButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.SaddleBrown;
            label1.Location = new System.Drawing.Point(117, 119);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 15);
            label1.TabIndex = 4;
            label1.Text = "USERNAME";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.SaddleBrown;
            label2.Location = new System.Drawing.Point(117, 157);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 15);
            label2.TabIndex = 5;
            label2.Text = "PASSWORD";
            // 
            // SkipButton
            // 
            SkipButton.BackColor = System.Drawing.Color.SaddleBrown;
            SkipButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SkipButton.ForeColor = System.Drawing.Color.Tan;
            SkipButton.Location = new System.Drawing.Point(573, 325);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new System.Drawing.Size(75, 23);
            SkipButton.TabIndex = 6;
            SkipButton.Text = "SKIP";
            SkipButton.UseVisualStyleBackColor = false;
            SkipButton.Click += SkipButton_Click;
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.ForeColor = System.Drawing.Color.SaddleBrown;
            checkBox.Location = new System.Drawing.Point(196, 283);
            checkBox.Name = "checkBox";
            checkBox.Size = new System.Drawing.Size(105, 19);
            checkBox.TabIndex = 7;
            checkBox.Text = "I'm not a robot";
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Bell MT", 48F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.SaddleBrown;
            label3.Location = new System.Drawing.Point(202, 39);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(248, 74);
            label3.TabIndex = 8;
            label3.Text = "שש-בש";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForgotPassLinkL
            // 
            ForgotPassLinkL.AutoSize = true;
            ForgotPassLinkL.LinkColor = System.Drawing.Color.SaddleBrown;
            ForgotPassLinkL.Location = new System.Drawing.Point(198, 185);
            ForgotPassLinkL.Name = "ForgotPassLinkL";
            ForgotPassLinkL.Size = new System.Drawing.Size(100, 15);
            ForgotPassLinkL.TabIndex = 9;
            ForgotPassLinkL.TabStop = true;
            ForgotPassLinkL.Text = "Forgot Password?";
            ForgotPassLinkL.LinkClicked += ForgotPassLinkL_LinkClicked;
            // 
            // forgotPassEmailT
            // 
            forgotPassEmailT.Location = new System.Drawing.Point(304, 182);
            forgotPassEmailT.Name = "forgotPassEmailT";
            forgotPassEmailT.Size = new System.Drawing.Size(100, 23);
            forgotPassEmailT.TabIndex = 10;
            // 
            // sendFPEmailB
            // 
            sendFPEmailB.BackColor = System.Drawing.Color.SaddleBrown;
            sendFPEmailB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            sendFPEmailB.ForeColor = System.Drawing.Color.Tan;
            sendFPEmailB.Location = new System.Drawing.Point(410, 182);
            sendFPEmailB.Name = "sendFPEmailB";
            sendFPEmailB.Size = new System.Drawing.Size(49, 23);
            sendFPEmailB.TabIndex = 11;
            sendFPEmailB.Text = "send";
            sendFPEmailB.UseVisualStyleBackColor = false;
            sendFPEmailB.Click += sendFPEmailB_Click;
            // 
            // LogInWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Tan;
            ClientSize = new System.Drawing.Size(700, 422);
            Controls.Add(sendFPEmailB);
            Controls.Add(forgotPassEmailT);
            Controls.Add(ForgotPassLinkL);
            Controls.Add(label3);
            Controls.Add(checkBox);
            Controls.Add(SkipButton);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(SignUpButton);
            Controls.Add(LogInButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserNameTextBox);
            Name = "LogInWindow";
            Text = "LOG IN";
            FormClosed += LogInWindow_FormClosed;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel ForgotPassLinkL;
        private System.Windows.Forms.TextBox forgotPassEmailT;
        private System.Windows.Forms.Button sendFPEmailB;
    }
}

