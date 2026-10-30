namespace PWC.Multiplayer.DataTypes;

public class MPData_ItemDropCharacterInteraction : MPData_ItemDropBase
{
	public MPEventIdentifierData idData; //Field offset: 0x50

	public MPData_ItemDropCharacterInteraction() { }

	public virtual void HandleReceviedData() { }

}

