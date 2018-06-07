using BuildSchool.PasswordValidationTool.Abstracts;
using System;
using System.Text;

namespace BuildSchool.PasswordValidationTool.Implementation.PasswordRules
{
    public class LowComplexityPasswordRule : IPasswordRule
    {
        private const int LeastLength = 6;
        private const string PasswordCharBase = "23456789abcdefghjkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";

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
            return password.Length >= LeastLength;
        }
    }
}
