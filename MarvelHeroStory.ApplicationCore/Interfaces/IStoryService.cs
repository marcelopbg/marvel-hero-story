using MarvelHeroStory.Domain.Entities;
using System.Threading.Tasks;

namespace MarvelHeroStory.ApplicationCore.Interfaces
{
    public interface IStoryService
    {
        Task<Story> GetStory();
    }
}
