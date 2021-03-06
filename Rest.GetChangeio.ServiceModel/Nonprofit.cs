using System.Collections.Generic;
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

		/// <summary>
		/// Dictionary of currency and amount.
		/// Ex: USD: 1.234
		/// </summary>
		[JsonPropertyName("pending_payout_amounts")]
		public Dictionary<string, object>? PendingPayoutAmounts { get; set; }

		[JsonPropertyName("address_line")]
		public string? AddressLine { get; set; }

		public string? City { get; set; }

		public string? Classification { get; set; }

		public string? Mission { get; set; }

		public string? State { get; set; }

		public string? Website { get; set; }

		[JsonPropertyName("zip_code")]
		public string? ZipCode { get; set; }

		public string? Category { get; set; }

		public string? Email { get; set; }

		public Dictionary<string, string>? Socials { get; set; }
	}
}