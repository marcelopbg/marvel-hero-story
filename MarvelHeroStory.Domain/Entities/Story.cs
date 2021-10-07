using System.Collections.Generic;

namespace MarvelHeroStory.Domain.Entities
{
    public class Story
    {
        public string AttributionText { get; set; }
        public string Description { get; set; }
        public IEnumerable<Character> Characters { get; set; }
    }
}
