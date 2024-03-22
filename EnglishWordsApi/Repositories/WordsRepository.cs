﻿using DeepL;
using EnglishWords.Context;
using EnglishWords.Models;
using EnglishWordsApi.interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EnglishWordsApi.Repositories
{
    public class WordsRepository : IWordsRepository
    {

        private readonly ApplicationDbContext _context;

        public WordsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Word>> GetWords()
        {
            return await _context.Word.ToListAsync();
        }

        public async Task<IEnumerable<Word>> GetWordsByUserId(string userId)
        {
            return await _context.Word.Where(w => w.User.Id == userId).ToListAsync();
        }

        public async Task<IEnumerable<Word>> GetWordRandomByUserId(string userId)
        {
            return await _context.Word.Where(w => w.User.Id == userId && !w.IsLearned).Take(10).ToListAsync();
        }

        public async Task<Word> GetWordById(string id)
        {
            return await _context.Word.FindAsync(id);
        }

        public async Task<Word> PostWord(Word word)
        {
            _context.Word.Add(word);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (WordExists(word.Id))
                {
                    throw new Exception("Error Conflit, id exist");
                }
                else
                {
                    throw new Exception(e.ToString());
                }
            }
            return word;
        }

        public async Task<Word> PutWord(string id, Word word)
        {
            // add in appSettings
            var authKey = "e35db37a-82fb-4559-9778-84060ed1b487:fx"; // Replace with your key

            var translator = new Translator(authKey);
            var translatedText = await translator.TranslateTextAsync(word.WordText, LanguageCode.English, LanguageCode.French);

            word.WordTranslate = translatedText.Text;
            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!WordExists(id))
                {
                    throw new Exception("Error Not found, word not find");
                }
                else
                {
                    throw new Exception(e.ToString());
                }
            }

            return word;
        }

        public async Task<string?> DeleteWord(string id)
        {
            var word = await _context.Word.FirstOrDefaultAsync(w => w.Id == id);
            if (word == null)
            {
                return null;
            }

            _context.Word.Remove(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }

        private bool WordExists(string id)
        {
            return _context.Word.Any(e => e.Id == id);
        }
    }
}
