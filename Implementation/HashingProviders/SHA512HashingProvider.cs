using BuildSchool.PasswordValidationTool.Abstracts;
using System.Security.Cryptography;

namespace BuildSchool.PasswordValidationTool.Implementation.HashingProviders
{
    public class SHA512HashingProvider : IHashingProvider
    {
        public byte[] ComputeHash(byte[] data)
        {
            var provider = new SHA512CryptoServiceProvider();
            return provider.ComputeHash(data);
        }
    }
}
