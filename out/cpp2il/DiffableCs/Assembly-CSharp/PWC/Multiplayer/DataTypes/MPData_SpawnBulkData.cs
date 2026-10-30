namespace PWC.Multiplayer.DataTypes;

public class MPData_SpawnBulkData : MPDataBase
{
	[JsonProperty("bData")]
	public BulkData bulkData; //Field offset: 0x28
	[JsonProperty("aData")]
	public List<MPAvatarData> avatarDatas; //Field offset: 0x30

	public MPData_SpawnBulkData() { }

	public virtual void HandleReceviedData() { }

}

