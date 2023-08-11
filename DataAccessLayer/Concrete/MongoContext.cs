using EntityLayer.Concrete;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            // MongoDB bağlantı dizesini appsettings.json dosyasından alın
            var connectionString = "mongodb://localhost:27017";

            // MongoClient oluştur
            var mongoClient = new MongoClient(connectionString);

            // Veritabanını al
            _database = mongoClient.GetDatabase("RealEstateSaleDB");
        }

        public IMongoCollection<Advert> Announcements => _database.GetCollection<Advert>("Adverts");
        public IMongoCollection<Comment> Comments => _database.GetCollection<Comment>("Comments");
        public IMongoCollection<Message> Messages => _database.GetCollection<Message>("Messages");
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
