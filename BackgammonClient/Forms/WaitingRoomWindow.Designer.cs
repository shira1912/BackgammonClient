﻿namespace BackgammonClient.Forms
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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(331, 192);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(153, 29);
            button1.TabIndex = 0;
            button1.Text = "search for game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // WaitingRoomWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(button1);
            Name = "WaitingRoomWindow";
            Text = "WaitingRoomWindow";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1;
    }
}