namespace Rest.GetChangeio.ServiceModel
{
	public record WebhookConversion
	{
		public long Amount { get; set; }

		public string? Currency { get; set; }
	}
}