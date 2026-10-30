namespace PWC.Multiplayer.DataTypes;

public abstract class MPData_ItemDropWithDestinationBase : MPData_ItemDropBase
{
	[JsonProperty("pos")]
	public PJVector2 position; //Field offset: 0x50

	protected MPData_ItemDropWithDestinationBase() { }

}

