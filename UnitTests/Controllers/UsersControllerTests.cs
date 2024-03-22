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
    public class UsersControllerTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private Fixture _fixture;

        private readonly UsersController _controller;
        public UsersControllerTests()
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
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedUsers = okResult.Value as List<User>;

            Assert.NotNull(okResult);
            Assert.That(returnedUsers, Is.EqualTo(expectedResult));
            Assert.That(3, Is.EqualTo(returnedUsers.Count()));
            var allNames = returnedUsers.Select(user => user.Email).ToList();
            var uniqueNames = new HashSet<string>(allNames);
            Assert.That(allNames.Count, Is.EqualTo(uniqueNames.Count));
        }


        [Test]
        public async Task GetUserByEmail_ReturnsOk_WithUser()
        {
            // Arrange
            var user = _fixture.Build<User>().Without(p => p.Words).Create();
            _mockRepo.Setup(repo => repo.GetUserByEmail(user.Email)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserByEmail(user.Email);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedUser = okResult.Value as User;
            Assert.That(user, Is.EqualTo(returnedUser));
        }

        [Test]
        public async Task GetUserById_ReturnsOk_WithUser()
        {
            // Arrange
            var user = _fixture.Build<User>().Without(p => p.Words).Create();
            _mockRepo.Setup(repo => repo.GetUserById(user.Id)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserById(user.Id);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedUser = okResult.Value as User;
            Assert.That(user, Is.EqualTo(returnedUser));

        }
    }
}
