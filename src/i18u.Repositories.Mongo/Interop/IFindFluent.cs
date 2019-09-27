using System.Collections.Generic;
using System.Threading;
using MongoDB.Driver;

namespace i18u.Repositories.Mongo.Interop
{
	/// <summary>
	/// Represents a MongoDB fluent find operation.
	/// </summary>
	/// <typeparam name="T1">Source type</typeparam>
	/// <typeparam name="T2">Projected type</typeparam>
	public interface IFindFluent<T1, T2>
    {
	    /// <inheritdoc cref="MongoDB.Driver.IFindFluent{TDocument,TProjection}.Filter"/>
	    FilterDefinition<T1> Filter { get; set; }

	    /// <inheritdoc cref="MongoDB.Driver.IFindFluent{TDocument,TProjection}.CountDocuments"/>
	    long CountDocuments(CancellationToken cancellationToken);

	    /// <inheritdoc cref="MongoDB.Driver.IFindFluent{TDocument,TProjection}.Limit"/>
	    IFindFluent<T1, T2> Limit(int? limit);

	    /// <inheritdoc cref="MongoDB.Driver.IFindFluent{TDocument,TProjection}.Skip"/>
	    IFindFluent<T1, T2> Skip(int? skip);

		/// <inheritdoc cref="MongoDB.Driver.IFindFluent{TDocument,TProjection}.Project"/>
        IFindFluent<T1, TProjection> Project<TProjection>(ProjectionDefinition<T1, TProjection> projection);

		/// <inheritdoc cref="MongoDB.Driver.IAsyncCursorSourceExtensions.ToList{T2}"/>
        IList<T2> ToList();
    }
}
