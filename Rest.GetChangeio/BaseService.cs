using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Rest.GetChangeio.Abstractions;

namespace Rest.GetChangeio
{
	public abstract class BaseService
	{
		private readonly IGetChangeioConfig config;
		private readonly IHttpClientFactory? httpClientFactory;

		protected string BaseUrl => $"https://api.getchange.io/api/v1/";

		protected Uri BaseUri => new Uri(this.BaseUrl);

		protected readonly JsonSerializerOptions JsonSerializerOptions = new()
		{
			PropertyNameCaseInsensitive = true,
			IgnoreNullValues = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		protected HttpClient HttpClient
		{
			get
			{
				var configuredHttpClient = this.httpClientFactory is not null
					? this.httpClientFactory.CreateClient()
					: new();

				if (configuredHttpClient is null)
				{
					throw new ArgumentNullException(nameof(configuredHttpClient), "Invalid http client");
				}

				var userAndPwd = $"{this.config.GetChangeioPublicKey}:{this.config.GetChangeioSecretKey}";
				var auth = $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes(userAndPwd))}";
				configuredHttpClient.DefaultRequestHeaders.Add("Authorization", auth);
				configuredHttpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
				return configuredHttpClient;
			}
		}

		protected BaseService(IGetChangeioConfig config)
		{
			this.config = config;
		}

		protected BaseService(IGetChangeioConfig config, IHttpClientFactory httpClientFactory)
		{
			this.config = config;
			this.httpClientFactory = httpClientFactory;
		}

		protected HttpRequestMessage CreateRequest<TRequest>(TRequest request, HttpMethod httpMethod, Uri requestUri)
		{
			var requestJson = JsonSerializer.Serialize(request, this.JsonSerializerOptions);
			return new(httpMethod, requestUri)
			{
				Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
			};
		}

		protected HttpRequestMessage CreateRequest<TRequest>(TRequest request, HttpMethod httpMethod, string requestUrl)
			=> CreateRequest(request, httpMethod, new Uri(requestUrl));
	}
}