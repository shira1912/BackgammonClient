namespace BackgammonClient.Forms
{
    partial class CaptchaCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblCountdown = new System.Windows.Forms.Label();
            captchaImageLabel = new System.Windows.Forms.Label();
            progressBar = new System.Windows.Forms.ProgressBar();
            userInputT = new System.Windows.Forms.TextBox();
            skipCaptcha = new System.Windows.Forms.Button();
            checkButton = new System.Windows.Forms.Button();
            countdownTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblCountdown
            // 
            lblCountdown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCountdown.Location = new System.Drawing.Point(80, 66);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new System.Drawing.Size(115, 34);
            lblCountdown.TabIndex = 11;
            lblCountdown.Text = "00:00:00";
            lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // captchaImageLabel
            // 
            captchaImageLabel.Location = new System.Drawing.Point(29, 57);
            captchaImageLabel.Name = "captchaImageLabel";
            captchaImageLabel.Size = new System.Drawing.Size(213, 57);
            captchaImageLabel.TabIndex = 10;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(29, 57);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(213, 53);
            progressBar.TabIndex = 9;
            // 
            // userInputT
            // 
            userInputT.Location = new System.Drawing.Point(48, 128);
            userInputT.Name = "userInputT";
            userInputT.Size = new System.Drawing.Size(166, 23);
            userInputT.TabIndex = 8;
            // 
            // skipCaptcha
            // 
            skipCaptcha.Location = new System.Drawing.Point(94, 186);
            skipCaptcha.Name = "skipCaptcha";
            skipCaptcha.Size = new System.Drawing.Size(75, 23);
            skipCaptcha.TabIndex = 7;
            skipCaptcha.Text = "skip";
            skipCaptcha.UseVisualStyleBackColor = true;
            // 
            // checkButton
            // 
            checkButton.Location = new System.Drawing.Point(94, 157);
            checkButton.Name = "checkButton";
            checkButton.Size = new System.Drawing.Size(75, 23);
            checkButton.TabIndex = 6;
            checkButton.Text = "Check";
            checkButton.UseVisualStyleBackColor = true;
            checkButton.Click += checkButton_Click;
            // 
            // countdownTimer
            // 
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += countdownTimer_Tick;
            // 
            // CaptchaCard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lblCountdown);
            Controls.Add(captchaImageLabel);
            Controls.Add(progressBar);
            Controls.Add(userInputT);
            Controls.Add(skipCaptcha);
            Controls.Add(checkButton);
            Name = "CaptchaCard";
            Size = new System.Drawing.Size(266, 238);
            Load += CaptchaCard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label captchaImageLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox userInputT;
        private System.Windows.Forms.Button skipCaptcha;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Timer countdownTimer;
    }
}
