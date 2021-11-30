using MongoDB.Bson;
using MongoDB.Driver;
using System;
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

        public async Task<Faculties> GetFaculties(string id, string name)
        {
            var builder = new FilterDefinitionBuilder<Faculties>();
            var filter = builder.Eq("Name", name) & builder.Eq("University", new ObjectId(id));
            return await Faculties.Find(filter).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<string> Create(Faculties faculties)
        {
            await Faculties.InsertOneAsync(faculties);
            return faculties.Id;
        }

        /// <inheritdoc/>
        public async Task<string> CreateOrUpdate(Faculties faculties)
        {
            var checkFaculties = await GetFaculties(faculties.University, faculties.Name);
            if (checkFaculties != null)
                return checkFaculties.Id;
            return await Create(faculties);
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
