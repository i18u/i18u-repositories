using System.Threading;
using MongoDB.Driver;

namespace i18u.Repositories.Mongo.Interop
{
	/// <summary>
	/// A MongoDB fluent find operation.
	/// </summary>
	/// <typeparam name="T1">Source type.</typeparam>
	/// <typeparam name="T2">Projected type.</typeparam>
	public class FindFluent<T1, T2> : IFindFluent<T1, T2>
	{
		/// <inheritdoc />
		public FilterDefinition<T1> Filter { get; set; }

		/// <summary>
		/// The <see cref="MongoDB.Driver.IFindFluent{T1,T2}"/> to use.
		/// </summary>
		private readonly MongoDB.Driver.IFindFluent<T1, T2> _fluentFind;

		/// <summary>
		/// Creates a new instance of the <see cref="FindFluent{T1,T2}" /> class.
		/// </summary>
		/// <param name="fluentFind"></param>
		public FindFluent(MongoDB.Driver.IFindFluent<T1, T2> fluentFind)
		{
			_fluentFind = fluentFind;
		}

		/// <inheritdoc />
		public long CountDocuments(CancellationToken cancellationToken)
		{
			return _fluentFind.CountDocuments(cancellationToken);
		}

		/// <inheritdoc />
		public IFindFluent<T1, T2> Limit(int? limit)
		{
			return _fluentFind.Limit(limit);
		}

		/// <inheritdoc />
		public IFindFluent<T1, T2> Skip(int? skip)
		{
			throw new System.NotImplementedException();
		}
	}
}
