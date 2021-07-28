using System.Collections.Generic;

namespace Rest.GetChangeio.ServiceModel
{
	public class SearchNonprofitsResponse
	{
		public List<Nonprofit>? Nonprofits { get; set; }

		public int Page { get; set; }
	}
}