using MarvelHeroStory.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MarvelHeroStory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : Controller
    {
        private readonly IStoryService _storyService;
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var story = await _storyService.GetStory();
            return Ok(story);
        }
    }
}
