using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Rest.GetChangeio.Abstractions;
using Shouldly;

namespace Rest.GetChangeio.Tests
{
	[TestFixture]
	public class DonationServiceTests : BaseServiceTests<IDonationService>
	{
		[TestCase("n_RtPIV9h5M3TUeahbdKtoTE2B", 12311, true)]
		[TestCase("n_KFixbn9eozETVpFiKL7yh1Zp", 12312, true)]
		[TestCase("n_5rbqR6IYF9hqkqdIAgTJk05l", 12313, true)]
		[TestCase("n_ZaVKZ7i08qkbfxWI363FtgxN", 12314, true)]
		[TestCase("n_ur8IsL04GUxE2uaKqAgqpYlK", 12315, true)]
		[TestCase("n_RtPIV9h5M3TUeahbdKtoTE2B", 12321, false)]
		[TestCase("n_KFixbn9eozETVpFiKL7yh1Zp", 12322, false)]
		[TestCase("n_5rbqR6IYF9hqkqdIAgTJk05l", 12323, false)]
		[TestCase("n_ZaVKZ7i08qkbfxWI363FtgxN", 12324, false)]
		[TestCase("n_ur8IsL04GUxE2uaKqAgqpYlK", 12325, false)]
		public async Task CreateDonation_Success(string id, long amount, bool fundsCollected)
		{
			var result = await this.Service!.CreateAsync(new(id, amount, fundsCollected));
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Id.ShouldNotBeNullOrEmpty(),
				() => result.Amount.ShouldBe(amount),
				() => result.NonprofitId.ShouldBe(id)
			);
		}

		[TestCase("d_kOQTmkYRrCdB7R5GnhjFGWfm")]
		public async Task GetDonation_Success(string id)
		{
			var result = await this.Service!.GetAsync(id);
			result.ShouldNotBeNull();
			result.Id.ShouldBe(id);
		}

		[Test]
		public Task GetDonation_Null_Id_ShouldThrow()
 #pragma warning disable 8625
			=> Should.ThrowAsync<ArgumentNullException>(() => this.Service!.GetAsync(null));
 #pragma warning restore 8625

		[TestCase("")]
		[TestCase("   ")]
		public Task GetDonation_Invalid_Id_ShouldThrow(string id)
 #pragma warning disable 8625
			=> Should.ThrowAsync<ArgumentException>(() => this.Service!.GetAsync(null));
 #pragma warning restore 8625

		[TestCase("invalid-id")]
		[TestCase("123123123")]
		public Task GetDonation_Invalid_Id_NotFound_ShouldThrow(string id)
 #pragma warning disable 8625
			=> Should.ThrowAsync<HttpRequestException>(() => this.Service!.GetAsync(id));
 #pragma warning restore 8625

		[Test]
		public async Task GetDonations_Success()
		{
			var result = await this.Service!.GetAllAsync();
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Donations.ShouldNotBeNull(),
				() => result.Donations.ShouldNotBeEmpty()
			);
		}

		protected override IDonationService GetService()
			=> new DonationService(this.ConfigMock!.Object);
	}
}