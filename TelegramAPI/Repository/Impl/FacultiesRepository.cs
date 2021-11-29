using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class FacultiesRepository : IFacultiesRepository
    {
        private readonly IMongoCollection<Faculties> Faculties;

        public FacultiesRepository()
        {
            MongoClient client = new("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Telegram");
            Faculties = database.GetCollection<Faculties>("Faculties");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Faculties>> GetFaculties(string id)
        {
            return await Faculties.Find(new BsonDocument("University", new ObjectId(id))).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task Create(Faculties faculties)
        {
            await Faculties.InsertOneAsync(faculties);
        }

        /// <inheritdoc/>
        public async Task Update(Faculties faculties)
        {
            await Faculties.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(faculties.Id)), faculties);
        }

        /// <inheritdoc/>
        public async Task Remove(string id)
        {
            await Faculties.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
