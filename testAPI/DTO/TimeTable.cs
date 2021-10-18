using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace testAPI.DTO
{
    public class TimeTable
    {

        [BsonId]
        public ObjectId _id { get; set; }

        public string Group { get; set; }

        public Week[] Weeks { get; set; }
    }
}
