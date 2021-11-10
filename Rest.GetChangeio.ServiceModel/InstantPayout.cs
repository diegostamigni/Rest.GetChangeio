namespace Rest.GetChangeio.ServiceModel
{
	public record InstantPayout
	{
		public string? Name { get; set; }

		public string? AccountId { get; set; }

		public long? Amount { get; set; }

		public string? Status { get; set; }
	}
}