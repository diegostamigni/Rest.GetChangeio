using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Rest.GetChangeio.ServiceModel;

namespace Rest.GetChangeio.Abstractions
{
	/// <summary>
	/// Most U.S. nonprofits exist in the CHANGE platform. Each nonprofit has a CHANGE-issued ID;
	/// these IDs are used to reference nonprofits throughout our APIs. You can search for nonprofits manually on
	/// the dashboard, or you can search programmatically.
	/// </summary>
	public interface INonprofitsService
	{
		/// <summary>
		/// Retrieves information for a nonprofit.
		/// </summary>
		/// <param name="id">The id of a nonprofit from the CHANGE network.</param>
		/// <param name="token"></param>
		/// <returns></returns>
		Task<Nonprofit?> GetAsync([NotNull] string id, CancellationToken token = default);

		/// <summary>
		/// Retrieves a list of nonprofits whose names match the provided name. This endpoint is paginated.
		/// </summary>
		/// <param name="name">A string to search.</param>
		/// <param name="page">The page to return. This endpoint is paginated, and returns up to 30 nonprofits at a time.</param>
		/// <param name="token"></param>
		/// <returns>A paginated list of nonprofits.</returns>
		Task<SearchNonprofitsResponse?> SearchAsync(
			[NotNull] string name,
			int page = 1,
			CancellationToken token = default);
	}
}