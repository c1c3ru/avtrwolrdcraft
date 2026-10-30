namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "TokenRequest")]
[Preserve]
public class TokenRequest
{
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	internal enum TokenTypeOptions
	{
		VivoxJoin = 1,
		WireJoin = 2,
	}

	[CompilerGenerated]
	private readonly TokenTypeOptions <TokenType>k__BackingField; //Field offset: 0x10

	[DataMember(Name = "tokenType", IsRequired = True, EmitDefaultValue = True)]
	[JsonConverter(typeof(StringEnumConverter))]
	[Preserve]
	public TokenTypeOptions TokenType
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public TokenRequest(TokenTypeOptions tokenType) { }

	[CompilerGenerated]
	public TokenTypeOptions get_TokenType() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

