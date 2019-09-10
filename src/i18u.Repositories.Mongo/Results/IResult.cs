using System;

namespace i18u.Repositories.Mongo.Results
{
    /// <summary>
    /// Represents a result from a MongoDB operation
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// The time taken to perform the operation.
        /// </summary>
        TimeSpan TimeTaken { get; }

        /// <summary>
        /// The number of documents affected by the operation.
        /// </summary>
        long DocumentsAffected { get; }
    }
}
