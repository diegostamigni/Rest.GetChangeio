using System.Collections.Generic;
using Rest.GetChangeio.ServiceModel;

namespace Rest.GetChangeio.Responses
{
	public class SearchNonprofitsResponse
	{
		public List<Nonprofit>? Nonprofits { get; set; }

		public int Page { get; set; }
	}
}