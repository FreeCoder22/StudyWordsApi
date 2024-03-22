using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyWords.Context;
using StudyWords.Models;
using DeepL;
using Polly;
using StudyWordsApi.interfaces;

namespace StudyWordsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordsRepository _wordsRepository;

        public WordsController(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWords()
        {
            var words = await _wordsRepository.GetWords();

            if (words == null)
            {
                return NotFound();
            }

            return Ok(words);
        }
        // GET: api/Words
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Word>>> GetWordsByUserId(string userId)
        {
            var words = await _wordsRepository.GetWordsByUserId(userId);
            if (words == null)
            {
                return NotFound();
            }
            return Ok(words);
        }
        // GET: api/Words
        [HttpGet("user/random/{userId}")]
        public async Task<ActionResult<IEnumerable<Word>>> GetWordRandomByUserId(string userId)
        {
            var words = await _wordsRepository.GetWordRandomByUserId(userId);
            if (words == null)
            {
                return NotFound();
            }
            return Ok(words);

        }
        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> GetWordById(string id)
        {
            var word = await _wordsRepository.GetWordById(id);

            if (word == null)
            {
                return NotFound();
            }

            return Ok(word);
        }

        // PUT: api/Words/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Word>> PutWord(string id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            var wordUpdate = await _wordsRepository.PutWord(id, word);

            

            return Ok(wordUpdate);
        }

        // POST: api/Words
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Word word)
        {
            var wordResult = await _wordsRepository.PostWord(word);

           

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteWord(string id)
        {
            var IdWord = await _wordsRepository.DeleteWord(id);

            if (IdWord == null)
            {
                return NotFound();
            }

            return Ok(IdWord);
        }

    
    }
}
