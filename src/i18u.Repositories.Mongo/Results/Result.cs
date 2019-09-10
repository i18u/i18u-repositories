using System;

namespace i18u.Repositories.Mongo.Results
{
    /// <inheritdoc />
    internal class Result : IResult
    {
        /// <inheritdoc />
        public TimeSpan TimeTaken { get; internal set; }

        /// <inheritdoc />
        public long DocumentsAffected { get; internal set; }
    }
}