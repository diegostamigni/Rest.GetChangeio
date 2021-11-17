using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Rest.GetChangeio.Abstractions;
using Rest.GetChangeio.Requests;
using Rest.GetChangeio.ServiceModel;

namespace Rest.GetChangeio
{
	public class PaymentsService : BaseService, IPaymentsService
	{
		public PaymentsService(IGetChangeioConfig config) : base(config)
		{
		}

		public PaymentsService(IGetChangeioConfig config, IHttpClientFactory httpClientFactory)
			: base(config, httpClientFactory)
		{
		}

		public Task<Checkout?> CreateCheckoutAsync(
			CreateCheckoutRequest request,
			CancellationToken token = default) => CreateCheckoutAsync(request, "payments/checkout_link", token);

		public Task<Checkout?> CreateCryptoCheckoutAsync(
			CreateCryptoCheckoutRequest request,
			CancellationToken token = default) => CreateCheckoutAsync(request, "payments/crypto_checkout_link", token);

		private async Task<Checkout?> CreateCheckoutAsync<TRequest>(
			TRequest request,
			string endpointUrl,
			CancellationToken token = default)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			using var httpClient = this.HttpClient;
			using var httpRequestMessage = CreateRequest(request, HttpMethod.Post, new Uri(this.BaseUri, endpointUrl));

			using var response = await httpClient.SendAsync(httpRequestMessage, token);
			await using var stream = await response.Content.ReadAsStreamAsync();

			var result = await JsonSerializer.DeserializeAsync<Checkout>(stream, this.JsonSerializerOptions, token);
			return result;
		}
	}
}