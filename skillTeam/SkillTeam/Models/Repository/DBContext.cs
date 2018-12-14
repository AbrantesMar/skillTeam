using System;
using MongoDB.Driver;


namespace SkillTeam.Models.Repository
{
    //TODO: Configuration mongodb referencia: http://www.macoratti.net/17/11/aspncore_mongo1.htm
    public class DBContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        
        private IMongoDatabase _database { get; }

        public DBContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                    
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);

            }
            catch (Exception ex)
            {
                throw new Exception("Ops, não conseguimos upar o mongo! :(", ex);
            }
        }

        public IMongoCollection<Employee> Employees
        {
            get {
                return _database.GetCollection<Employee>("Employees");
            }
        }

        public IMongoCollection<Skill> SkillTeam
        {
            get {
                return _database.GetCollection<Skill>("Skills");
            }
        }
        
    }
}