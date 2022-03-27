namespace UserIdentityWithMongodb.Settings
{
    public class MongoDBConfig
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}
