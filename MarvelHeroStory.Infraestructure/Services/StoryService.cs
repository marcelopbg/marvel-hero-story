using MarvelHeroStory.ApplicationCore.Dtos;
using MarvelHeroStory.ApplicationCore.Interfaces;
using MarvelHeroStory.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarvelHeroStory.Infraestructure.Services
{
    public class StoryService : IStoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHashGeneratorService _hashGeneratorService;
        private readonly ICharacterService _characterService;

        public StoryService(HttpClient httpClient, IConfiguration configuration, IHashGeneratorService hashGeneratorService, ICharacterService characterService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _hashGeneratorService = hashGeneratorService;
            _characterService = characterService;

        }
        public async Task<Story> GetStory()
        {
            string ts = DateTime.Now.Ticks.ToString();
            string publicKey = _configuration["MarvelAPI:PublicKey"];
            string privateKey = _configuration["MarvelAPI:PrivateKey"];
            string hash = _hashGeneratorService.GenerateHash(ts, publicKey, privateKey);
            string url = _configuration["MarvelAPI:BaseUrl"];
            var storyId = _configuration["MarvelAPI:StoryId"];
            var response = await _httpClient.GetAsync($"{url}/stories/{storyId}?ts={ts}&apikey={publicKey}&hash={hash}");
            var responseStream = await response.Content.ReadAsStreamAsync();
            var storyDTO = await JsonSerializer.DeserializeAsync<StoryDTO>(responseStream);
            var storyCharactersDTO = storyDTO.data.results.First().characters.items;
            List<Character> storyCharacters = new();
            foreach (var characterData in storyCharactersDTO)
            {
                var character = await _characterService.GetCharacter(characterData.resourceURI);
                storyCharacters.Add(character);
            }
            var story = new Story()
            {
                Description = storyDTO.data.results.First().description,
                AttributionText = storyDTO.attributionText,
                Characters = storyCharacters
            };
            return story;
        }
    }
}
