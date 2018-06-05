namespace BuildSchool.PasswordValidationTool.Abstracts
{
    public interface IHashingProvider
    {
        byte[] ComputeHash(byte[] data);
    }
}
