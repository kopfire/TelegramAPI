using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class SpecialtiesRepository : ISpecialtiesRepository
    {
        private readonly IMongoCollection<Specialties> Specialties;

        public SpecialtiesRepository()
        {
            MongoClient client = new("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Telegram");
            Specialties = database.GetCollection<Specialties>("Specialties");
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Specialties>> GetSpecialties(string id)
        {
            return await Specialties.Find(new BsonDocument("Facylty", new ObjectId(id))).ToListAsync();
        }
        public async Task<Specialties> GetSpecialties(string id, string name)
        {
            var builder = new FilterDefinitionBuilder<Specialties>();
            var filter = builder.Eq("Name", name) & builder.Eq("Facylty", new ObjectId(id));
            return await Specialties.Find(filter).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<string> Create(Specialties specialties)
        {
            await Specialties.InsertOneAsync(specialties);
            return specialties.Id;
        }

        /// <inheritdoc/>
        public async Task<string> CreateOrUpdate(Specialties specialties)
        {
            var checkSpecialties = await GetSpecialties(specialties.Facylty, specialties.Name);
            if (checkSpecialties != null)
                return checkSpecialties.Id;
            return await Create(specialties);
        }

        /// <inheritdoc/>
        public async Task Update(Specialties specialties)
        {
            await Specialties.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(specialties.Id)), specialties);
        }

        /// <inheritdoc/>
        public async Task Remove(string id)
        {
            await Specialties.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
