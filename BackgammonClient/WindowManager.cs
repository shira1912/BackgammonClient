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
        private int countTries = 0;
        private delegate void delWaitingLabel();


        public WindowManager()
        {
            _logInWindow = new LogInWindow();
            _signUpWindow = new SignUpWindow();
            _waitingRoomWindow = new WaitingRoomWindow();

            _encryptedCommunication = new SecureNetworkManager();
            _encryptedCommunication.Connect();

            _encryptedCommunication.OnMessageReceive += OnMessageReceive;

            _logInWindow.sendMessage += sendMessage;
            _logInWindow.OnSwitchWindowToSignUp += OnSwitchWindowToSignUp;

            _logInWindow.OnResetPassword += sendMessage;


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
            //_signUpWindow.BeginInvoke(() =>
            //{
            //   _signUpWindow.SendEmail();
            //});

        }

        private void OnSwitchWindowToLogIn()
        {
            _signUpWindow?.Hide();
            _logInWindow?.Show();
        }

        private void OnSwitchWindowToWaitingRoom()
        {
            _waitingRoomWindow = new WaitingRoomWindow();
            _waitingRoomWindow.OnStartSearchingForGame += SearchForGame;
            _GameWindow?.Hide();
            _waitingRoomWindow?.Show();
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
                                _logInWindow.Show();
                                _signUpWindow.Hide();
                            });
                        }
                        else
                        {
                            _signUpWindow.ShowMessageInMessageBox("SignUp wasn't successful, " + splitMessage[2]+ " is exist");
                        }
                        break;
                    }
                case "ValidSignUp":
                    {
                        _signUpWindow.BeginInvoke(() =>
                        {
                            _signUpWindow.checkValidEmail();
                        });
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
                            _logInWindow.BeginInvoke(() =>
                            {
                                _logInWindow.updateTries();
                            });
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
                            _GameWindow.OnSwitchWindowToWaitingRoom += OnSwitchWindowToWaitingRoom;
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
                        //     _waitingRoomWindow.ShowMessageInMessageBox("Waiting for another player");
                        _waitingRoomWindow.BeginInvoke(new Action(() => _waitingRoomWindow.changeWaitingLabel()));
                        
                            break;
                    }
                case "Turn":
                    {
                        _GameWindow.switchTurn(splitMessage[1] == this.playerId.ToString());
                        break;
                    }

                case "Dice":
                    {
                        int remoteCube1 = int.Parse(splitMessage[1]);
                        int remoteCube2 = int.Parse(splitMessage[2]);

                        this._GameWindow.BeginInvoke(new Action(() => {
                            _GameWindow.setCubePicture(remoteCube1, 1);
                            _GameWindow.setCubePicture(remoteCube2, 2);
                        }));
                        break;
                    }
                case "Win":
                    {
                        this._GameWindow.BeginInvoke(new Action(() =>
                        {
                            int playerID = int.Parse(splitMessage[1]);

                            this._GameWindow.winHandling(playerID);
                            
                        }));
                        
                    }
                    break;
                case "IsEmailExists":
                    {
                        if (splitMessage[1] == "true")
                        {
                            _logInWindow.BeginInvoke(() =>
                            {
                                _logInWindow.ShowMessageInMessageBox("An email is being sent to you.");

                                _logInWindow.sendForgotPassEmail(splitMessage[1]);
                            });
                        }
                        else
                        {
                            _logInWindow.BeginInvoke(() =>
                            {
                                _logInWindow.ShowMessageInMessageBox("Email doesn't exist in our system");
                            });
                        }
                        break;
                    }

                case "ResetPassword":
                    {
                        if (splitMessage[1] == "successful")
                        {
                            _logInWindow.BeginInvoke(() =>
                            {
                                _logInWindow.ShowMessageInMessageBox("Password has been reset successfully.");
                            });
                        }
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
