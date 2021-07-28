using System.Threading;
using System.Threading.Tasks;
using Rest.GetChangeio.Requests;
using Rest.GetChangeio.Responses;
using Rest.GetChangeio.ServiceModel;

namespace Rest.GetChangeio.Abstractions
{
	/// <summary>
	/// To create a donation, use the /donations/create endpoint.
	/// In the response, you'll get a donation ID, which you can use to retrieve information about your donation.
	/// We also have endpoints that simplify making carbon offset donations.
	/// </summary>
	public interface IDonationService
	{
		/// <summary>
		/// Creates a donation to any nonprofit. CHANGE keeps track of your donations, bills you at the end of the month,
		/// and handles the nonprofit payouts for you.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="token"></param>
		/// <returns>The resulting donation.</returns>
		Task<Donation?> CreateAsync(CreateDonationRequest request, CancellationToken token = default);

		/// <summary>
		/// Retrieves the details of a donation you've previously made.
		/// </summary>
		/// <param name="id">The id of a donation. Ids are returned when a donation is created.</param>
		/// <param name="token"></param>
		/// <returns>The requested donation.</returns>
		Task<Donation?> GetAsync(string id, CancellationToken token = default);

		/// <summary>
		/// Retrieves a list of donations you've previously made. The donations are returned in order of creation,
		/// with the most recent donations appearing first. This endpoint is paginated.
		/// </summary>
		/// <param name="page">Which page to return. This endpoint is paginated, and returns maximum 30 donations per page.</param>
		/// <param name="token"></param>
		/// <returns>Retrieves a list of donations you've previously made.</returns>
		Task<GetDonationsResponse?> GetAllAsync(int page = 1, CancellationToken token = default);
	}
}