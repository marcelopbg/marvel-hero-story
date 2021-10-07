using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelHeroStory.ApplicationCore.Interfaces
{
    public interface IHashGeneratorService
    {
        string GenerateHash(string ts, string publicKey, string privateKey);
    }
}
