using System;
using MongoDB.Driver;

namespace i18u.Repositories.Mongo.Interop
{
    internal class MockCollection<T> : IMongoCollection<T> where T : IMongoModel
    {
		public string CollectionName { get; }

		/// <summary>
		/// Creates a new instance of the <see cref="MockCollection{T}"/> class.
		/// </summary>
        public MockCollection(string name)
		{
            CollectionName = name;
        }

        public IFindFluent<T, T> Find(FilterDefinition<T> filter)
        {
            throw new NotImplementedException();
        }
    }
}
