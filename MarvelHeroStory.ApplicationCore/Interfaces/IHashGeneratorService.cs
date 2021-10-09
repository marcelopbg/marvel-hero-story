namespace MarvelHeroStory.ApplicationCore.Interfaces
{
    public interface IHashGeneratorService
    {
        string GenerateHash(string ts, string publicKey, string privateKey);
    }
}
