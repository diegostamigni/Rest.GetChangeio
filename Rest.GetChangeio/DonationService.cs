using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Rest.GetChangeio.Abstractions;
using Rest.GetChangeio.Requests;
using Rest.GetChangeio.Responses;
using Rest.GetChangeio.ServiceModel;

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

		public async Task<Donation?> CreateAsync(CreateDonationRequest request, CancellationToken token = default)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			using var httpClient = this.HttpClient;
			using var httpRequestMessage = CreateRequest(request, HttpMethod.Post, new Uri(BaseUri, "donations"));

			using var response = await httpClient.SendAsync(httpRequestMessage, token);
			await using var stream = await response.Content.ReadAsStreamAsync();

			var result = await JsonSerializer.DeserializeAsync<Donation>(stream, this.JsonSerializerOptions, token);
			return result;
		}

		public async Task<Donation?> GetAsync(string id, CancellationToken token = default)
		{
			if (id is null)
			{
				throw new ArgumentNullException(nameof(id));
			}

			if (string.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentException(nameof(id));
			}

			var uri = new Uri(BaseUri, $"donations/{id}");

			using var httpClient = this.HttpClient;
			await using var stream = await httpClient.GetStreamAsync(uri);

			var result = await JsonSerializer.DeserializeAsync<Donation>(stream, this.JsonSerializerOptions, token);
			return result;
		}

		public async Task<GetDonationsResponse?> GetAllAsync(int page = 1, CancellationToken token = default)
		{
			var uri = new Uri(BaseUri, $"donations?page={page}");

			using var httpClient = this.HttpClient;
			await using var stream = await httpClient.GetStreamAsync(uri);

			var result = await JsonSerializer.DeserializeAsync<GetDonationsResponse>(stream, this.JsonSerializerOptions, token);
			return result;
		}
	}
}