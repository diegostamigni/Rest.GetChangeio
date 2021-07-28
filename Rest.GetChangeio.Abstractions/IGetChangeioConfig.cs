namespace Rest.GetChangeio.Abstractions
{
	public interface IGetChangeioConfig
	{
		public string? GetChangeioPublicKey { get; set; }

		public string? GetChangeioSecretKey { get; set; }
	}
}