namespace BuildSchool.PasswordValidationTool.Client
{
    public interface IPasswordValidationService
    {
        byte[] HashPassword(byte[] pwd, byte[] salt);
        bool ValidatePassword(string pwd, byte[] pwdToCheck, byte[] salt);
        string GeneratePassword();
    }
}
