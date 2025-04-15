namespace BackgammonClient.Forms
{
    partial class EmailVerificationForm
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
            title = new System.Windows.Forms.Label();
            userInput = new System.Windows.Forms.TextBox();
            VerifyB = new System.Windows.Forms.Button();
            resetPasswordPanel = new System.Windows.Forms.Panel();
            ResetPasswordB = new System.Windows.Forms.Button();
            newPass2 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            newPass1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            resetPasswordPanel.SuspendLayout();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            title.Location = new System.Drawing.Point(71, 35);
            title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            title.Name = "title";
            title.Size = new System.Drawing.Size(286, 19);
            title.TabIndex = 0;
            title.Text = "Enter the verification code sent to your email:";
            // 
            // userInput
            // 
            userInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            userInput.Location = new System.Drawing.Point(132, 80);
            userInput.Margin = new System.Windows.Forms.Padding(2);
            userInput.Name = "userInput";
            userInput.Size = new System.Drawing.Size(177, 25);
            userInput.TabIndex = 1;
            // 
            // VerifyB
            // 
            VerifyB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            VerifyB.Location = new System.Drawing.Point(154, 131);
            VerifyB.Margin = new System.Windows.Forms.Padding(2);
            VerifyB.Name = "VerifyB";
            VerifyB.Size = new System.Drawing.Size(127, 36);
            VerifyB.TabIndex = 2;
            VerifyB.Text = "Verify";
            VerifyB.UseVisualStyleBackColor = true;
            VerifyB.Click += VerifyB_Click;
            // 
            // resetPasswordPanel
            // 
            resetPasswordPanel.Controls.Add(ResetPasswordB);
            resetPasswordPanel.Controls.Add(newPass2);
            resetPasswordPanel.Controls.Add(label2);
            resetPasswordPanel.Controls.Add(newPass1);
            resetPasswordPanel.Controls.Add(label1);
            resetPasswordPanel.Location = new System.Drawing.Point(0, 0);
            resetPasswordPanel.Margin = new System.Windows.Forms.Padding(2);
            resetPasswordPanel.Name = "resetPasswordPanel";
            resetPasswordPanel.Size = new System.Drawing.Size(446, 220);
            resetPasswordPanel.TabIndex = 3;
            // 
            // ResetPasswordB
            // 
            ResetPasswordB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ResetPasswordB.Location = new System.Drawing.Point(154, 160);
            ResetPasswordB.Margin = new System.Windows.Forms.Padding(2);
            ResetPasswordB.Name = "ResetPasswordB";
            ResetPasswordB.Size = new System.Drawing.Size(127, 36);
            ResetPasswordB.TabIndex = 6;
            ResetPasswordB.Text = "Reset Password";
            ResetPasswordB.UseVisualStyleBackColor = true;
            //ResetPasswordB.Click += ResetPasswordB_Click;
            // 
            // newPass2
            // 
            newPass2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            newPass2.Location = new System.Drawing.Point(103, 122);
            newPass2.Margin = new System.Windows.Forms.Padding(2);
            newPass2.Name = "newPass2";
            newPass2.Size = new System.Drawing.Size(230, 25);
            newPass2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            label2.Location = new System.Drawing.Point(99, 98);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(184, 19);
            label2.TabIndex = 4;
            label2.Text = "Confirm your new password:";
            // 
            // newPass1
            // 
            newPass1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            newPass1.Location = new System.Drawing.Point(103, 58);
            newPass1.Margin = new System.Windows.Forms.Padding(2);
            newPass1.Name = "newPass1";
            newPass1.Size = new System.Drawing.Size(230, 25);
            newPass1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            label1.Location = new System.Drawing.Point(99, 35);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(167, 19);
            label1.TabIndex = 2;
            label1.Text = "Enter your new password:";
            // 
            // EmailVerificationForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(446, 220);
            Controls.Add(resetPasswordPanel);
            Controls.Add(VerifyB);
            Controls.Add(userInput);
            Controls.Add(title);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "EmailVerificationForm";
            Text = "EmailVerificationForm";
            resetPasswordPanel.ResumeLayout(false);
            resetPasswordPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.Button VerifyB;
        private System.Windows.Forms.Panel resetPasswordPanel;
        private System.Windows.Forms.Button ResetPasswordB;
        private System.Windows.Forms.TextBox newPass2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newPass1;
        private System.Windows.Forms.Label label1;
    }
}