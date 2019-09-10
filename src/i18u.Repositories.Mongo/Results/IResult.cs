using System;

namespace i18u.Repositories.Mongo.Results
{
    /// <summary>
    /// Repesents a result from a mongo operation
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