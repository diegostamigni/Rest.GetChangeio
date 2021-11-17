using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Rest.GetChangeio.Abstractions;
using Rest.GetChangeio.Requests;
using Shouldly;

namespace Rest.GetChangeio.Tests
{
	[TestFixture]
	public class PaymentsServiceTests : BaseServiceTests<IPaymentsService>
	{
		[TestCase("n_ur8IsL04GUxE2uaKqAgqpYlK")]
		public async Task CreateCheckout_Success(string nonprofitId)
		{
			var request = new CreateCheckoutRequest(1000, nonprofitId, "http://example.com/success", "http://example.com/cancel");
			var result = await this.Service!.CreateCheckoutAsync(request);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.CheckoutUrl.ShouldNotBeNullOrEmpty()
			);
		}

		[Explicit("Service is currently in beta and enabled for specific API keys.")]
		[TestCase("n_ur8IsL04GUxE2uaKqAgqpYlK")]
		public async Task CreateCryptoCheckout_Success(string nonprofitId)
		{
			var request = new CreateCryptoCheckoutRequest(1000, nonprofitId)
			{
				Metadata = new()
				{
					{ "external_id", Guid.NewGuid().ToString("N") }
				}
			};

			var result = await this.Service!.CreateCryptoCheckoutAsync(request);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.CheckoutUrl.ShouldNotBeNullOrEmpty()
			);
		}
		protected override IPaymentsService GetService()
			=> new PaymentsService(this.ConfigMock!.Object);
	}
}