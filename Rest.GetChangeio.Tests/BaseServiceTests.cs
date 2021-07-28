using Moq;
using NUnit.Framework;
using Rest.GetChangeio.Abstractions;

namespace Rest.GetChangeio.Tests
{
	public abstract class BaseServiceTests<TService>
	{
		protected abstract TService GetService();

		protected TService? Service { get; private set; }

		protected Mock<IGetChangeioConfig>? ConfigMock { get; private set; }

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this.ConfigMock = new();
			this.ConfigMock
				.Setup(x => x.PublicKey)
				.Returns("pk_test_88c1d002fb2b2e4abddd2843e2819edf00ad26e9f97714f0a2a11853d7dfd53b");

			this.ConfigMock
				.Setup(x => x.SecretKey)
				.Returns("sk_test_6bca16406fc57fa62e18eb10eb80be1cbd2d955e81928a3e12cb4279d2d14016");
		}

		[SetUp]
		public void SetUp()
		{
			this.Service = GetService();
		}
	}
}