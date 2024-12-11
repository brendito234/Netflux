using MongoDB.Driver;
using OurProject.Data.Models;
namespace OurProject.Data
{
    public class MongoDBContext
    {
        private readonly IConfiguration configuration;
        private readonly IMongoDatabase database;
      
        public MongoDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;

            string connectionString = configuration.GetConnectionString("MongoDB");
            var mongoUrl = MongoUrl.Create(connectionString);
            var client = new MongoClient(mongoUrl);
            database = client.GetDatabase(mongoUrl.DatabaseName);
        }
        public IMongoDatabase? Database => database;
       
    }
}
