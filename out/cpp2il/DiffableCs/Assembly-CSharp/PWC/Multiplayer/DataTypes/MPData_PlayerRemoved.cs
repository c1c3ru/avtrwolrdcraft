namespace PWC.Multiplayer.DataTypes;

public class MPData_PlayerRemoved : MPDataBase
{
	[JsonProperty("pUID")]
	public int playerUID; //Field offset: 0x28

	public MPData_PlayerRemoved() { }

	public virtual void HandleReceviedData() { }

}

