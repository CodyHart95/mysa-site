using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using mysa_backend.Repositories;

namespace mysa_backend
{
    public static class Startup
    {
        public static void Configure(IServiceCollection services)
        {
            var isDev = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

            if(isDev)
            {
                AWSConfigs.RegionEndpoint = RegionEndpoint.USEast2;
            }
            
            ConfigureServices(services);
            ConfigureDynamo(services, isDev);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IShooterScoreRepo, ShooterScoreRepo>();
            services.AddScoped<IShootRepository, ShootRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();
        }

        private static void ConfigureDynamo(IServiceCollection services, bool isDev)
        {
            var dynamoDbUrl = Environment.GetEnvironmentVariable("DYNAMO_DB_LOCAL_ADDRESS");

            var dynamoDbConfig = new AmazonDynamoDBConfig();

            if (!string.IsNullOrEmpty(dynamoDbUrl))
            {
                dynamoDbConfig.ServiceURL = dynamoDbUrl;
            }

            var client = new AmazonDynamoDBClient(dynamoDbConfig);

            var tableNamePrefix = isDev ? "local" : "prod";

            var dbConfig = new DynamoDBContextConfig
            {
                SkipVersionCheck = true,
                TableNamePrefix = tableNamePrefix,
            };

            services.AddSingleton(new DynamoDBContext(client, dbConfig));
        }
    }
}
