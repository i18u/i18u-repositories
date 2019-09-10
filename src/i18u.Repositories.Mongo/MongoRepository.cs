using System.Collections.Generic;
using i18u.Repositories.Mongo.Results;
using MongoDB.Bson;
using MongoDB.Driver;
using IMongoClient = i18u.Repositories.Mongo.Interop.IMongoClient;

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
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public IInsertResult InsertMany(IEnumerable<TModel> model)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public IUpdateResult Update(ObjectId id, UpdateDefinition<TModel> updateDefinition)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public IUpdateResult UpdateMany(FilterDefinition<TModel> filterDefinition, UpdateDefinition<TModel> updateDefinition)
        {
            throw new System.NotImplementedException();
        }
    }
}