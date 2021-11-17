using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rest.GetChangeio.Requests
{
	/// <summary>
	/// Creates a Stripe Checkout link to collect donations for a specific nonprofit.
	/// Donation processing fees are automatically deducted from the collected amount.
	/// </summary>
	/// <param name="Amount">The amount of the donation in cents.</param>
	/// <param name="NonprofitId">The id of a nonprofit from the Change network.</param>
	public record CreateCryptoCheckoutRequest(
		long Amount,

		[property: JsonPropertyName("nonprofit_id")]
		string NonprofitId)
	{
		/// <summary>
		/// A set of key-value pairs that you can attach to a donation.
		/// This information will be returned in a webhook upon successful payment.
		/// </summary>
		public Dictionary<string, string>? Metadata { get; set; }
	}
}