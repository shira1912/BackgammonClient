using BackgammonClient.Objects;
using BackgammonClient.Properties;
using DataProtocols;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackgammonClient.Forms
{
    public partial class GameWindow : Form
    {

        private Button[] slotsButtons = new Button[24];

        private int[] WhitediscsPlaces = new int[15];
        private Button[] discsButtons = new Button[24];

        private Disc[] discs = new Disc[30];
        //private int slotOfDiscId;
        private Disc selectedDisc;
        private int selectedDiscId;

        int usedCubesAmount = 0;
        private int movesRemaining = 0;

        private int[] Blackdiscs = new int[15];

        private Slot[] slots = new Slot[24];
        private int color;
        private int cube1, cube2, usedCube;
        private int selectedSlot;

        public event Action OnSwitchTurn;
        public event Action<string> sendMessage;
        private Color[] discsColor = [System.Drawing.SystemColors.ButtonHighlight, System.Drawing.SystemColors.ActiveCaptionText];

        private delegate void delSwitchTurn(bool turn);
        private delegate void delUpdateBoard(string state);
        public GameWindow(int color)
        {
            InitializeComponent();
            this.color = color;
            buildBoard();
            initialSlots();
            placeDiscs();
            initalTurn(color == 1);
         //   this.colorPictureBox.BackColor = discsColor[1];
        }

        public void switchTurn(bool turn)
        {
            this.Invoke(new delSwitchTurn(initalTurn), turn);
        }

        public bool isDone()
        {
            return false;
        }
        public void updateBoard(string state)
        {
            this.Invoke(new delUpdateBoard(stateChanged), state);
        }

        public void initalTurn(bool turn)
        {
            disableButtons(turn);
            if (turn)
            {
                this.turnLabel.Text = "It's your turn";
            }
            else
            {
                this.turnLabel.Text = "It's not your turn";
            }
        }

        //public void initialWhiteDisks()
        //{
        //    this.WhitedisksPlaces = [5, 5, 5, 5, 5, 7, 7, 7, 12, 12, 12, 12, 12, 23, 23];
        //}

        public void initialSlots()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new Slot(0, 0);
            }
            slots[0] = new Slot(2, 2);
            slots[5] = new Slot(5, 1);
            slots[7] = new Slot(3, 1);
            slots[11] = new Slot(5, 2);
            slots[12] = new Slot(5, 1);
            slots[16] = new Slot(3, 2);
            slots[18] = new Slot(5, 2);
            slots[23] = new Slot(2, 1);
        }

        public void disableButtons(bool turn)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                this.slotsButtons[i].Enabled = false;

            }

            roll.Enabled = turn;
            doneButton.Enabled = turn;

            for (int i = 0; i < this.discsButtons.Length; i++)
            {
                if (discsButtons[i] != null)
                {

                    this.discsButtons[i].Enabled = turn;
                }
            }
        }

        public void initialBoard()
        {
            for (int i = 0; i < discsButtons.Length; i++)
            {
                if (discsButtons[i] != null)
                {
                    this.Controls.Remove(discsButtons[i]);
                    discsButtons[i].Dispose();
                    discsButtons[i] = null;
                }
            }


        }

        public void stateChanged(string state)
        {
            string[] slotsString = state.Split(';');

            for (int i = 0; i < slotsString.Length; i++)
            {
                string[] slot = slotsString[i].Split(':');
                slots[i].setColor(Int32.Parse(slot[0]));
                slots[i].setQuantity(Int32.Parse(slot[1]));
            }
            placeDiscs();
        }
        public void placeDiscs()
        {
            initialBoard();
            int counter = 0;
            for (int i = 0; i < slots.Length; i++)
            {
                for (int j = 0; j < slots[i].getQuantity(); j++)
                {
                    this.discsButtons[i] = new Button();

                    Point location = this.slotsButtons[i].Location;
                    if (i > (slots.Length / 2) - 1)
                    {
                        this.discsButtons[i].Location = new System.Drawing.Point(location.X + 10, location.Y - (j * 30) + 120);
                    }

                    else
                    {
                        this.discsButtons[i].Location = new System.Drawing.Point(location.X + 10, location.Y + (j * 30));

                    }
                    if (slots[i].getColor() == 1)
                    {
                        this.discsButtons[i].BackColor = discsColor[0]; //white
                        this.discsButtons[i].Name = counter.ToString();
                    }
                    else
                    {
                        this.discsButtons[i].BackColor = discsColor[1]; //black
                        this.discsButtons[i].Name = counter.ToString();

                    }

                    //this.discsButtons[i].Enabled = (discsButtons[i].BackColor == discsColor[this.color]);
                    //this.discs[i].Name = "disc" + (i + 1);
                    this.discsButtons[i].Size = new System.Drawing.Size(30, 30);
                    this.discsButtons[i].TabIndex = 36;
                    this.discsButtons[i].TabStop = false;

                    this.discsButtons[i].Click += new System.EventHandler(this.showAvailableSlots);
                    this.Controls.Add(this.discsButtons[i]);
                    this.discsButtons[i].BringToFront();

                    this.discs[counter] = new Disc(i);
                    counter++;
                    //this.Controls.SetChildIndex(this.disks[i], 1);
                }

            }
        }

        public void showAvailableSlots(object sender, EventArgs e)
        {

            int selectedDiscId = int.Parse(((Button)sender).Name);
            //   selectedDisc = discs[selectedDiscId];
            Color selectedDiscColor = ((Button)sender).BackColor;

            int slot = discs[selectedDiscId].getSlotId();
            int slot1 = -1;
            int slot2 = -1;


            bool useCube1 = usedCube != cube1;
            bool useCube2 = usedCube != cube2;
            if (selectedDiscColor == discsColor[1]) //black
            {
                if (useCube1 && slot + cube1 < this.slotsButtons.Length)
                    slot1 = slot + cube1;

                if (useCube2 && slot + cube2 < this.slotsButtons.Length)
                    slot2 = slot + cube2;
            }
            else
            {
                if (useCube1 && slot - cube1 >= 0)
                    slot1 = slot - cube1;

                if (useCube2 && slot - cube2 >= 0)
                    slot2 = slot - cube2;
            }

            //Only enable if the slot was calculated
            if (slot1 != -1)
                enableValidSlot(slot1);
            if (slot2 != -1)
                enableValidSlot(slot2);

            this.selectedSlot = slot;



        }

        public void enableValidSlot(int slotId)
        {
            if (slots[slotId].getColor() == this.color || slots[slotId].getQuantity() <= 1)
            {
                this.slotsButtons[slotId].Enabled = true;
            }
        }

        public void buildBoard()
        {
            placeSlotsTop();
            placeSlotsBottom();
            if (this.color == 1)
            {
                this.colorPictureBox.BackColor = discsColor[0];
            }

            else if (this.color == 2)
            {
                this.colorPictureBox.BackColor = discsColor[1];
            }
        }

        public void SlotClick(object sender, EventArgs e)
        {
            string[] selectedSlotName = ((Button)sender).Name.Split(',');
            int selectedSlotId = int.Parse(selectedSlotName[1]);
            slots[selectedSlot].setQuantity(slots[selectedSlot].getQuantity() - 1);
            slots[selectedSlotId].setQuantity(slots[selectedSlotId].getQuantity() + 1);
            slots[selectedSlotId].setColor(this.color);

            int diff = Math.Abs(selectedSlotId - selectedSlot);

            if (diff == cube1 || diff == cube2)
            {
                usedCube = diff;
            }

            usedCubesAmount++;
            movesRemaining--;
            // if (usedCubesAmount >= 2 || (cube1 == 0 && cube2 == 0))

            // Reset selection
            selectedDisc = null;
            usedCube = 0;

            if (movesRemaining <= 0)
            {
                this.OnSwitchTurn?.Invoke();
            }
            disableUsedCube();
            sendState();
        }

        public void disableUsedCube()
        {
            for (int i = 0; i < slotsButtons.Length; i++)
            {
                slotsButtons[i].Enabled = false;
            }

            if (usedCube == 0) return;

            if (selectedDisc == null) return;

            int slot = selectedDisc.getSlotId();
            int remainingMove = (usedCube == cube1) ? cube2 : cube1;

            int slotTarget1 = -1;

            if (this.color == 1) // white
            {
                if (slot - remainingMove >= 0)
                    slotTarget1 = slot - remainingMove;
            }
            else // black
            {
                if (slot + remainingMove < slotsButtons.Length)
                    slotTarget1 = slot + remainingMove;
            }

            if (slotTarget1 != -1)
                enableValidSlot(slotTarget1);
        }


        public void sendState()
        {
            string[] slotsString = new string[slots.Length];
            for (int i = 0; i < slots.Length; i++)
            {
                slotsString[i] = slots[i].toString();
            }
            sendMessage("State," + string.Join(";", slotsString));
        }



        private void rollTheDice_click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            cube1 = rnd.Next(1, 7);
            cube2 = rnd.Next(1, 7);

            if (cube1 == cube2)
            {
                movesRemaining = 4;
            }
            else
            {
                movesRemaining = 2;
            }
            setCubePicture(cube1, 1);
            setCubePicture(cube2, 2);

            this.roll.Enabled = false;

        }


        private void doneButton_Click(object sender, EventArgs e)
        {
            this.OnSwitchTurn?.Invoke();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        public void placeSlotsTop()
        {
            int x = 700;
            int y = 10;
            for (int i = 0; i < slotsButtons.Length / 2; i++)
            {
                this.slotsButtons[i] = new Button();

                this.slotsButtons[i].Location = new System.Drawing.Point(x, y);
                this.slotsButtons[i].Name = "slot," + (i);
                this.slotsButtons[i].Size = new System.Drawing.Size(50, 150);
                this.slotsButtons[i].TabIndex = 36;
                this.slotsButtons[i].TabStop = false;
                this.slotsButtons[i].Enabled = false;
                this.slotsButtons[i].Click += new System.EventHandler(this.SlotClick);
                this.Controls.Add(this.slotsButtons[i]);
                this.slotsButtons[i].SendToBack();

                if ((i + 1) % (slotsButtons.Length / 4) == 0 && i != 0 && i != slotsButtons.Length / 2 - 1)
                {
                    x -= 50;
                }
                x -= 50;
            }
        }

        public void placeSlotsBottom()
        {
            int y = 285;
            int x = 100;
            for (int i = slotsButtons.GetLength(0) / 2; i < slotsButtons.Length; i++)
            {
                this.slotsButtons[i] = new Button();

                this.slotsButtons[i].Location = new System.Drawing.Point(x, y);
                this.slotsButtons[i].Name = "slot," + (i);
                this.slotsButtons[i].Size = new System.Drawing.Size(50, 153);
                this.slotsButtons[i].TabIndex = 36;
                this.slotsButtons[i].TabStop = false;
                this.slotsButtons[i].Click += new System.EventHandler(this.SlotClick);
                this.Controls.Add(this.slotsButtons[i]);
                this.slotsButtons[i].SendToBack();

                if ((i + 1) % (slotsButtons.Length / 4) == 0 && i != 0)
                {
                    x += 50;
                }

                x += 50;
            }
            x = 50;
        }

        public void setCubePicture(int cube, int cubeNum)
        {

            if (cubeNum == 1)
            {
                switch (cube)
                {
                    case 1:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/one.png");
                            break;
                        }

                    case 2:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/two.jpg");
                            break;
                        }

                    case 3:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/three.jpg");
                            break;
                        }

                    case 4:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/four.jpg");
                            break;
                        }

                    case 5:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/five.jpg");
                            break;
                        }

                    case 6:
                        {
                            pictureBox1.Image = Image.FromFile(@"../../../cubeImages/six.jpg");
                            break;
                        }
                }
            }

            else if (cubeNum == 2)
            {
                switch (cube)
                {
                    case 1:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/one.png");
                            break;
                        }

                    case 2:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/two.jpg");
                            break;
                        }

                    case 3:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/three.jpg");
                            break;
                        }

                    case 4:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/four.jpg");
                            break;
                        }

                    case 5:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/five.jpg");
                            break;
                        }

                    case 6:
                        {
                            pictureBox2.Image = Image.FromFile(@"../../../cubeImages/six.jpg");
                            break;
                        }
                        //pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "Resources/" +cube1.ToString()+".jpg");
                        //pictureBox2.Image = Image.FromFile(Environment.CurrentDirectory + "Resources/" + cube2.ToString() + ".jpg");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
