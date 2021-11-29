using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class CitiesRepository : ICitiesRepository
    {
        private readonly IMongoCollection<Cities> Cities;

        public CitiesRepository()
        {
            MongoClient client = new("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Telegram");
            Cities = database.GetCollection<Cities>("Cities");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Cities>> GetCities(string id)
        {
            return await Cities.Find(new BsonDocument("Country", new ObjectId(id))).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task Create(Cities cities)
        {
            await Cities.InsertOneAsync(cities);
        }

        /// <inheritdoc/>
        public async Task Update(Cities cities)
        {
            await Cities.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(cities.Id)), cities);
        }

        /// <inheritdoc/>
        public async Task Remove(string id)
        {
            await Cities.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
