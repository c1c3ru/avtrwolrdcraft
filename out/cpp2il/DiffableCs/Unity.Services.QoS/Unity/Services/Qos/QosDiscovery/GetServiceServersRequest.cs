namespace Unity.Services.Qos.QosDiscovery;

[Preserve]
internal class GetServiceServersRequest : QosDiscoveryApiBaseRequest
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, String> <>9__12_0; //Field offset: 0x8
		public static Func<String, String> <>9__12_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <.ctor>b__12_0(string v) { }

		internal string <.ctor>b__12_1(string v) { }

	}

	public const string ServiceIdRelay = "relay"; //Field offset: 0x0
	public const string ServiceIdMultiplay = "multiplay"; //Field offset: 0x0
	[CompilerGenerated]
	private readonly string <ServiceId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly List<String> <Region>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly List<String> <Fleet>k__BackingField; //Field offset: 0x20
	private string PathAndQueryParams; //Field offset: 0x28

	[Preserve]
	public List<String> Fleet
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public List<String> Region
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public string ServiceId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public GetServiceServersRequest(string serviceId, List<String> region = null, List<String> fleet = null) { }

	public Byte[] ConstructBody() { }

	public Dictionary<String, String> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null) { }

	public string ConstructUrl(string requestBasePath) { }

	[CompilerGenerated]
	public List<String> get_Fleet() { }

	[CompilerGenerated]
	public List<String> get_Region() { }

	[CompilerGenerated]
	public string get_ServiceId() { }

}

