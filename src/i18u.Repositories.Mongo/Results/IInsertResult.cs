using MongoDB.Bson;

namespace i18u.Repositories.Mongo.Results
{
    /// <summary>
    /// The result of an insert operation.
    /// </summary>
    public interface IInsertResult : IResult
    {
        /// <summary>
        /// The IDs generated from the insert operation.
        /// </summary>
        ObjectId[] Ids { get; }
    }
}