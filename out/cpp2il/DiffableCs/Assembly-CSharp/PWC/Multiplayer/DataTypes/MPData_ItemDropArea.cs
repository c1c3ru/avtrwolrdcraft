namespace PWC.Multiplayer.DataTypes;

public class MPData_ItemDropArea : MPData_ItemDropWithDestinationBase
{
	internal enum Type
	{
		None = 0,
		Tween = 1,
		Fall = 2,
		Snap = 3,
	}

	public Type type; //Field offset: 0x58
	[JsonProperty("dicd")]
	public MPOneCallGeneratorData dropOneCalldata; //Field offset: 0x60

	public MPData_ItemDropArea() { }

	public virtual void HandleReceviedData() { }

}

