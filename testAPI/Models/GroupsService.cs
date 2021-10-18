using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TelegramAPI.Models
{
    public class GroupsService
    {
        IGridFSBucket gridFS;   // файловое хранилище
        IMongoCollection<Groups> Groups; // коллекция в базе данных
        public GroupsService()
        {
            // строка подключения
            string connectionString = "mongodb://localhost:27017";
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase("Telegram");
            // получаем доступ к файловому хранилищу
            gridFS = new GridFSBucket(database);
            // обращаемся к коллекции Students
            Groups = database.GetCollection<Groups>("Groups");
        }

        // получаем один документ по группе
        public async Task<Groups> GetGroups(long id)
        {
            return await Groups.Find(new BsonDocument("Students", id )).FirstOrDefaultAsync();
        }

        // добавление документа
        public async Task Create(Groups p)
        {
            await Groups.InsertOneAsync(p);
        }
        // обновление документа
        public async Task Update(Groups p)
        {
            await Groups.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }
        // удаление документа
        public async Task Remove(string id)
        {
            await Groups.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
