using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace i18u.Repositories.Mongo
{
    /// <summary>
    /// A read-only repository for MongoDB.
    /// </summary>
    /// <typeparam name="TModel">The database model.</typeparam>
    public interface IReadOnlyMongoRepository<TModel> : IReadOnlyMongoRepository<TModel, TModel> where TModel : IMongoModel {}

    /// <summary>
    /// A read-only repository for MongoDB.
    /// </summary>
    /// <typeparam name="TModel">The database model.</typeparam>
    /// <typeparam name="TProjection">The projection to return.</typeparam>
    public interface IReadOnlyMongoRepository<TModel, TProjection> where TModel : IMongoModel
    {
        /// <summary>
        /// Retrieves an object by its <see cref="ObjectId"/> (_id) field.
        /// </summary>
        /// <param name="id">The <see cref="ObjectId"/> to retrieve the document by.</param>
        /// <returns>The object retrieved by the _id query.</returns>
        TProjection Get(ObjectId id);

        /// <summary>
        /// Retrieves a collection of objects by the provided <see cref="FilterDefinition{TModel}"/>.
        /// </summary>
        /// <param name="filter">The <see cref="FilterDefinition{TModel}"/> by which to retrieve the models.</param>
        /// <returns>The matching documents from Mongo.</returns>
        IEnumerable<TProjection> Get(FilterDefinition<TModel> filter);

        /// <summary>
        /// Retrieves a collection of objects by the provided <see cref="FilterDefinition{TModel}"/>.
        /// </summary>
        /// <param name="filter">The <see cref="FilterDefinition{TModel}"/> by which to retrieve the models.</param>
        /// <param name="skip">The number of entities to skip.</param>
        /// <param name="limit">The maximum number of entities to return.</param>
        /// <returns>The matching documents from Mongo.</returns>
        IEnumerable<TProjection> Get(FilterDefinition<TModel> filter, int skip, int limit);

        /// <summary>
        /// Retrieves a collection of objects by the provided <see cref="Expression{T}"/> of <see cref="Func{T, U}"/>.
        /// </summary>
        /// <param name="filter">The <see cref="Expression{T}"/> of <see cref="Func{T, U}"/> by which to retrieve the models.</param>
        /// <returns>The matching entities from Mongo.</returns>
        IEnumerable<TProjection> Get(Expression<Func<TModel, bool>> filter);

        /// <summary>
        /// Retrieves a collection of objects by the provided <see cref="Expression{T}"/> of <see cref="Func{T, U}"/>.
        /// </summary>
        /// <param name="filter">The <see cref="Expression{T}"/> of <see cref="Func{T, U}"/> by which to retrieve the models.</param>
        /// <param name="skip">The number of entities to skip.</param>
        /// <param name="limit">The maximum number of entities to return.</param>
        /// <returns>The matching entities from Mongo.</returns>
        IEnumerable<TProjection> Get(Expression<Func<TModel, bool>> filter, int skip, int limit);
    }
}
