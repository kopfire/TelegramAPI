using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TelegramAPI.Models
{
    public class TimeTablesService
    {
        IGridFSBucket gridFS;   /// файловое хранилище
        IMongoCollection<TimeTables> TimeTables; /// коллекция в базе данных
        public TimeTablesService()
        {
            /// строка подключения
            string connectionString = "mongodb://localhost:27017";
            var connection = new MongoUrlBuilder(connectionString);
            /// получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            /// получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase("Telegram");
            /// получаем доступ к файловому хранилищу
            gridFS = new GridFSBucket(database);
            /// обращаемся к коллекции TimeTable
            TimeTables = database.GetCollection<TimeTables>("TimeTables");
        }

        /// получаем один документ по группе

        public async Task<TimeTables> GetTimeTable(string group)
        {
            return await TimeTables.Find(new BsonDocument("Group", group)).FirstOrDefaultAsync();
        }

        /// получаем один документ по id
        public async Task<TimeTables> GetTimeTable(long id)
        {
            Console.WriteLine("OK1");
            var filter = Builders<TimeTables>.Filter.AnyEq(x => x.Students,  id );

            Console.WriteLine("OK2");
            return await TimeTables.Find(filter).FirstOrDefaultAsync();
        }
        /// добавление документа
        public async Task Create(TimeTables p)
        {
            await TimeTables.InsertOneAsync(p);
        }
        /// обновление документа
        public async Task Update(TimeTables p)
        {
            await TimeTables.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }
        /// удаление документа
        public async Task Remove(string id)
        {
            await TimeTables.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
