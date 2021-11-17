using System.Threading;
using System.Threading.Tasks;
using Rest.GetChangeio.Requests;
using Rest.GetChangeio.ServiceModel;

namespace Rest.GetChangeio.Abstractions
{
	public interface IPaymentsService
	{
		/// <summary>
		/// Creates a Stripe Checkout link to collect donations for a specific nonprofit.
		/// Donation processing fees are automatically deducted from the collected amount.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		Task<Checkout?> CreateCheckoutAsync(CreateCheckoutRequest request, CancellationToken token = default);

		/// <summary>
		/// Creates a Coinbase Checkout link to collect donations for a specific nonprofit. Donation processing fees
		/// are automatically deducted from the collected amount. Accepted currencies include Bitcoin, Bitcoin Cash,
		/// Dai, Dogecoin, Ethereum, Litecoin, and USD Coin.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		Task<Checkout?> CreateCryptoCheckoutAsync(CreateCryptoCheckoutRequest request, CancellationToken token = default);
	}
}