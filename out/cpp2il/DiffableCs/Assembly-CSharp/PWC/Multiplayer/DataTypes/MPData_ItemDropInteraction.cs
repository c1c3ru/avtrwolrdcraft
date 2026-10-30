namespace PWC.Multiplayer.DataTypes;

public class MPData_ItemDropInteraction : MPData_ItemDropBase
{
	public MPEventIdentifierData idData; //Field offset: 0x50

	public MPData_ItemDropInteraction() { }

	public virtual void HandleReceviedData() { }

}

