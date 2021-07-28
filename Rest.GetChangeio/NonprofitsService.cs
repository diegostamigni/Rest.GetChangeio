using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Rest.GetChangeio.Abstractions;
using Rest.GetChangeio.Responses;
using Rest.GetChangeio.ServiceModel;

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

		public async Task<Nonprofit?> GetAsync(string id, CancellationToken token = default)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}

			if (string.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentException(nameof(id));
			}

			var uri = new Uri(this.BaseUri, $"nonprofits/{id}");

			using var httpClient = this.HttpClient;
			using var stream = await httpClient.GetStreamAsync(uri);

			var result = await JsonSerializer.DeserializeAsync<Nonprofit>(stream, this.JsonSerializerOptions, token);
			return result;
		}

		public async Task<SearchNonprofitsResponse?> SearchAsync(string name, int page, CancellationToken token = default)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			var uri = new Uri(this.BaseUri, $"nonprofits?name={name}&page={page}");

			using var httpClient = this.HttpClient;
			using var stream = await httpClient.GetStreamAsync(uri);

			var result = await JsonSerializer.DeserializeAsync<SearchNonprofitsResponse>(stream, this.JsonSerializerOptions, token);
			return result;
		}
	}
}