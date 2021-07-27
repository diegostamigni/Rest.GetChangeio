namespace Rest.GetChangeio.Abstractions
{
	public interface IGetChangeioConfig
	{
		public string? PublicKey { get; set; }

		public string? SecretKey { get; set; }
	}
}