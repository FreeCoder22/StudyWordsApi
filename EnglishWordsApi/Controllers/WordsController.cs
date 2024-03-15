﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnglishWords.Context;
using EnglishWords.Models;
using DeepL;

namespace EnglishWordsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWord()
        {
            return await _context.Word.ToListAsync();
        }
        // GET: api/Words
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Word>>> GetWordByUserId(string userId)
        {
            return await _context.Word.Where(w => w.User.Id == userId).ToListAsync();
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> GetWord(string id)
        {
            var word = await _context.Word.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
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
            var authKey = "e35db37a-82fb-4559-9778-84060ed1b487:fx"; // Replace with your key

            var translator = new Translator(authKey);
            var translatedText = await translator.TranslateTextAsync(
      word.WordText,
      LanguageCode.English,
      LanguageCode.French );
            Console.WriteLine(translatedText);
            word.WordTranslate = translatedText.Text;
            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return word;
        }

        // POST: api/Words
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Word word)
        {
            _context.Word.Add(word);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WordExists(word.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        [HttpDelete]
        public async Task<IActionResult> DeleteWord([FromBody] string[] data)
        {
            var word = _context.Word.Where(word => data.Contains(word.Id));
            if (word == null)
            {
                return NotFound();
            }

            _context.Word.RemoveRange(word);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WordExists(string id)
        {
            return _context.Word.Any(e => e.Id == id);
        }
    }
}
