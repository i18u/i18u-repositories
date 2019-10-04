using System.Collections.Generic;
using i18u.Repositories.Mongo.Results;
using MongoDB.Driver;
using DeleteResult = MongoDB.Driver.DeleteResult;
using UpdateResult = MongoDB.Driver.UpdateResult;

namespace i18u.Repositories.Mongo.Interop
{
	/// <inheritdoc cref="IMongoCollection{T}" />
	internal class MongoCollection<T> : IMongoCollection<T> where T : IMongoModel
	{
		/// <summary>
		/// The <see cref="MongoDB.Driver.IMongoCollection{T}"/> to use.
		/// </summary>
		private readonly MongoDB.Driver.IMongoCollection<T> _collection;

		/// <summary>
		/// Creates a new instance of the <see cref="MongoCollection{T}" /> class.
		/// </summary>
		/// <param name="collection">The underlying <see cref="MongoDB.Driver.IMongoCollection{T}"/> instance.</param>
		public MongoCollection(MongoDB.Driver.IMongoCollection<T> collection)
		{
			_collection = collection;
		}

		/// <inheritdoc />
		public IFindFluent<T, T> Find(FilterDefinition<T> filter)
		{
			return new FindFluent<T, T>(_collection.Find(filter));
		}

		/// <inheritdoc />
		public void InsertOne(T model, bool bypassValidation)
		{
			var options = new InsertOneOptions
			{
				BypassDocumentValidation = bypassValidation
			};

			_collection.InsertOne(model, options);
		}

		/// <inheritdoc />
		public void InsertOne(T model)
		{
			InsertOne(model, false);
		}

		/// <inheritdoc />
		public void InsertMany(IEnumerable<T> entities, bool bypassValidation, bool isOrdered)
		{
			var insertManyOptions = new InsertManyOptions
			{
				BypassDocumentValidation = bypassValidation,
				IsOrdered = isOrdered,
			};

			_collection.InsertMany(entities, insertManyOptions);
		}

		/// <inheritdoc />
		public void InsertMany(IEnumerable<T> entities)
		{
			InsertMany(entities, false, false);
		}

		/// <inheritdoc />
		public UpdateResult UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options)
		{
			return _collection.UpdateOne(filter, update, options);
		}

		/// <inheritdoc />
		public UpdateResult UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update)
		{
			return _collection.UpdateOne(filter, update);
		}

		/// <inheritdoc />
		public UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update)
		{
			return _collection.UpdateMany(filter, update);
		}

		/// <inheritdoc />
		public UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options)
		{
			return _collection.UpdateMany(filter, update, options);
		}

		/// <inheritdoc />
		public DeleteResult DeleteOne(FilterDefinition<T> filter)
		{
			return _collection.DeleteOne(filter);
		}

		/// <inheritdoc />
		public DeleteResult DeleteOne(FilterDefinition<T> filter, DeleteOptions options)
		{
			return _collection.DeleteOne(filter, options);
		}

		/// <inheritdoc />
		public DeleteResult DeleteMany(FilterDefinition<T> filter)
		{
			return _collection.DeleteMany(filter);
		}

		/// <inheritdoc />
		public DeleteResult DeleteMany(FilterDefinition<T> filter, DeleteOptions options)
		{
			return _collection.DeleteMany(filter, options);
		}
	}
}
