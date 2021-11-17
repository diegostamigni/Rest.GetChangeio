using System.Text.Json.Serialization;

namespace Rest.GetChangeio.Requests
{
	/// <summary>
	/// Creates a Stripe Checkout link to collect donations for a specific nonprofit.
	/// Donation processing fees are automatically deducted from the collected amount.
	/// </summary>
	/// <param name="Amount">The amount of the donation in cents.</param>
	/// <param name="NonprofitId">The id of a nonprofit from the Change network.</param>
	/// <param name="SuccessUrl">The url the donor will be redirected to upon a successful donation.</param>
	/// <param name="CancelUrl">The url the donor will be redirected to if they cancel checkout.</param>
	public record CreateCheckoutRequest(
		long Amount,

		[property: JsonPropertyName("nonprofit_id")]
		string NonprofitId,

		[property: JsonPropertyName("success_url")]
		string SuccessUrl,

		[property: JsonPropertyName("cancel_url")]
		string CancelUrl);
}