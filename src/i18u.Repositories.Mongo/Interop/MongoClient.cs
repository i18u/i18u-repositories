namespace i18u.Repositories.Mongo.Interop
{
    /// <inheritdoc cref="IMongoClient" />
    public class MongoClient
    {
        private MongoDB.Driver.MongoClient _client;
        
        /// <inheritdoc cref="IMongoClient.GetDatabase" />
        public IMongoDatabase GetDatabase(string name)
        {
            var databoose = _client.GetDatabase(name);
            return new MongoDatabase(databoose);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MongoClient" /> class.
        /// </summary>
        /// <param name="host">The host to connect to.</param>
        /// <param name="port">The port to connect on.</param>
        /// <param name="username">The username of the user to authenticate as.</param>
        /// <param name="password">The password of the user to authenticate as.</param>
        public MongoClient(string host, int port, string username, string password)
        {
            _client = new MongoDB.Driver.MongoClient(new MongoDB.Driver.MongoClientSettings
            {
                Server = new MongoDB.Driver.MongoServerAddress(host, port),
                Credential = MongoDB.Driver.MongoCredential.CreateCredential("admin", username, password)
            });
        }
    }
}