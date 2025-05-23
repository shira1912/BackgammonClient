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
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.SaddleBrown;
            button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            button1.ForeColor = System.Drawing.Color.Tan;
            button1.Location = new System.Drawing.Point(274, 180);
            button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 50);
            button1.TabIndex = 0;
            button1.Text = "SEARCH FOR GAME";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // waitingLabel
            // 
            waitingLabel.AutoSize = true;
            waitingLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            waitingLabel.Location = new System.Drawing.Point(227, 276);
            waitingLabel.Name = "waitingLabel";
            waitingLabel.Size = new System.Drawing.Size(0, 25);
            waitingLabel.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Bell MT", 24F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.SaddleBrown;
            label3.Location = new System.Drawing.Point(563, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(125, 37);
            label3.TabIndex = 9;
            label3.Text = "שש-בש";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Tan;
            label1.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(190, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(341, 53);
            label1.TabIndex = 10;
            label1.Text = "WAITING ROOM";
            // 
            // WaitingRoomWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Tan;
            ClientSize = new System.Drawing.Size(700, 422);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(waitingLabel);
            Controls.Add(button1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "WaitingRoomWindow";
            Text = "WAITING ROOM";
            FormClosed += WaitingRoomWindow_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label waitingLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}