using System.Collections.Generic;
using System.Text.Json.Serialization;
using Rest.GetChangeio.Enums;

namespace Rest.GetChangeio.Requests;

/// <summary>
/// Requests a nonprofit.
/// </summary>
/// <param name="Name">The name of the nonprofit.</param>
/// <param name="Ein">The EIN of the nonprofit.</param>
public record CreateNonprofitRequest(
	[property: JsonPropertyName("name")]
	string Name,

	[property: JsonPropertyName("ein")]
	string Ein)
{
	/// <summary>
	/// The address of the nonprofit.
	/// </summary>
	[JsonPropertyName("address_line")]
	public string? AddressLine { get; set; }

	/// <summary>
	/// The city the nonprofit is in.
	/// </summary>
	public string? City { get; set; }

	/// <summary>
	/// The state the nonprofit is in.
	/// </summary>
	public string? State { get; set; }

	/// <summary>
	/// The NTEE code for the nonprofit.
	/// </summary>
	public string? Classification { get; set; }

	/// <summary>
	/// The mission of the nonprofit.
	/// </summary>
	public string? Mission { get; set; }

	/// <summary>
	/// The social handles of the nonprofit. Accepted keys are: facebook, instagram, tiktok, twitter, youtube.
	/// </summary>
	public Dictionary<SocialType, string>? Socials { get; set; }

	/// <summary>
	/// The website of the nonprofit.
	/// </summary>
	public string? Website { get; set; }

	/// <summary>
	/// A contact email for the nonprofit.
	/// </summary>
	[JsonPropertyName("admin_email")]
	public string? AdminEmail { get; set; }

	/// <summary>
	/// An email address to use for the nonprofit's payouts.
	/// </summary>
	[JsonPropertyName("payout_email")]
	public string? PayoutEmail { get; set; }

	/// <summary>
	/// The URL of an image that represents the nonprofit
	/// </summary>
	[JsonPropertyName("image_url")]
	public string? ImageUrl { get; set; }
}