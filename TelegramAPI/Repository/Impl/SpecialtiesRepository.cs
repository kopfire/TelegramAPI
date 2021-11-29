﻿using MongoDB.Bson;
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

        /// <inheritdoc/>
        public async Task Create(Specialties specialties)
        {
            await Specialties.InsertOneAsync(specialties);
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