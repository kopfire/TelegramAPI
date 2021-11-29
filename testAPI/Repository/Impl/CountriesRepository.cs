using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class CountriesRepository : ICountriesRepository
    {
        private readonly IMongoCollection<Countries> Countries;

        public CountriesRepository()
        {
            MongoClient client = new("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Telegram");
            Countries = database.GetCollection<Countries>("Countries");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Countries>> GetCounties()
        {
            var builder = new FilterDefinitionBuilder<Countries>();
            var filter = builder.Empty;
            return await Countries.Find(filter).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task Create(Countries countries)
        {
            await Countries.InsertOneAsync(countries);
        }

        /// <inheritdoc/>
        public async Task Update(Countries countries)
        {
            await Countries.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(countries.Id)), countries);
        }

        /// <inheritdoc/>
        public async Task Remove(string id)
        {
            await Countries.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
