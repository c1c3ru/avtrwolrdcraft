namespace PWC.Multiplayer.DataTypes;

public class MPData_SpawnAvatar : MPDataBase
{
	[JsonProperty("aid")]
	public int avatarId; //Field offset: 0x28
	[JsonProperty("aData")]
	public MPAvatarData avatarData; //Field offset: 0x30
	[JsonProperty("pos")]
	public PJVector2 position; //Field offset: 0x38
	[JsonProperty("parent")]
	public string parentSceneGuid; //Field offset: 0x40
	[JsonProperty("pOverride")]
	public string prefabGuidOverride; //Field offset: 0x48
	[JsonProperty("asocd")]
	public MPOneCallGeneratorData avatarSpawnOneCallData; //Field offset: 0x50

	public MPData_SpawnAvatar() { }

	public virtual void HandleReceviedData() { }

}

