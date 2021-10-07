using MarvelHeroStory.ApplicationCore.Interfaces;
using MarvelHeroStory.Controllers;
using MarvelHeroStory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelHeroStory.UnitTests
{
    public class StoryServiceTests
    {
        private StoryController controller;
        private Mock<IStoryService> storyService;

        [SetUp]
        public void Setup()
        {
            storyService = new Mock<IStoryService>();
        }
        [Test]
        public async Task ShouldReturnAStory()
        {
            var story =
                new Story()
                {
                    AttributionText = "All rights reserved",
                    Description = "Cool Story Bro",
                    Characters = new List<Character>()
                {
                    new Character()
                    {
                        ImageUrl = "www.google.com",
                        Name = "Character name"
                    }
                }
                };
            // arrange
            storyService.Setup(s => s.GetStory()).Returns(Task.FromResult(story));
            controller = new StoryController(storyService.Object);

            // Act 
            var result = await controller.Get();
            var okResult = result as ObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.True(okResult is OkObjectResult);
            Assert.AreEqual(okResult.Value, story);
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}
