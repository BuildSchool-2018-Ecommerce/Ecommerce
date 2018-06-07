namespace BuildSchool.PasswordValidationTool.Abstracts
{
    public interface IPasswordRule
    {
        bool Validate(string password);
        string Generate();
    }
}
