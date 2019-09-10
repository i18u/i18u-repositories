using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using IMongoClient = i18u.Repositories.Mongo.Interop.IMongoClient;

namespace i18u.Repositories.Mongo
{
    /// <inheritdoc cref="IReadOnlyMongoRepository{TModel}" />
    public class ReadOnlyMongoRepository<TModel> : ReadOnlyMongoRepository<TModel, TModel>, IReadOnlyMongoRepository<TModel> where TModel : IMongoModel 
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ReadOnlyMongoRepository{TModel}"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IMongoClient"/> to use.</param>
        /// <param name="database">The name of the database to use.</param>
        /// <param name="collection">The name of the collection to use.</param>
        public ReadOnlyMongoRepository(IMongoClient client, string database, string collection)
            : base(client, database, collection, Builders<TModel>.Projection.Expression(z => z)) { }
    }
    
    /// <inheritdoc cref="IReadOnlyMongoRepository{TModel, TProjection}"/>
    public class ReadOnlyMongoRepository<TModel, TProjection> : IReadOnlyMongoRepository<TModel, TProjection> where TModel : IMongoModel
    {
        /// <summary>
        /// The <see cref="ProjectionDefinition{TModel, TProjection}"/> to convert 
        /// from the mongo entity to the projection entity.
        /// </summary>
        protected readonly ProjectionDefinition<TModel, TProjection> Projection;

        /// <summary>
        /// The <see cref="IMongoCollection{T}"/> to retrieve entities from.
        /// </summary>
        protected readonly Interop.IMongoCollection<TModel> Collection;

        /// <summary>
        /// Creates a new instance of the <see cref="ReadOnlyMongoRepository{TModel, TProjection}"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IMongoClient"/> to use.</param>
        /// <param name="database">The name of the database to use.</param>
        /// <param name="collection">The name of the collection to use.</param>
        /// <param name="projection">The <see cref="ProjectionDefinition{T, U}"/> to use.</param>
        public ReadOnlyMongoRepository(IMongoClient client, string database, string collection, ProjectionDefinition<TModel, TProjection> projection)
        {
            Projection = projection;
            Collection = GetCollection(client, database, collection);
        }

        private static Interop.IMongoCollection<TModel> GetCollection(IMongoClient client, string database, string collection)
        {
            return client.GetDatabase(database).GetCollection<TModel>(collection);
        }

        /// <inheritdoc cref="IReadOnlyMongoRepository{TModel, TProjection}"/>
        public TProjection Get(ObjectId id)
        {
            if (id == null) 
            {
                return default;
            }
            
            var filter = Builders<TModel>.Filter.Eq(z => z.Id, id);
            var entities = Get(filter);

            if (entities.Count() == 0)
            {
                return default;
            }

            return entities.FirstOrDefault();
        }

        /// <inheritdoc cref="IReadOnlyMongoRepository{TModel, TProjection}"/>
        public IEnumerable<TProjection> Get(FilterDefinition<TModel> filter)
        {
            if (filter == null) 
            {
                return new TProjection[0];
            }

            return Collection
                .Find(filter)
                .Project(Projection)
                .ToList();
        }

        /// <inheritdoc cref="IReadOnlyMongoRepository{TModel, TProjection}"/>
        public IEnumerable<TProjection> Get(FilterDefinition<TModel> filter, int skip, int limit)
        {
            if (filter == null)
            {
                return new TProjection[0];
            }

            if (skip <= 0)
            {
                return new TProjection[0];
            }

            if (limit <= 0)
            {
                return new TProjection[0];
            }

            return Collection
                .Find(filter)
                .Project(Projection)
                .Skip(skip)
                .Limit(limit)
                .ToList();
        }

        /// <inheritdoc cref="IReadOnlyMongoRepository{TModel, TProjection}"/>
        public IEnumerable<TProjection> Get(Expression<Func<TModel, bool>> filter)
        {
            FilterDefinition<TModel> filterDef = filter;
            return Get(filterDef);
        }

        /// <inheritdoc cref="IReadOnlyMongoRepository{TModel, TProjection}"/>
        public IEnumerable<TProjection> Get(Expression<Func<TModel, bool>> filter, int skip, int limit)
        {
            FilterDefinition<TModel> filterDef = filter;
            return Get(filterDef, skip, limit);
        }
    }
}