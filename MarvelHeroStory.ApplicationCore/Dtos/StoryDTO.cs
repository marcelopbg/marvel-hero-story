namespace MarvelHeroStory.ApplicationCore.Dtos
{
    public class StoryDTO
    {
        public string attributionText { get; set; }
        public SToryDataDTO data { get; set; }
    }

    public class SToryDataDTO
    {
        public StoryDataResultsDTO[] results { get; set; }
    }
    public class StoryDataResultsDTO
    {
        public string description { get; set; }
        public StoryCharactersDTO characters { get; set; }
    }
    public class StoryCharactersDTO
    {
        public StoryCharacterItemDTO[] items { get; set; }
    }
    public class StoryCharacterItemDTO
    {
        public string characterName { get; set; }
        public string resourceURI { get; set; }
    }
}
