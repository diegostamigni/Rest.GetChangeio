using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Rest.GetChangeio.Abstractions;
using Shouldly;

namespace Rest.GetChangeio.Tests
{
	[TestFixture]
	public class NonprofitsServiceTests : BaseServiceTests<INonprofitsService>
	{
		[TestCase("n_RtPIV9h5M3TUeahbdKtoTE2B")]
		[TestCase("n_KFixbn9eozETVpFiKL7yh1Zp")]
		[TestCase("n_5rbqR6IYF9hqkqdIAgTJk05l")]
		[TestCase("n_ZaVKZ7i08qkbfxWI363FtgxN")]
		[TestCase("n_ur8IsL04GUxE2uaKqAgqpYlK")]
		public async Task GetNonprofit_Success(string id)
		{
			var result = await this.Service!.GetAsync(id);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Id.ShouldBe(id),
				() => result.PendingPayoutAmount.ShouldBe(0),
				() => result.Ein.ShouldNotBeEmpty()
			);
		}

		[Test]
		public Task GetNonprofit_Null_Id_ShouldThrow()
 #pragma warning disable 8625
			=> Should.ThrowAsync<ArgumentNullException>(() => this.Service!.GetAsync(null));
 #pragma warning restore 8625

		[TestCase("")]
		[TestCase("   ")]
		public Task GetNonprofit_Invalid_Id_ShouldThrow(string id)
 #pragma warning disable 8625
			=> Should.ThrowAsync<ArgumentException>(() => this.Service!.GetAsync(null));
 #pragma warning restore 8625

		[TestCase("invalid-id")]
		[TestCase("123123123")]
		public async Task GetNonprofit_Invalid_Id_NotFound_ReturnsNull(string id)
		{
			var result = await this.Service!.GetAsync(id);
			result.ShouldBeNull();
		}

		[TestCase("fcancer", "n_ur8IsL04GUxE2uaKqAgqpYlK")]
		[TestCase("thirst project", "n_ZaVKZ7i08qkbfxWI363FtgxN")]
		public async Task SearchNonprofits_Success(string name, string id)
		{
			var result = await this.Service!.SearchAsync(name);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Nonprofits.ShouldNotBeNull(),
				() => result.Nonprofits?.ShouldContain(x => x.Id == id)
			);
		}

		[TestCase("fcancer", "n_ur8IsL04GUxE2uaKqAgqpYlK", "healthcare", "environment")]
		[TestCase("fcancer", "n_ur8IsL04GUxE2uaKqAgqpYlK", "healthcare")]
		public async Task SearchNonprofits_Categories_Success(string name, string id, params string[] categories)
		{
			var result = await this.Service!.SearchAsync(name, categories);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Nonprofits.ShouldNotBeNull(),
				() => result.Nonprofits?.ShouldContain(x => x.Id == id)
			);
		}

		[TestCase("invalid-search")]
		public async Task SearchNonprofits_EmptyResult(string name)
		{
			var result = await this.Service!.SearchAsync(name);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Nonprofits.ShouldNotBeNull(),
				() => result.Nonprofits.ShouldBeEmpty()
			);
		}

		[Test]
		public Task SearchNonprofits_Null_Id_ShouldThrow()
 #pragma warning disable 8625
			=> Should.ThrowAsync<ArgumentNullException>(() => this.Service!.SearchAsync(null));
 #pragma warning restore 8625

		[Test]
		public async Task CreateInstantPayout_Success()
		{
			var result = await this.Service!.CreateInstantPayoutAsync("n_ur8IsL04GUxE2uaKqAgqpYlK");
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.InstantPayouts.ShouldNotBeNull(),
				() => result.InstantPayouts.ShouldBeEmpty()
			);
		}

		protected override INonprofitsService GetService()
			=> new NonprofitsService(this.ConfigMock!.Object);
	}
}
