namespace BackgammonClient.Forms
{
    partial class WaitingRoomWindow
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
            button1 = new System.Windows.Forms.Button();
            waitingLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(290, 144);
            button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(134, 22);
            button1.TabIndex = 0;
            button1.Text = "search for game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // waitingLabel
            // 
            waitingLabel.AutoSize = true;
            waitingLabel.Location = new System.Drawing.Point(342, 225);
            waitingLabel.Name = "waitingLabel";
            waitingLabel.Size = new System.Drawing.Size(38, 15);
            waitingLabel.TabIndex = 1;
            waitingLabel.Text = "label1";
            // 
            // WaitingRoomWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 338);
            Controls.Add(waitingLabel);
            Controls.Add(button1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "WaitingRoomWindow";
            Text = "WaitingRoomWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label waitingLabel;
    }
}