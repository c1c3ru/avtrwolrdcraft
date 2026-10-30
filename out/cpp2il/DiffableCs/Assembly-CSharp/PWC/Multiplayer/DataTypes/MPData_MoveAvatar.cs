namespace PWC.Multiplayer.DataTypes;

public class MPData_MoveAvatar : MPDataBase
{
	[JsonProperty("aid")]
	public int avatarId; //Field offset: 0x28
	[JsonProperty("aData")]
	public MPAvatarData avatarData; //Field offset: 0x30
	[JsonProperty("tUID")]
	public int targetPlayerUID; //Field offset: 0x38
	[JsonProperty("mag")]
	public string moveAvatarGuid; //Field offset: 0x40
	[JsonProperty("asocd")]
	public MPOneCallGeneratorData avatarSpawnOneCallData; //Field offset: 0x48

	public MPData_MoveAvatar() { }

	public virtual void HandleReceviedData() { }

	public virtual bool ShouldHostHanldeData() { }

}

