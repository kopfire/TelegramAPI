﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using testAPI.DTO;

namespace TelegramAPI.Models
{
    public class Groups
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Display(Name = "Группа")]
        public string Group { get; set; }

        [Display(Name = "Студенты")]
        public BsonArray[] Students { get; set; }
    }
}
