using System.Linq;

namespace BackgammonClient.Utils
{
    public static  class LogInLegitimacyCheckingUtils
    {
        private const int k_MinimalUsernameLength = 6;
        private const int k_MinimalDomainPartLength = 2;
        private const char AT_SYMBOL = '@';
        private const char DOT_SYMBOL = '.';
        private const int k_MinimalNameLength = 2;
        private const int MIN_PASSWORD_LENGTH = 8;

        public static string IsUserNameAndPasswordLegitimate(string username, string password)
        {
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(username))
            {
                ErrorMessage += "Username cannot be empty.\n";
            }
            else if (username.Length < k_MinimalUsernameLength)
            {
                ErrorMessage += $"Username must be at least {k_MinimalUsernameLength} characters long.\n";
            }

            if (string.IsNullOrEmpty(password))
            {
                ErrorMessage += "Password cannot be empty.\n";
            }
            else
            {
                string passwordError = IsPasswordStrongEnough(password);
                if (!string.IsNullOrEmpty(passwordError))
                {
                    ErrorMessage += passwordError + "\n";
                }
            }

            return ErrorMessage.Trim();
        }


        public static string IsAllFieldsFull(string username, string password, string firstName, string lastName, string email, string city, string gender)
        {
            string ErrorMessage = "";

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(gender))
            {
                ErrorMessage += "All fields must be filled.\n";
            }

            if (firstName.Length < k_MinimalNameLength || lastName.Length < k_MinimalNameLength)
            {
                ErrorMessage += "First name and last name must be two or more characters long.\n";
            }

            string passwordError = IsPasswordStrongEnough(password);
            if (!string.IsNullOrEmpty(passwordError))
            {
                ErrorMessage += passwordError + "\n";
            }

            string emailError = IsEmailOk(email);
            if (!string.IsNullOrEmpty(emailError))
            {
                ErrorMessage += emailError + "\n";
            }

            return ErrorMessage.Trim();
        }


        private static string IsPasswordStrongEnough(string password)
        {
            string ErrorMessage = "";

            if (password.Length < MIN_PASSWORD_LENGTH)
            {
                ErrorMessage += "Password must be at least " + MIN_PASSWORD_LENGTH + " characters long.\n";
            }

            if (!password.Any(char.IsUpper))
            {
                ErrorMessage += "Password must contain at least one uppercase letter.\n";
            }

            if (!password.Any(char.IsLower))
            {
                ErrorMessage += "Password must contain at least one lowercase letter.\n";
            }

            if (!password.Any(char.IsDigit))
            {
                ErrorMessage += "Password must contain at least one digit.\n";
            }

            return ErrorMessage.Trim();
        }


        private static string IsEmailOk(string email)
        {
            string ErrorMessage = "";

            if (!email.Contains(AT_SYMBOL))
            {
                ErrorMessage += "Email is missing '@' symbol.\n";
            }
            else
            {
                string[] AtSeparation = email.Split(AT_SYMBOL);

                if (AtSeparation[0].Length < k_MinimalUsernameLength)
                {
                    ErrorMessage += "Username portion of email is too short.\n";
                }
                if (!AtSeparation[1].Contains(DOT_SYMBOL))
                {
                    ErrorMessage += "Domain portion of email is missing '.' symbol.\n";
                }
                else
                {
                    string[] DotSeparation = AtSeparation[1].Split(DOT_SYMBOL);
                    if (DotSeparation[0].Length < k_MinimalDomainPartLength || DotSeparation[1].Length < k_MinimalDomainPartLength)
                    {
                        ErrorMessage += "Invalid domain format.\n";
                    }
                }
            }
            return ErrorMessage.Trim();
        }
    }
}
