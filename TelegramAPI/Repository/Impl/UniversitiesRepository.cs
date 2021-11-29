using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class UniversitiesRepository : IUniversitiesRepository
    {
        private readonly IMongoCollection<Universities> Universities;

        public UniversitiesRepository()
        {
            MongoClient client = new("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Telegram");
            Universities = database.GetCollection<Universities>("Universities");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Universities>> GetUniversities(string id)
        {
            return await Universities.Find(new BsonDocument("City", new ObjectId(id))).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task Create(Universities universities)
        {
            await Universities.InsertOneAsync(universities);
        }

        /// <inheritdoc/>
        public async Task Update(Universities universities)
        {
            await Universities.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(universities.Id)), universities);
        }

        /// <inheritdoc/>
        public async Task Remove(string id)
        {
            await Universities.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
