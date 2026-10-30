namespace PWC.Multiplayer.DataTypes;

public class MPData_MoveAvatarRequest : MPDataBase
{
	[JsonProperty("aid")]
	public int avatarId; //Field offset: 0x28
	[JsonProperty("mag")]
	public string moveAvatarGuid; //Field offset: 0x30

	public MPData_MoveAvatarRequest() { }

	public virtual void HandleReceviedData() { }

}

