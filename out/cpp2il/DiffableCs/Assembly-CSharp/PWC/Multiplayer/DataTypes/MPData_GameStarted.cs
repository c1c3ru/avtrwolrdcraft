namespace PWC.Multiplayer.DataTypes;

public class MPData_GameStarted : MPDataBase
{
	[JsonProperty("picData")]
	public AvatarSpineData avatarSpineDataForPicture; //Field offset: 0x28
	[JsonProperty("carsData")]
	public List<AvatarSpineData> carsSpineData; //Field offset: 0x30

	public MPData_GameStarted() { }

	public virtual void HandleReceviedData() { }

}

