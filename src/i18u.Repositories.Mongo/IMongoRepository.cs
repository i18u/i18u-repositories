using System.Collections.Generic;
using i18u.Repositories.Mongo.Results;
using MongoDB.Bson;
using MongoDB.Driver;

namespace i18u.Repositories.Mongo
{
    /// <inheritdoc />
    public interface IMongoRepository<TModel> : IMongoRepository<TModel, TModel>, IReadOnlyMongoRepository<TModel> where TModel : IMongoModel { }

    /// <summary>
    /// A repository for reading and writing from Mongo.
    /// </summary>
    /// <typeparam name="TModel">The entity type to query against in Mongo.</typeparam>
    /// <typeparam name="TProjection">The entity type to retrieve from Mongo for read operations.</typeparam>
    public interface IMongoRepository<TModel, TProjection> : IReadOnlyMongoRepository<TModel, TProjection> where TModel : IMongoModel
    {
        /// <summary>
        /// Inserts the provided entity into Mongo.
        /// </summary>
        /// <param name="model">The entity to insert.</param>
        /// <returns>A <see cref="IInsertResult"/> representing the outcome.</returns>
        IInsertResult Insert(TModel model);

        /// <summary>
        /// Inserts the provided entities into Mongo.
        /// </summary>
        /// <param name="model">The entities to insert.</param>
        /// <returns>A <see cref="IInsertResult"/> representing the outcome.</returns>
        IInsertResult InsertMany(IEnumerable<TModel> model);

        /// <summary>
        /// Updates the entity(s) in Mongo that match the provided <see cref="ObjectId"/>.
        /// </summary>
        /// <param name="id">The <see cref="ObjectId"/> of the entity(s) to update.</param>
        /// <param name="updateDefinition">The <see cref="UpdateDefinition{TModel}"/> to apply to the entity(s).</param>
        /// <returns>A <see cref="IUpdateResult"/> representing the outcome.</returns>
        IUpdateResult Update(ObjectId id, UpdateDefinition<TModel> updateDefinition);

        /// <summary>
        /// Updates the entity(s) in Mongo that match the provided <see cref="FilterDefinition{TModel}"/>.
        /// </summary>
        /// <param name="filterDefinition">The <see cref="FilterDefinition{TModel}"/> to identify the entity(s) to update.</param>
        /// <param name="updateDefinition">The <see cref="UpdateDefinition{TModel}"/> to apply to the entity(s).</param>
        /// <returns>A <see cref="IUpdateResult"/> representing the outcome.</returns>
        IUpdateResult UpdateMany(FilterDefinition<TModel> filterDefinition, UpdateDefinition<TModel> updateDefinition);

        /// <summary>
        /// Deletes the entity(s) in Mongo that match the provided <see cref="ObjectId"/>.
        /// </summary>
        /// <param name="id">The <see cref="ObjectId"/> of the entity(s) to delete.</param>
        /// <returns>A <see cref="IDeleteResult"/> representing the outcome.</returns>
        IDeleteResult Delete(ObjectId id);

        /// <summary>
        /// Deletes the entity(s) in Mongo that match the provided <see cref="FilterDefinition{TModel}"/>.
        /// </summary>
        /// <param name="filterDefinition">The <see cref="FilterDefinition{TModel}"/> to identify the entity(s) to delete.</param>
        /// <returns>A <see cref="IDeleteResult"/> representing the outcome.</returns>
        IDeleteResult DeleteMany(FilterDefinition<TModel> filterDefinition);
    }
}
