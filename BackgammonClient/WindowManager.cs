using BackgammonClient.Forms;
using LogInClient.Network;
using Microsoft.VisualBasic.Logging;
using System;
using System.Windows;
using System.Windows.Forms;

namespace BackgammonClient
{
    internal class WindowManager
    {
        private LogInWindow _logInWindow;
        private SignUpWindow _signUpWindow;
        private SecureNetworkManager _encryptedCommunication;
        private WaitingRoomWindow _waitingRoomWindow;
        private GameWindow _GameWindow;
        private int playerId;

        public WindowManager()
        {
            _logInWindow = new LogInWindow();
            _signUpWindow = new SignUpWindow();
            _waitingRoomWindow = new WaitingRoomWindow();

            _encryptedCommunication = new SecureNetworkManager();
            _encryptedCommunication.Connect();

            _encryptedCommunication.OnMessageReceive += OnMessageReceive;

            _logInWindow.OnLogIn += sendMessage;
            _logInWindow.OnSwitchWindowToSignUp += OnSwitchWindowToSignUp;

            _signUpWindow.OnSignUp += signUp;
            _signUpWindow.OnSwitchWindowToLogIn += OnSwitchWindowToLogIn;

            _waitingRoomWindow.OnStartSearchingForGame += SearchForGame;

            _logInWindow.Show();
        }

        private void sendMessage(string message)
        {
            _encryptedCommunication.SendMessage(message);
        }

        private void SearchForGame()
        {
            _encryptedCommunication.SendMessage("InSearchForGame,");
        }

        private void SwitchTurn()
        {
            _encryptedCommunication.SendMessage("SwitchTurn,"+this.playerId.ToString());
        }
        private void OnSwitchWindowToSignUp()
        {
            _logInWindow?.Hide();
            _signUpWindow?.Show();
        }

        private void signUp(string message)
        {
            _encryptedCommunication.SendMessage(message);
        }

        private void OnSwitchWindowToLogIn()
        {
            _signUpWindow?.Hide();
            _logInWindow?.Show();
        }

        private void OnMessageReceive(string message)
        {
            string[] splitMessage = message.Split(',');

            switch (splitMessage[0])
            {
                case "SignUp":
                    {
                        if (splitMessage[1] == "true")
                        {
                            _signUpWindow.BeginInvoke(() =>
                            {
                                _waitingRoomWindow.Show();
                                _signUpWindow.Hide();
                            });
                        }
                        else
                        {
                            _signUpWindow.ShowMessageInMessageBox("SignUp wasn't successful");
                        }
                        break;
                    }
                case "Login":
                    {
                        if (splitMessage[1] == "true")
                        {
                            _logInWindow.BeginInvoke(() => 
                            {
                                _waitingRoomWindow.Show();
                                _logInWindow.Hide();
                            });
                            
                        }
                        else
                        {
                            _signUpWindow.ShowMessageInMessageBox("Login wasn't successful");
                        }
                        break;
                    }
                case "StartGame":
                    {
                        _waitingRoomWindow.BeginInvoke(() =>
                        {
                            _waitingRoomWindow.Hide();
                            this.playerId = Int32.Parse(splitMessage[1]);

                            _GameWindow = new GameWindow(this.playerId);
                            _GameWindow.OnSwitchTurn += SwitchTurn;
                            _GameWindow.sendMessage += sendMessage;
                            _GameWindow.Show();
                        });

                        break;
                    }
                case "State":
                    {
                        _GameWindow.updateBoard(splitMessage[1]);
                        break;
                    }
                case "Wait":
                    {
                        _waitingRoomWindow.ShowMessageInMessageBox("Waiting for another player");

                        break;
                    }
                case "Turn":
                    {
                        _GameWindow.switchTurn(splitMessage[1] == this.playerId.ToString());
                        break;
                    }

                default:
                    {
                        throw new System.Exception("Unknown message");
                    }
            }
        }
    }
}
