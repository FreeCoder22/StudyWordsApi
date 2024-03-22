using System;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using EnglishWords.Models;
using EnglishWordsApi.Controllers;
using EnglishWordsApi.interfaces;
using NuGet.Protocol.Core.Types;
using AutoFixture;
namespace EnglishWords.Tests
{
    [TestFixture]
    public class WordsControllerTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private Fixture _fixture;

        private readonly UsersController _controller;
        public WordsControllerTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _controller = new UsersController(_mockRepo.Object);
            _fixture = new Fixture();
        }

        [Test]
        public async Task GetAllUsers_ReturnsResult_WithListOfUsers()
        {
            Fixture fixture = new Fixture();

           var expectedResult = new List<User>
        {
            _fixture.Build<User>().Without(p => p.Words).Create(),
            _fixture.Build<User>().Without(p => p.Words).Create(),
            _fixture.Build<User>().Without(p => p.Words).Create()
        };
            _mockRepo.Setup(repo => repo.GetUsers()).ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.GetUsers();

            // Assert
            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(3, Is.EqualTo(result.Count()));
            var allNames = result.Select(user => user.Email).ToList();
            var uniqueNames = new HashSet<string>(allNames);
            Assert.That(allNames.Count, Is.EqualTo(uniqueNames.Count));
        }

        [Test]
        public async Task GetUserByEmail_ReturnsResult_WithUser()
        {
            Fixture fixture = new Fixture();

            var expectedResult = _fixture.Build<User>().Without(p => p.Words).Create();
            Assert.NotNull(expectedResult);
            if (expectedResult == null) return;
            _mockRepo.Setup(repo => repo.GetUserByEmail(expectedResult.Id)).ReturnsAsync(expectedResult); 

            // Act
            var result = await _controller.GetUserByEmail(expectedResult.Id);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Value, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task GetUserById_ReturnsResult_WithUser()
        {
            Fixture fixture = new Fixture();

            var expectedResult = _fixture.Build<User>().Without(p => p.Words).Create();
            Assert.NotNull(expectedResult);
            if (expectedResult == null) return;
            _mockRepo.Setup(repo => repo.GetUserById(expectedResult.Id)).ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.GetUserById(expectedResult.Id);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Value, Is.EqualTo(expectedResult));
        }

    }
}
