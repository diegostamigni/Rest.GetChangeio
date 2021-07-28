using System.Collections.Generic;
using Rest.GetChangeio.ServiceModel;

namespace Rest.GetChangeio.Responses
{
	public class GetDonationsResponse
	{
		public List<Donation>? Donations { get; set; }

		public int Page { get; set; }
	}
}