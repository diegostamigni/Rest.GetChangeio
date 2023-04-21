using System.Text.Json.Serialization;

namespace Rest.GetChangeio.Enums;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SocialType
{
	Facebook,
	Instagram,
	TikTok,
	Twitter,
	YouTube
}