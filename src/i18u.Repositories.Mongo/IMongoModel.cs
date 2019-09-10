using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace i18u.Repositories.Mongo
{
    /// <summary>
    /// An entity stored in Mongo.
    /// </summary>
    public interface IMongoModel
    {
        /// <summary>
        /// The non-unique _id field.
        /// </summary>
        [BsonId]
        ObjectId Id { get; set; }
    }
}