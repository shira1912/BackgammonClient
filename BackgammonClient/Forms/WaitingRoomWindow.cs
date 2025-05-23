﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgammonClient.Forms
{
    public partial class WaitingRoomWindow : Form
    {
        public event Action OnStartSearchingForGame;

        public WaitingRoomWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnStartSearchingForGame?.Invoke();
            this.button1.Enabled = false;
        }

        public void changeWaitingLabel()
        {
            this.waitingLabel.Text = "Waiting for another player...";
        }

        public void ShowMessageInMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        private void WaitingRoomWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
