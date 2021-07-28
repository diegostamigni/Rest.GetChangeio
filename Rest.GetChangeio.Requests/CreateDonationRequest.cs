using System.Text.Json.Serialization;

namespace Rest.GetChangeio.Requests
{
	/// <summary>
	///
	/// </summary>
	/// <param name="NonprofitId">The id of a nonprofit from the CHANGE network.</param>
	/// <param name="Amount">The amount of the donation in cents.</param>
	/// <param name="FundsCollected">Whether you are collecting payment for the donation.
	/// This helps us issue the correct tax receipt at the end of the year.</param>
	public record CreateDonationRequest(
		[property: JsonPropertyName("nonprofit_id")]
		string NonprofitId,

		long Amount,

		[property:JsonPropertyName("funds_collected")]
		bool FundsCollected)
	{
		/// <summary>
		/// An external ID associated with the donation, e.g. an order ID, SKU, or customer ID.
		/// </summary>
		[JsonPropertyName("external_id")]
		public string? ExternalId { get; set; }

		/// <summary>
		/// A zip code to associate with the donation. CHANGE provides geography-based analytics if zip codes are provided.
		/// </summary>
		[JsonPropertyName("zip_code")]
		public string? ZipCode { get; set; }

		/// <summary>
		/// Cart or order volume (in cents) associated with the donation. CHANGE provides AOV metrics if order values are provided.
		/// </summary>
		[JsonPropertyName("order_value")]
		public string? OrderValue { get; set; }

		/// <summary>
		/// Whether the amount parameter should include processing fees. Default is false.
		/// </summary>
		[JsonPropertyName("cover_fees")]
		public bool? CoverFees { get; set; }
	}
}