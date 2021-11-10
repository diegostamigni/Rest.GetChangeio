using System.Collections.Generic;
using System.Text.Json.Serialization;
using Rest.GetChangeio.ServiceModel;

namespace Rest.GetChangeio.Responses
{
	public class CreateInstantPayoutResponse
	{
		[JsonPropertyName("instant_payouts")]
		public List<InstantPayout>? InstantPayouts { get; set; }
	}
}