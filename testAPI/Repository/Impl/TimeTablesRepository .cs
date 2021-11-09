using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class TimeTablesRepository : ITimeTableRepository
    {

        IMongoCollection<TimeTable> TimeTables;

        public TimeTablesRepository()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Telegram");
            TimeTables = database.GetCollection<TimeTable>("TimeTables");
        }

        /// <inheritdoc/>
        public async Task<TimeTable> GetTimeTable(string group)
        {
            return await TimeTables.FindAsync(new BsonDocument("Group", group)).Result.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<TimeTable> GetTimeTable(long id)
        {
            var filter = Builders<TimeTable>.Filter.AnyEq(x => x.Students,  id );
            return await TimeTables.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task Create(TimeTable p)
        {
            await TimeTables.InsertOneAsync(p);
        }

        /// <inheritdoc/>
        public async Task Update(TimeTable p)
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
