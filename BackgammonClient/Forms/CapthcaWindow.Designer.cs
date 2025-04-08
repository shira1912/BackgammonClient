namespace BackgammonClient.Forms
{
    partial class CapthcaWindow
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
            components = new System.ComponentModel.Container();
            countdownTimer = new System.Windows.Forms.Timer(components);
            checkButton = new System.Windows.Forms.Button();
            skipCaptcha = new System.Windows.Forms.Button();
            userInputT = new System.Windows.Forms.TextBox();
            progressBar = new System.Windows.Forms.ProgressBar();
            captchaImageLabel = new System.Windows.Forms.Label();
            lblCountdown = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // checkButton
            // 
            checkButton.Location = new System.Drawing.Point(50, 120);
            checkButton.Name = "checkButton";
            checkButton.Size = new System.Drawing.Size(75, 23);
            checkButton.TabIndex = 0;
            checkButton.Text = "Check";
            checkButton.UseVisualStyleBackColor = true;
            // 
            // skipCaptcha
            // 
            skipCaptcha.Location = new System.Drawing.Point(179, 120);
            skipCaptcha.Name = "skipCaptcha";
            skipCaptcha.Size = new System.Drawing.Size(75, 23);
            skipCaptcha.TabIndex = 1;
            skipCaptcha.Text = "skip";
            skipCaptcha.UseVisualStyleBackColor = true;
            // 
            // userInputT
            // 
            userInputT.Location = new System.Drawing.Point(50, 91);
            userInputT.Name = "userInputT";
            userInputT.Size = new System.Drawing.Size(100, 23);
            userInputT.TabIndex = 2;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(50, 20);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(213, 53);
            progressBar.TabIndex = 3;
            progressBar.Click += progressBar1_Click;
            // 
            // captchaImageLabel
            // 
            captchaImageLabel.Location = new System.Drawing.Point(50, 20);
            captchaImageLabel.Name = "captchaImageLabel";
            captchaImageLabel.Size = new System.Drawing.Size(213, 57);
            captchaImageLabel.TabIndex = 4;
            // 
            // lblCountdown
            // 
            lblCountdown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCountdown.Location = new System.Drawing.Point(101, 29);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new System.Drawing.Size(115, 34);
            lblCountdown.TabIndex = 5;
            lblCountdown.Text = "00:00:00";
            lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CapthcaWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(307, 184);
            Controls.Add(lblCountdown);
            Controls.Add(captchaImageLabel);
            Controls.Add(progressBar);
            Controls.Add(userInputT);
            Controls.Add(skipCaptcha);
            Controls.Add(checkButton);
            Name = "CapthcaWindow";
            Text = "Capthca";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button skipCaptcha;
        private System.Windows.Forms.TextBox userInputT;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label captchaImageLabel;
        private System.Windows.Forms.Label lblCountdown;
    }
}