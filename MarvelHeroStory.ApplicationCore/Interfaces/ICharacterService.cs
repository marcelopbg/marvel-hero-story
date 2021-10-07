using MarvelHeroStory.Domain.Entities;
using System.Threading.Tasks;

namespace MarvelHeroStory.ApplicationCore.Interfaces
{
    public interface ICharacterService
    {
        Task<Character> GetCharacter(string characterApiURL);
    }
}
