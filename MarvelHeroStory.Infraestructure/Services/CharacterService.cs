using MarvelHeroStory.ApplicationCore.Dtos;
using MarvelHeroStory.ApplicationCore.Interfaces;
using MarvelHeroStory.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarvelHeroStory.Infraestructure.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHashGeneratorService _hashGeneratorService;
        public CharacterService(HttpClient httpClient, IConfiguration configuration, IHashGeneratorService hashGeneratorService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _hashGeneratorService = hashGeneratorService;
        }

        public async Task<Character> GetCharacter(string characterApiURL)
        {
            string ts = DateTime.Now.Ticks.ToString();
            string publicKey = _configuration["MarvelAPI:PublicKey"];
            string privateKey = _configuration["MarvelAPI:PrivateKey"];
            string hash = _hashGeneratorService.GenerateHash(ts, publicKey, privateKey);
            var response = await _httpClient.GetAsync($"{characterApiURL}?ts={ts}&apikey={publicKey}&hash={hash}");
            var responseStream = await response.Content.ReadAsStreamAsync();
            var characterDTO = await JsonSerializer.DeserializeAsync<CharacterDTO>(responseStream);
            var first = characterDTO.data.results.First();
            var character = new Character()
            {
                Name = first.name,
                ImageUrl = $"{first.thumbnail.path}.{first.thumbnail.extension}"
            };
            return character;
        }
    }
}
