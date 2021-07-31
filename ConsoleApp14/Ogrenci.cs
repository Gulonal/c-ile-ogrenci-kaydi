using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    public class Ogrenci
    {
        public ObjectId _id { get; set; } = ObjectId.GenerateNewId();
        public string Isim { get; set; }
        public string Soyad { get; set; }
        public string No { get; set; }
       


        public IMongoDatabase GetDatabase()
        {
            return new MongoClient().GetDatabase("OKUL");
        }
        public bool Insert()
        {
            try
            {
                IMongoDatabase _database = GetDatabase();
                var collection = _database.GetCollection<BsonDocument>("Sinif");
                if (collection == null)
                {
                    _database.CreateCollection("Sinif");
                    collection = _database.GetCollection<BsonDocument>("Sinif");
                }
                collection.InsertOne(this.ToBsonDocument());
                return true;
            }
            catch { return false; }
        }

        public DeleteResult Delete(string no)
        {
                IMongoDatabase _database = GetDatabase();
                var collection = _database.GetCollection<BsonDocument>("Sinif");
                var filter = Builders<BsonDocument>.Filter.Eq("No", no);
                var result = collection.DeleteMany(filter);
                return result;

        }
    }
}
