namespace Unity.Services.Qos.V2.QosDiscovery;

[Preserve]
internal class GetAllServersRequest : QosDiscoveryApiBaseRequest
{
	[CompilerGenerated]
	private readonly Guid <XRequestId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <XUser>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly string <XUserType>k__BackingField; //Field offset: 0x28
	private string PathAndQueryParams; //Field offset: 0x30

	[Preserve]
	public Guid XRequestId
	{
		[CompilerGenerated]
		 get { } //Length: 12
	}

	[Preserve]
	public string XUser
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public string XUserType
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public GetAllServersRequest(Guid xRequestId = null, string xUser = null, string xUserType = null) { }

	public Byte[] ConstructBody() { }

	public Dictionary<String, String> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null) { }

	public string ConstructUrl(string requestBasePath) { }

	[CompilerGenerated]
	public Guid get_XRequestId() { }

	[CompilerGenerated]
	public string get_XUser() { }

	[CompilerGenerated]
	public string get_XUserType() { }

}

