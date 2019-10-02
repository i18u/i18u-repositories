using MongoDB.Bson;

namespace i18u.Repositories.Mongo.Results
{
    /// <summary>
    /// Represents the result of an insert operation.
    /// </summary>
    internal class InsertResult : Result, IInsertResult
    {
		/// <inheritdoc />
        public ObjectId[] Ids { get;  internal set; }
    }
}
