namespace Unity.Services.Authentication;

internal class BaseJwt
{
	[JsonProperty("exp")]
	public int ExpirationTimeUnix; //Field offset: 0x10
	[JsonProperty("iat")]
	public int IssuedAtTimeUnix; //Field offset: 0x14
	[JsonProperty("nbf")]
	public int NotBeforeTimeUnix; //Field offset: 0x18

	[JsonIgnore]
	public Nullable<DateTime> ExpirationTime
	{
		 get { } //Length: 8
	}

	[JsonIgnore]
	public Nullable<DateTime> IssuedAtTime
	{
		 get { } //Length: 8
	}

	[JsonIgnore]
	public Nullable<DateTime> NotBeforeTime
	{
		 get { } //Length: 8
	}

	[Preserve]
	public BaseJwt() { }

	protected Nullable<DateTime> ConvertTimestamp(int timestamp) { }

	public Nullable<DateTime> get_ExpirationTime() { }

	public Nullable<DateTime> get_IssuedAtTime() { }

	public Nullable<DateTime> get_NotBeforeTime() { }

}

