namespace PWC.Inventory;

public class InventoryData
{
	[JsonProperty("prefabGuids")]
	private readonly HashSet<String> _prefabGuids; //Field offset: 0x10
	[JsonProperty("flags")]
	private readonly Dictionary<String, Int32> _flags; //Field offset: 0x18
	[JsonProperty("achievements")]
	private readonly HashSet<String> _achievements; //Field offset: 0x20
	[CompilerGenerated]
	private bool <IsDirty>k__BackingField; //Field offset: 0x28

	[JsonIgnore]
	public bool IsDirty
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public InventoryData() { }

	public void AddAchievement(string achievementId) { }

	public bool AddFlag(string flag, int count) { }

	public bool AddPrefabGuid(string prefabGuid) { }

	public bool ContainsAchievement(string achievementId) { }

	public bool ContainsFlag(string flag) { }

	public bool ContainsPrefabGuid(string prefabGuid) { }

	[CompilerGenerated]
	public bool get_IsDirty() { }

	public int GetFlagCount(string flag) { }

	public IReadOnlyCollection<String> GetReadOnlyAchievements() { }

	public IReadOnlyDictionary<String, Int32> GetReadOnlyFlags() { }

	public IReadOnlyCollection<String> GetReadOnlyPrefabGuids() { }

	public void LogData() { }

	[CompilerGenerated]
	public void set_IsDirty(bool value) { }

}

