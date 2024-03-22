using System;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using EnglishWords.Models;
using EnglishWordsApi.Controllers;
using EnglishWordsApi.interfaces;
using NuGet.Protocol.Core.Types;
using AutoFixture;
using EnglishWords.Context;
namespace EnglishWords.Tests
{
    [TestFixture]
    public class WordsControllerTests
    {
        private Mock<IWordsRepository> _mockRepo;
        private Fixture _fixture;
        private WordsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IWordsRepository>();
            _controller = new WordsController(_mockRepo.Object);
            _fixture = new Fixture();
        }

        [Test]
        public async Task GetAllWords_ReturnsResult_WithListOfWords()
        {
           var words = new List<Word>
        {
            _fixture.Build<Word>().Without(w => w.User).Create(),
            _fixture.Build<Word>().Without(w => w.User).Create(),
            _fixture.Build<Word>().Without(w=> w.User).Create()
        };
            _mockRepo.Setup(repo => repo.GetWords()).ReturnsAsync(words);

            // Act
            var result = await _controller.GetWords();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedWords = okResult.Value as List<Word>;

            Assert.NotNull(okResult);
            Assert.That(returnedWords, Is.EqualTo(returnedWords));
            Assert.That(3, Is.EqualTo(returnedWords.Count()));
        }

        [Test]
        public async Task GetWordRandomByUserId_ReturnsOk_WithListOfWords()
        {
            // Arrange
            var user = _fixture.Build<User>().Without(w => w.Words).Create();
            var words = _fixture.Build<Word>()
                        .With(w => w.User, user)
                        .With(w => w.IsLearned, false)
                        .CreateMany()
                        .ToList();
            _mockRepo.Setup(repo => repo.GetWordRandomByUserId(user.Id)).ReturnsAsync(words);

            // Act
            var result = await _controller.GetWordRandomByUserId(user.Id);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedWords = okResult.Value as List<Word>;
            Assert.That(returnedWords, Is.EqualTo(words));

        }

        [Test]
        public async Task GetWordById_ReturnsResult_WithWord()
        {
            Fixture fixture = new Fixture();

            var word = _fixture.Build<Word>().Without(w => w.User).Create();
            Assert.NotNull(word);
            if (word == null) return;
            _mockRepo.Setup(repo => repo.GetWordById(word.Id)).ReturnsAsync(word);

            // Act
            var result = await _controller.GetWordById(word.Id);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedWord = okResult.Value as Word;
            Assert.That(word, Is.EqualTo(returnedWord));
        }

        [Test]
        public async Task PutWord_ReturnsOk_WithUpdatedWord()
        {
            // Arrange
            var user = _fixture.Build<User>().Without(w => w.Words).Create();
            var word = _fixture.Build<Word>()
                        .With(w => w.User, user)
                        .Create();

            _mockRepo.Setup(repo => repo.PutWord(word.Id, word)).ReturnsAsync(word);

            // Act
            var result = await _controller.PutWord(word.Id, word);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedWord = okResult.Value as Word;
            Assert.That(word, Is.EqualTo(returnedWord));

        }

        [Test]
        public async Task PostWord_ReturnsCreatedAtAction_WithNewWord()
        {
            // Arrange
            var user = _fixture.Build<User>().Without(w => w.Words).Create();
            var word = _fixture.Build<Word>()
                        .With(w => w.User, user)
                        .Create();
            _mockRepo.Setup(repo => repo.PostWord(word)).ReturnsAsync(word);

            // Act
            var result = await _controller.PostWord(word);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
            var createdAtResult = result.Result as CreatedAtActionResult;
            var returnedWord = createdAtResult.Value as Word;
            Assert.That(word, Is.EqualTo(returnedWord));

        }

        [Test]
        public async Task DeleteWord_ReturnsOk_WithWordId()
        {
            // Arrange
            var wordId = Guid.NewGuid().ToString();
            _mockRepo.Setup(repo => repo.DeleteWord(wordId)).ReturnsAsync(wordId);

            // Act
            var result = await _controller.DeleteWord(wordId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedWordId = okResult.Value as string;
            Assert.That(wordId, Is.EqualTo(returnedWordId));

        }

    }
}
