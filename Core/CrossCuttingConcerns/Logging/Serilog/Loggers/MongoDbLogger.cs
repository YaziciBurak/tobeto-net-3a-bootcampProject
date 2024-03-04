using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using MongoDB.Driver;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class MongoDbLogger:LoggerServiceBase
{
    public MongoDbLogger()
    {
        //MongoDbConfiguration? dbConfiguration =
        //    ConfigurationModels.GetSection("SerilogConfigurations:MongoDbConfiguration").Get<MongoDbConfiguration>();

        Logger = new LoggerConfiguration().WriteTo.MongoDBBson(
            cfg =>
            {
                MongoClient client = new("mongodb://localhost:27017");
                IMongoDatabase? database = client.GetDatabase("logs");
                cfg.SetMongoDatabase(database);
            }
            ).CreateLogger();
    }
}
