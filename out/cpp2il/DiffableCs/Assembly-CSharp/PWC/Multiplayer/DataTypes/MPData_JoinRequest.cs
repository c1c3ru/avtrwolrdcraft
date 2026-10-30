namespace PWC.Multiplayer.DataTypes;

public class MPData_JoinRequest : MPDataBase
{
	[JsonProperty("bn")]
	public int buildNumber; //Field offset: 0x28

	public MPData_JoinRequest() { }

	public virtual void HandleReceviedData() { }

}

