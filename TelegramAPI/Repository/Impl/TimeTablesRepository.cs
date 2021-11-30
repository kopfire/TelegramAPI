using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class TimeTablesRepository : ITimeTableRepository
    {
        private readonly IMongoCollection<TimeTable> TimeTables;

        public TimeTablesRepository()
        {
            MongoClient client = new("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Telegram");
            TimeTables = database.GetCollection<TimeTable>("TimeTables");
        }

        public async Task<IEnumerable<TimeTable>> GetTimeTables(string id)
        {
            return await TimeTables.Find(new BsonDocument("Speciality", new ObjectId(id))).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<TimeTable> GetTimeTableByGroup(string group)
        {
            return await TimeTables.FindAsync(new BsonDocument("Group", group)).Result.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<TimeTable> GetTimeTable(string id)
        {
            return await TimeTables.FindAsync(new BsonDocument("_id", new ObjectId(id))).Result.FirstOrDefaultAsync();
        }

        public async Task<TimeTable> GetTimeTable(string id, string name)
        {
            var builder = new FilterDefinitionBuilder<TimeTable>();
            var filter = builder.Eq("Group", name) & builder.Eq("Speciality", new ObjectId(id));
            return await TimeTables.Find(filter).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task Create(TimeTable timeTable)
        {
            await TimeTables.InsertOneAsync(timeTable);
        }

        /// <inheritdoc/>
        public async Task Update(TimeTable timeTable)
        {
            await TimeTables.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(timeTable.Id)), timeTable);
        }

        /// <inheritdoc/>
        public async Task CreateOrUpdate(TimeTable timeTable)
        {
            var checkTimeTable = await GetTimeTable(timeTable.Speciality, timeTable.Group);
            if (checkTimeTable != null)
                return;
            await Create(timeTable);
            return;
        }

        /// <inheritdoc/>
        public async Task Remove(string id)
        {
            await TimeTables.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
