using System.Text.Json.Serialization;

namespace Rest.GetChangeio.ServiceModel
{
	public record Nonprofit(string Id)
	{
		[JsonPropertyName("icon_url")]
		public string? IconUrl { get; set; }

		public string? Name { get; set; }

		public string? Ein { get; set; }

		public string? Memo { get; set; }

		[JsonPropertyName("pending_payout_amount")]
		public long? PendingPayoutAmount { get; set; }

		[JsonPropertyName("address_line")]
		public string? AddressLine { get; set; }

		public string? City { get; set; }

		public string? Classification { get; set; }

		public string? Mission { get; set; }

		public string? State { get; set; }

		public string? Website { get; set; }

		[JsonPropertyName("zip_code")]
		public string? ZipCode { get; set; }
	}
}