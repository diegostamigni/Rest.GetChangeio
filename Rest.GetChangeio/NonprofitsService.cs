using System;
using System.Linq;
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
			if (id is null)
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

		public Task<SearchNonprofitsResponse?> SearchAsync(string name, int page, CancellationToken token = default)
			=> SearchAsync(name, Array.Empty<string>(), page, token);

		public async Task<SearchNonprofitsResponse?> SearchAsync(
			string name,
			string[] categories,
			int page = 1,
			CancellationToken token = default)
		{
			if (name is null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (categories is null)
			{
				throw new ArgumentNullException(nameof(categories));
			}

			var path = categories
				.Select(x => x.Trim())
				.Aggregate($"nonprofits?name={name}&page={page}", (current, category) => $"{current}&categories[]={category}");

			var uri = new Uri(this.BaseUri, path);

			using var httpClient = this.HttpClient;
			using var stream = await httpClient.GetStreamAsync(uri);

			var result = await JsonSerializer.DeserializeAsync<SearchNonprofitsResponse>(stream, this.JsonSerializerOptions, token);
			return result;
		}
	}
}