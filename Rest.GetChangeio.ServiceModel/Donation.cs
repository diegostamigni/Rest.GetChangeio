using System.Text.Json.Serialization;

namespace Rest.GetChangeio.ServiceModel
{
	public record Donation(string Id, long Amount)
	{
		[JsonPropertyName("live_mode")]
		public bool? LiveMode { get; set; }

		[JsonPropertyName("merchant_id")]
		public string? MerchantId { get; set; }

		[JsonPropertyName("nonprofit_id")]
		public string? NonprofitId { get; set; }

		[JsonPropertyName("order_value")]
		public int? OrderValue { get; set; }

		[JsonPropertyName("zip_code")]
		public string? ZipCode { get; set; }

		[JsonPropertyName("external_id")]
		public string? ExternalId { get; set; }
	}
}