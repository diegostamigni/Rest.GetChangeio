using System.Text.Json.Serialization;
using Rest.GetChangeio.ServiceModel;

namespace Rest.GetChangeio.Responses;

public class CreateNonprofitResponse
{
	[JsonPropertyName("result")]
	public Nonprofit? Nonprofit { get; set; }
}