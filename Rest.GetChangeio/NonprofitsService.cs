using System.Net.Http;
using Rest.GetChangeio.Abstractions;

namespace Rest.GetChangeio
{
	public class NonprofitsService : BaseService, INonprofitsService
	{
		public NonprofitsService(IGetChangeioConfig config)
			: base(config)
		{
		}

		public NonprofitsService(IGetChangeioConfig config, IHttpClientFactory httpClientFactory)
			: base(config, httpClientFactory)
		{
		}
	}
}