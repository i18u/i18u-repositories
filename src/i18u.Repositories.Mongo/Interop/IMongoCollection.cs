using MongoDB.Driver;

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
    }
}
