namespace Unity.Services.Authentication.PlayerAccounts;

public class BaseJwt
{
	[JsonProperty("exp")]
	public int ExpirationTimeUnix; //Field offset: 0x10
	[JsonProperty("iat")]
	public int IssuedAtTimeUnix; //Field offset: 0x14
	[JsonProperty("nbf")]
	public int NotBeforeTimeUnix; //Field offset: 0x18

	[JsonIgnore]
	public DateTime ExpirationTime
	{
		 get { } //Length: 8
	}

	[JsonIgnore]
	public DateTime IssuedAtTime
	{
		 get { } //Length: 8
	}

	[JsonIgnore]
	public DateTime NotBeforeTime
	{
		 get { } //Length: 8
	}

	[Preserve]
	internal BaseJwt() { }

	internal DateTime ConvertTimestamp(int timestamp) { }

	public DateTime get_ExpirationTime() { }

	public DateTime get_IssuedAtTime() { }

	public DateTime get_NotBeforeTime() { }

}

