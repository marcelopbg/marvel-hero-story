using MarvelHeroStory.ApplicationCore.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace MarvelHeroStory.Infraestructure
{
    public class HashGeneratorService : IHashGeneratorService
    {
        public string GenerateHash(string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
        Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            byte[] bytesHash = MD5.Create().ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", string.Empty);
        }
    }
}
