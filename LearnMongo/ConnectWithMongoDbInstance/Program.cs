using ConnectWithMongoDbInstance;
using MongoDB.Driver;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Mongo Db connection");

var secretAppsettingReader = new SecretAppsettingReader();
var secretValues = secretAppsettingReader.ReadSection("mongodb");
string mongoDbUrl = secretValues.GetSection("ConnectionString").Value;

if (string.IsNullOrEmpty(mongoDbUrl))
{ 
    Console.WriteLine("MongoDb connection string is not set.");
    return;
}

//Console.WriteLine($"MongoDb connection string: {mongoDbUrl}");
var mongoClient = new MongoClient(mongoDbUrl);
var dbList = mongoClient.ListDatabaseNames().ToList();
Console.WriteLine("database on this server: ");
foreach (var db in dbList)
{ 
   Console.WriteLine(db);
}