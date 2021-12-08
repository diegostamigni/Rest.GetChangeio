namespace Rest.GetChangeio.ServiceModel
{
	public record WebhookConversion
	{
		public decimal? Amount { get; set; }

		public string? Currency { get; set; }
	}
}