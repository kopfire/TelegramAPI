using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using TelegramAPI.Models;

namespace TelegramAPI.Repository.Impl
{
    /// <inheritdoc/>
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<Users> Users;

        public UsersRepository()
        {
            MongoClient client = new ("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("Telegram");
            Users = database.GetCollection<Users>("Users");
        }

        /// <inheritdoc/>
        public async Task<Users> Get(long id)
        {
            return await Users.FindAsync(new BsonDocument("TelegramID", id)).Result.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task Create(Users users)
        {
            await Users.InsertOneAsync(users);
        }

        /// <inheritdoc/>
        public async Task Update(Users users)
        {
            await Users.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(users.Id)), users);
        }

        /// <inheritdoc/>
        public async Task Remove(string id)
        {
            await Users.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
