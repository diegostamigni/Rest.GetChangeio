namespace Rest.GetChangeio.ServiceModel
{
	public record InstantPayout
	{
		public string? Name { get; set; }

		public string? AccountId { get; set; }

		public decimal? Amount { get; set; }

		public string? Status { get; set; }
	}
}