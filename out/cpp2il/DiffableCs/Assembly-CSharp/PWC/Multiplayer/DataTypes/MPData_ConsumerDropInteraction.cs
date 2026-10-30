namespace PWC.Multiplayer.DataTypes;

public class MPData_ConsumerDropInteraction : MPData_ItemDropBase
{
	public MPEventIdentifierData idData; //Field offset: 0x50

	public MPData_ConsumerDropInteraction() { }

	public virtual void HandleReceviedData() { }

}

