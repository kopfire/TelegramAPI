using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TelegramAPI.Models
{
    public class TimeTableService
    {
        IGridFSBucket gridFS;   // файловое хранилище
        IMongoCollection<TimeTable> TimeTables; // коллекция в базе данных
        public TimeTableService()
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
            // обращаемся к коллекции TimeTable
            TimeTables = database.GetCollection<TimeTable>("TimeTable");
        }

        // получаем один документ по группе
        public async Task<IEnumerable<TimeTable>> GetTimeTable()
        {
            Console.WriteLine("sdfs");
            return await TimeTables.Find(new BsonDocument("_id", new ObjectId("616d58af7214da37284efcfc"))).ToListAsync();
        }
        // добавление документа
        public async Task Create(TimeTable p)
        {
            await TimeTables.InsertOneAsync(p);
        }
        // обновление документа
        public async Task Update(TimeTable p)
        {
            await TimeTables.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }
        // удаление документа
        public async Task Remove(string id)
        {
            await TimeTables.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
