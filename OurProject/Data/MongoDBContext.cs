using MongoDB.Driver;
using OurProject.Data.Models;
namespace OurProject.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase Database;
        public IMongoCollection<User> Users => Database.GetCollection<User>("Users");
        public MongoDBContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            Database = client.GetDatabase("NAME");
        }
        
    }
}
