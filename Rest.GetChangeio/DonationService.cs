using System.Net.Http;
using Rest.GetChangeio.Abstractions;

namespace Rest.GetChangeio
{
	public class DonationService : BaseService, IDonationService
	{
		public DonationService(IGetChangeioConfig config)
			: base(config)
		{
		}

		public DonationService(IGetChangeioConfig config, IHttpClientFactory httpClientFactory)
			: base(config, httpClientFactory)
		{
		}
	}
}