using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class TimeTablesRepository : ITimeTableRepository
    {
        IMongoCollection<TimeTables> TimeTables; /// коллекция в базе данных
        public TimeTablesRepository()
        {
            /// строка подключения
            string connectionString = "mongodb://localhost:27017";
            var connection = new MongoUrlBuilder(connectionString);
            /// получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            /// получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase("Telegram");
            /// обращаемся к коллекции TimeTable
            TimeTables = database.GetCollection<TimeTables>("TimeTables");
        }

        /// <inheritdoc/>
        public async Task<TimeTables> GetTimeTable(string group)
        {
            return await TimeTables.FindAsync(new BsonDocument("Group", group)).Result.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<TimeTables> GetTimeTable(long id)
        {
            var filter = Builders<TimeTables>.Filter.AnyEq(x => x.Students,  id );
            return await TimeTables.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task Create(TimeTables p)
        {
            await TimeTables.InsertOneAsync(p);
        }

        /// <inheritdoc/>
        public async Task Update(TimeTables p)
        {
            await TimeTables.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }

        /// <inheritdoc/>
        public async Task Remove(string id)
        {
            await TimeTables.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
