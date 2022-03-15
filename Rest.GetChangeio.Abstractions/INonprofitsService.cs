using System.Threading;
using System.Threading.Tasks;
using Rest.GetChangeio.Responses;
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
		Task<Nonprofit?> GetAsync(string id, CancellationToken token = default);

		/// <summary>
		/// Retrieves a list of nonprofits whose names match the provided name. This endpoint is paginated.
		/// </summary>
		/// <param name="name">A string to search.</param>
		/// <param name="page">The page to return. This endpoint is paginated, and returns up to 30 nonprofits at a time.</param>
		/// <param name="token"></param>
		/// <returns>A paginated list of nonprofits.</returns>
		Task<SearchNonprofitsResponse?> SearchAsync(string name, int page = 1, CancellationToken token = default);

		/// <summary>
		/// Retrieves a list of nonprofits whose names match the provided name. This endpoint is paginated.
		/// </summary>
		/// <param name="name">A string to search.</param>
		/// <param name="categories">List of categories to search. Valid categories are: 'arts and culture',
		/// 'education', 'environment', 'animals', 'healthcare', 'human services', 'international affairs',
		/// 'public benefit', 'religion', 'mutual benefit', 'unclassified'.</param>
		/// <param name="page">The page to return. This endpoint is paginated, and returns up to 30 nonprofits at a time.</param>
		/// <param name="token"></param>
		/// <returns>A paginated list of nonprofits.</returns>
		Task<SearchNonprofitsResponse?> SearchAsync(
			string name,
			string[] categories,
			int page = 1,
			CancellationToken token = default);

		/// <summary>
		/// Immediately starts a payout to a nonprofit. Normally, nonprofits are paid once per month.
		/// If you want a nonprofit to receive your donations sooner, use this endpoint. You will receive an invoice
		/// for the donation funds within 24 hours of using this endpoint.
		/// </summary>
		/// <param name="id">The id of a nonprofit from the CHANGE network.</param>
		/// <param name="token"></param>
		/// <returns>The payout created</returns>
		Task<CreateInstantPayoutResponse?> CreateInstantPayoutAsync(string id, CancellationToken token = default);

		/// <summary>
		/// Retrieves a list of instant payouts you've previously made that are either pending or complete for the
		/// last month. The instant payouts are returned in order of creation, with the most recent instant payouts
		/// appearing first.
		/// </summary>
		/// <param name="id">The id of a nonprofit from the CHANGE network.</param>
		/// <param name="token"></param>
		/// <returns>A list of instant payouts you've previously made</returns>
		Task<GetInstantPayoutsResponse?> GetInstantPayoutsAsync(string id, CancellationToken token = default);
	}
}