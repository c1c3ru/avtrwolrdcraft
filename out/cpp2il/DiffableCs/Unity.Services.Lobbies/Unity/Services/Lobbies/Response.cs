namespace Unity.Services.Lobbies;

internal class Response
{
	[CompilerGenerated]
	private readonly Dictionary<String, String> <Headers>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private long <Status>k__BackingField; //Field offset: 0x18

	public Dictionary<String, String> Headers
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public long Status
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public Response(HttpClientResponse httpResponse) { }

	[CompilerGenerated]
	public Dictionary<String, String> get_Headers() { }

	[CompilerGenerated]
	public long get_Status() { }

	[CompilerGenerated]
	public void set_Status(long value) { }

}

