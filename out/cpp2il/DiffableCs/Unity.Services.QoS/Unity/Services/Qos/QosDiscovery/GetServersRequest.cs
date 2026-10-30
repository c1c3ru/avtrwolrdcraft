namespace Unity.Services.Qos.QosDiscovery;

[Preserve]
internal class GetServersRequest : QosDiscoveryApiBaseRequest
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, String> <>9__7_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <.ctor>b__7_0(string v) { }

	}

	[CompilerGenerated]
	private readonly List<String> <Region>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Service>k__BackingField; //Field offset: 0x18
	private string PathAndQueryParams; //Field offset: 0x20

	[Preserve]
	public List<String> Region
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public string Service
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public GetServersRequest(List<String> region = null, string service = null) { }

	public Byte[] ConstructBody() { }

	public Dictionary<String, String> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null) { }

	public string ConstructUrl(string requestBasePath) { }

	[CompilerGenerated]
	public List<String> get_Region() { }

	[CompilerGenerated]
	public string get_Service() { }

}

