using MongoDB.Driver;

namespace APIKnightMongo.Extensions
{
    public static class DatabaseServicesExtensions
    {
        public class MongoDbSettings
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public static IConfiguration _configuration { get; set; }

        public static IServiceCollection AddDatabaseServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            _configuration = configuration;
           
            services.Configure<MongoDbSettings>(
                _configuration.GetSection("MongoDbConnection")
            );

            services.AddSingleton<IMongoDatabase>(options => {
                var settings = _configuration.GetSection("MongoDbConnection").Get<MongoDbSettings>();
                var client = new MongoClient(settings.ConnectionString);
                return client.GetDatabase(settings.DatabaseName);
            });

            return services;
        }
    }
}
