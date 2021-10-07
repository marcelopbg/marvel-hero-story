namespace MarvelHeroStory.ApplicationCore.Dtos
{
    public class CharacterDTO
    {
        public CharacterDataDTO data { get; set; }
    }
    public class CharacterDataDTO
    {
        public CharacterResultDTO[] results { get; set; }
    }
    public class CharacterResultDTO
    {
        public string name { get; set; }
        public ThumbnailDTO thumbnail { get; set; }
    }
    public class ThumbnailDTO
    {
        public string path { get; set; }
        public string extension { get; set; }
    }
}
