namespace BuildSchool.PasswordValidationTool.Abstracts
{
    public interface ISaltStrategy
    {
        string Format(string passwordBody, string salt);
        byte[] Format(byte[] passwordData, byte[] saltData);
    }
}
