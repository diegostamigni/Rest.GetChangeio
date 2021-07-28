using System.Text.Json.Serialization;

namespace Rest.GetChangeio.Requests
{
	public record CreateDonationRequest(
		[property: JsonPropertyName("nonprofit_id")]
		string NonprofitId,

		long Amount,

		[property:JsonPropertyName("funds_collected")]
		bool FundsCollected)
	{
		[JsonPropertyName("external_id")]
		public string? ExternalId { get; set; }

		[JsonPropertyName("zip_code")]
		public string? ZipCode { get; set; }

		[JsonPropertyName("order_value")]
		public string? OrderValue { get; set; }

		[JsonPropertyName("cover_fees")]
		public bool? CoverFees { get; set; }
	}
}