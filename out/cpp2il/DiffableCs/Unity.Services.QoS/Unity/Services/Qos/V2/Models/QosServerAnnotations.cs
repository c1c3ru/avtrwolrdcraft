namespace Unity.Services.Qos.V2.Models;

[DataContract(Name = "QosServerAnnotations")]
[Preserve]
public class QosServerAnnotations
{
	[CompilerGenerated]
	private readonly List<String> <ProjectId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly List<String> <EnvironmentId>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly List<String> <RelayRegionId>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly List<String> <MultiplayRegionId>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private readonly List<String> <MultiplayFleetId>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private readonly List<String> <MatchmakerQueueName>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private readonly List<String> <MatchmakerPoolId>k__BackingField; //Field offset: 0x40

	[DataMember(Name = "environmentId", EmitDefaultValue = False)]
	[Preserve]
	public List<String> EnvironmentId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "matchmakerPoolId", EmitDefaultValue = False)]
	[Preserve]
	public List<String> MatchmakerPoolId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "matchmakerQueueName", EmitDefaultValue = False)]
	[Preserve]
	public List<String> MatchmakerQueueName
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "multiplayFleetId", EmitDefaultValue = False)]
	[Preserve]
	public List<String> MultiplayFleetId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "multiplayRegionId", EmitDefaultValue = False)]
	[Preserve]
	public List<String> MultiplayRegionId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "projectId", EmitDefaultValue = False)]
	[Preserve]
	public List<String> ProjectId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DataMember(Name = "relayRegionId", EmitDefaultValue = False)]
	[Preserve]
	public List<String> RelayRegionId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public QosServerAnnotations(List<String> projectId = null, List<String> environmentId = null, List<String> relayRegionId = null, List<String> multiplayRegionId = null, List<String> multiplayFleetId = null, List<String> matchmakerQueueName = null, List<String> matchmakerPoolId = null) { }

	[CompilerGenerated]
	public List<String> get_EnvironmentId() { }

	[CompilerGenerated]
	public List<String> get_MatchmakerPoolId() { }

	[CompilerGenerated]
	public List<String> get_MatchmakerQueueName() { }

	[CompilerGenerated]
	public List<String> get_MultiplayFleetId() { }

	[CompilerGenerated]
	public List<String> get_MultiplayRegionId() { }

	[CompilerGenerated]
	public List<String> get_ProjectId() { }

	[CompilerGenerated]
	public List<String> get_RelayRegionId() { }

	internal Dictionary<String, String> GetAsQueryParam() { }

	internal string SerializeAsPathParam() { }

}

