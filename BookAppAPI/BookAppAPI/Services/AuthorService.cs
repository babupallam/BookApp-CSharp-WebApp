using MongoDB.Driver;
using BookAppAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAppAPI.Services
{
    public class AuthorService
    {
        private readonly IMongoCollection<Author> _authors;

        public AuthorService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _authors = database.GetCollection<Author>(settings.AuthorsCollectionName);
        }

        public async Task<List<Author>> GetAsync() =>
            await _authors.Find(author => true).ToListAsync();

        public async Task<Author> GetAsync(string id) =>
            await _authors.Find<Author>(author => author.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Author author) =>
            await _authors.InsertOneAsync(author);

        public async Task UpdateAsync(string id, Author authorIn) =>
            await _authors.ReplaceOneAsync(author => author.Id == id, authorIn);

        public async Task RemoveAsync(string id) =>
            await _authors.DeleteOneAsync(author => author.Id == id);
    }
}
