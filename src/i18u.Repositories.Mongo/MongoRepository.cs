using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using i18u.Repositories.Mongo.Results;
using MongoDB.Bson;
using MongoDB.Driver;
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

        /// <inheritdoc />
        public IDeleteResult Delete(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public IDeleteResult DeleteMany(FilterDefinition<TModel> filterDefinition)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public IInsertResult Insert(TModel model)
        {
            var result = new InsertResult();
			var sw = Stopwatch.StartNew();

            try
            {

				Collection.InsertOne(model, false);

				result.Success = true;
            	result.DocumentsAffected = 1;
				result.Ids = new []
				{
					model.Id,
				};
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

			result.TimeTaken = sw.Elapsed;

            return result;
        }

        /// <inheritdoc />
        public IInsertResult InsertMany(IEnumerable<TModel> models)
        {
            var result = new InsertResult();
			var sw = Stopwatch.StartNew();

			try
			{
				Collection.InsertMany(models);

                var affectedModelIds = models
					.Where(model => model.Id == default)
                    .Select(model => model.Id)
                    .ToArray();

                result.Success = true;
            	result.DocumentsAffected = affectedModelIds.Length;
				result.Ids = affectedModelIds;
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

            result.TimeTaken = sw.Elapsed;

            return result;
        }

        /// <inheritdoc />
        public IUpdateResult Update(ObjectId id, UpdateDefinition<TModel> updateDefinition)
        {
            var result = new UpdateResult();
            var sw = Stopwatch.StartNew();

            try
			{
				var filter = Builders<TModel>.Filter.Eq(entity => entity.Id, id);
                var mResult = Collection.UpdateOne(filter, updateDefinition);

                result.Success = true;
                result.DocumentsAffected = mResult.ModifiedCount;
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

            return result;
        }

        /// <inheritdoc />
        public IUpdateResult UpdateMany(FilterDefinition<TModel> filterDefinition, UpdateDefinition<TModel> updateDefinition)
        {
            var result = new UpdateResult();
            var sw = Stopwatch.StartNew();

			try
			{
                var mResult = Collection.UpdateMany(filterDefinition, updateDefinition);

                result.Success = true;
                result.DocumentsAffected = mResult.ModifiedCount;
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

            return result;
        }
    }
}
