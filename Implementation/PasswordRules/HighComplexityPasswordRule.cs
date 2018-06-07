using BuildSchool.PasswordValidationTool.Abstracts;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BuildSchool.PasswordValidationTool.Implementation.PasswordRules
{
    public class HighComplexityPasswordRule : IPasswordRule
    {
        private const int LeastLength = 8;
        private const string PasswordCharBase = "23456789abcdefghjkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ@#$%^&!";

        public string Generate()
        {
            var random = new Random();
            var passwordBuilder = new StringBuilder();

            do
            {
                passwordBuilder.Clear();

                while (passwordBuilder.Length < LeastLength)
                {
                    var idx = random.Next(
                        0,
                        PasswordCharBase.Length - 1);
                    passwordBuilder.Append(
                        PasswordCharBase[idx]);
                }
            }
            while (!Validate(passwordBuilder.ToString()));

            return passwordBuilder.ToString();
        }

        public bool Validate(string password)
        {
            var regex = new Regex(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&!]).{8,})");
            return regex.IsMatch(password);
        }
    }
}
