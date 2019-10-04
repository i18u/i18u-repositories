using System;
using System.Collections.Generic;
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

        public void InsertOne(T model)
        {
            throw new NotImplementedException();
        }

        public void InsertOne(T model, bool bypassValidation)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(IEnumerable<T> models)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(IEnumerable<T> models, bool bypassValidation, bool isOrdered)
        {
            throw new NotImplementedException();
        }

        public UpdateResult UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            throw new NotImplementedException();
        }

        public UpdateResult UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options)
        {
            throw new NotImplementedException();
        }

        public UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            throw new NotImplementedException();
        }

        public UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options)
        {
            throw new NotImplementedException();
        }

        public DeleteResult DeleteOne(FilterDefinition<T> filter)
        {
            throw new NotImplementedException();
        }

        public DeleteResult DeleteOne(FilterDefinition<T> filter, DeleteOptions opts)
        {
            throw new NotImplementedException();
        }

        public DeleteResult DeleteMany(FilterDefinition<T> filter)
        {
            throw new NotImplementedException();
        }

        public DeleteResult DeleteMany(FilterDefinition<T> filter, DeleteOptions opts)
        {
            throw new NotImplementedException();
        }
    }
}
