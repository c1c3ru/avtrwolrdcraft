namespace Unity.Services.Lobbies.Models;

[DataContract(Name = "TokenData")]
[Preserve]
public class TokenData
{
	[CompilerGenerated]
	private readonly string <TokenValue>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Uri>k__BackingField; //Field offset: 0x18

	[DataMember(Name = "tokenValue", EmitDefaultValue = False)]
	[Preserve]
	public string TokenValue
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "uri", EmitDefaultValue = False)]
	[Preserve]
	public string Uri
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public TokenData(string tokenValue = null, string uri = null) { }

	[CompilerGenerated]
	public string get_TokenValue() { }

	[CompilerGenerated]
	public string get_Uri() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

