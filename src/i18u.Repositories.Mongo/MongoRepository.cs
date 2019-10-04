using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using i18u.Repositories.Mongo.Results;
using MongoDB.Bson;
using MongoDB.Driver;
using DeleteResult = i18u.Repositories.Mongo.Results.DeleteResult;
using IMongoClient = i18u.Repositories.Mongo.Interop.IMongoClient;
using UpdateResult = i18u.Repositories.Mongo.Results.UpdateResult;

namespace i18u.Repositories.Mongo
{
	/// <inheritdoc cref="IMongoRepository{TModel}" />
	public class MongoRepository<TModel> : MongoRepository<TModel, TModel>, IMongoRepository<TModel> where TModel : IMongoModel
	{
		/// <summary>
		/// Creates a new instance of the <see cref="ReadOnlyMongoRepository{TModel}"/> class.
		/// </summary>
		/// <param name="client">The <see cref="IMongoClient"/> to use.</param>
		/// <param name="database">The name of the database to use.</param>
		/// <param name="collection">The name of the collection to use.</param>
		public MongoRepository(IMongoClient client, string database, string collection)
			: base(client, database, collection, Builders<TModel>.Projection.Expression(z => z))
		{
		}
	}

	/// <inheritdoc cref="IMongoRepository{TModel, TProjection}"/>
	public class MongoRepository<TModel, TProjection> : ReadOnlyMongoRepository<TModel, TProjection>, IMongoRepository<TModel, TProjection> where TModel : IMongoModel
	{
		/// <summary>
		/// Creates a new instance of the <see cref="ReadOnlyMongoRepository{TModel, TProjection}"/> class.
		/// </summary>
		/// <param name="client">The <see cref="IMongoClient"/> to use.</param>
		/// <param name="database">The name of the database to use.</param>
		/// <param name="collection">The name of the collection to use.</param>
		/// <param name="projection">The <see cref="ProjectionDefinition{T, U}"/> to use.</param>
		public MongoRepository(IMongoClient client, string database, string collection, ProjectionDefinition<TModel, TProjection> projection) : base(client, database, collection, projection)
		{
		}

		private T WrapMongoResult<T>(Action action) where T : Result, new()
		{
			return WrapMongoResult<T>((res) =>
			{
				action.Invoke();
			});
		}

		private T WrapMongoResult<T>(Action<T> action) where T : Result, new()
		{
			var result = new T();
			var sw = Stopwatch.StartNew();

			try
			{
				result.Success = true;
				result.DocumentsAffected = 1;

				action.Invoke(result);
			}
			catch (Exception ex)
			{
				result.ServerError = ex;
				result.Success = false;
				result.DocumentsAffected = 0;
			}
			finally
			{
				sw.Stop();
			}

			// Set our value if it hasn't already been set.
			if (result.TimeTaken != default)
			{
				result.TimeTaken = sw.Elapsed;
			}

			return result;
		}

		/// <inheritdoc />
		public IInsertResult Insert(TModel model)
		{
			var result = WrapMongoResult<InsertResult>(() =>
			{
				Collection.InsertOne(model, false);
			});

			result.Ids = new []
			{
				model.Id,
			};

			return result;
		}

		/// <inheritdoc />
		public IInsertResult InsertMany(IEnumerable<TModel> models)
		{
			var result = WrapMongoResult<InsertResult>(() =>
			{
				Collection.InsertMany(models);
			});

			var affectedModelIds = models
				.Where(model => model.Id != default)
				.Select(model => model.Id)
				.ToArray();

			result.Ids = affectedModelIds;

			return result;
		}

		/// <inheritdoc />
		public IUpdateResult Update(ObjectId id, UpdateDefinition<TModel> updateDefinition)
		{
			var result = WrapMongoResult<UpdateResult>((res) =>
			{
				var filter = Builders<TModel>.Filter.Eq(entity => entity.Id, id);
				var mResult = Collection.UpdateOne(filter, updateDefinition);

				res.DocumentsAffected = mResult.ModifiedCount;
			});

			return result;
		}

		/// <inheritdoc />
		public IUpdateResult UpdateMany(FilterDefinition<TModel> filterDefinition, UpdateDefinition<TModel> updateDefinition)
		{
			var result = WrapMongoResult<UpdateResult>((res) =>
			{
				var mResult = Collection.UpdateMany(filterDefinition, updateDefinition);

				res.DocumentsAffected = mResult.ModifiedCount;
			});

			return result;
		}

		/// <inheritdoc />
		public IDeleteResult Delete(ObjectId id)
		{
			var result = WrapMongoResult<DeleteResult>((res) =>
			{
				var filter = Builders<TModel>.Filter.Eq(doc => doc.Id, id);
				var mResult = Collection.DeleteOne(filter);

				res.DocumentsAffected = mResult.DeletedCount;
			});

			return result;
		}

		/// <inheritdoc />
		public IDeleteResult DeleteMany(FilterDefinition<TModel> filterDefinition)
		{
			var result = WrapMongoResult<DeleteResult>((res) =>
			{
				var mResult = Collection.DeleteOne(filterDefinition);

				res.DocumentsAffected = mResult.DeletedCount;
			});

			return result;
		}
	}
}
