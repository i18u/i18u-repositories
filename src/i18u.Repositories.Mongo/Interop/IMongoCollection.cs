using System.Collections.Generic;
using i18u.Repositories.Mongo.Results;
using MongoDB.Driver;
using DeleteResult = MongoDB.Driver.DeleteResult;
using UpdateResult = MongoDB.Driver.UpdateResult;

namespace i18u.Repositories.Mongo.Interop
{
	/// <summary>
	/// A MongoDB database collection.
	/// </summary>
	/// <typeparam name="T">The type of entities stored in the collection.</typeparam>
	public interface IMongoCollection<T> where T : IMongoModel
	{
		/// <summary>
		/// Finds entities by the given filter.
		/// </summary>
		/// <param name="filter">The filter by which to find entities.</param>
		/// <returns>The entities found by the filter.</returns>
		IFindFluent<T, T> Find(FilterDefinition<T> filter);

		/// <summary>
		/// Inserts the given model into the collection.
		/// </summary>
		/// <param name="model">The model to insert.</param>
		void InsertOne(T model);

		/// <summary>
		/// Inserts the given model into the collection.
		/// </summary>
		/// <param name="model">The model to insert.</param>
		/// <param name="bypassValidation">Whether or not to bypass document validation checks.</param>
		void InsertOne(T model, bool bypassValidation);

		/// <summary>
		/// Inserts the given models into the collection.
		/// </summary>
		/// <param name="models">The models to insert.</param>
		void InsertMany(IEnumerable<T> models);

		/// <summary>
		/// Inserts the given models into the collection.
		/// </summary>
		/// <param name="models">The models to insert.</param>
		/// <param name="bypassValidation">Whether to bypass document validation. Default false.</param>
		/// <param name="isOrdered">Whether the operations are to complete in order. Default false.</param>
		void InsertMany(IEnumerable<T> models, bool bypassValidation, bool isOrdered);

		/// <summary>
		/// Updates a single Mongo entity matching the given filter.
		/// </summary>
		/// <param name="filter">The filter to use.</param>
		/// <param name="update">The update to apply.</param>
		/// <returns>The <see cref="UpdateResult"/> from the update operation.</returns>
		UpdateResult UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update);

		/// <summary>
		/// Updates a single Mongo entity matching the given filter.
		/// </summary>
		/// <param name="filter">The filter to use.</param>
		/// <param name="update">The update to apply.</param>
		/// <param name="options">The options to use when updating.</param>
		/// <returns>The <see cref="UpdateResult"/> from the update operation.</returns>
		UpdateResult UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options);

		/// <summary>
		/// Updates any Mongo entities matching the given filter.
		/// </summary>
		/// <param name="filter">The filter to use.</param>
		/// <param name="update">The update to apply.</param>
		/// <returns>The <see cref="UpdateResult"/> from the update operation.</returns>
		UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update);

		/// <summary>
		/// Updates any Mongo entities matching the given filter.
		/// </summary>
		/// <param name="filter">The filter to use.</param>
		/// <param name="update">The update to apply.</param>
		/// <param name="options">The options to use when updating.</param>
		/// <returns>The <see cref="UpdateResult"/> from the update operation.</returns>
		UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options);

		/// <summary>
		/// Deletes a single Mongo entity matching the given filter.
		/// </summary>
		/// <param name="filter">The filter to use.</param>
		/// <returns>The <see cref="DeleteResult"/> from the delete operation.</returns>
		DeleteResult DeleteOne(FilterDefinition<T> filter);

		/// <summary>
		/// Deletes a single Mongo entity matching the given filter.
		/// </summary>
		/// <param name="filter">The filter to use.</param>
		/// <param name="opts">The options to use when deleting.</param>
		/// <returns>The <see cref="DeleteResult"/> from the delete operation.</returns>
		DeleteResult DeleteOne(FilterDefinition<T> filter, DeleteOptions opts);

		/// <summary>
		/// Deletes any Mongo entities matching the given filter.
		/// </summary>
		/// <param name="filter">The filter to use.</param>
		/// <returns>The <see cref="DeleteResult"/> from the delete operation.</returns>
		DeleteResult DeleteMany(FilterDefinition<T> filter);

		/// <summary>
		/// Deletes any Mongo entities matching the given filter.
		/// </summary>
		/// <param name="filter">The filter to use.</param>
		/// <param name="opts">The options to use when deleting.</param>
		/// <returns>The <see cref="DeleteResult"/> from the delete operation.</returns>
		DeleteResult DeleteMany(FilterDefinition<T> filter, DeleteOptions opts);
	}
}
