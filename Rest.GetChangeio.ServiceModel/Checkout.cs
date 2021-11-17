using System.Text.Json.Serialization;

namespace Rest.GetChangeio.ServiceModel
{
	public record Checkout(
		[property: JsonPropertyName("checkout_url")]
		string CheckoutUrl);
}