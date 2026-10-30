namespace Unity.Services.Qos.Models;

[DataContract(Name = "QosServer")]
[Preserve]
internal class QosServer
{
	[CompilerGenerated]
	private readonly List<String> <Endpoints>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <Region>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly List<String> <Services>k__BackingField; //Field offset: 0x20

	[DataMember(Name = "endpoints", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public List<String> Endpoints
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "region", IsRequired = True, EmitDefaultValue = True)]
	[Preserve]
	public string Region
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "services", EmitDefaultValue = False)]
	[Preserve]
	public List<String> Services
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QosServer(List<String> endpoints, string region, List<String> services = null) { }

	[CompilerGenerated]
	public List<String> get_Endpoints() { }

	[CompilerGenerated]
	public string get_Region() { }

	[CompilerGenerated]
	public List<String> get_Services() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

