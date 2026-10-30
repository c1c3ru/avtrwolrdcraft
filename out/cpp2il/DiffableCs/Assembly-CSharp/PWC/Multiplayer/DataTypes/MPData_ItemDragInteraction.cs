namespace PWC.Multiplayer.DataTypes;

public class MPData_ItemDragInteraction : MPData_ItemInteractionBase
{
	public Multiplayer_EventType eventType; //Field offset: 0x50
	public MPEventIdentifierData idData; //Field offset: 0x58

	public MPData_ItemDragInteraction() { }

	public virtual void HandleReceviedData() { }

}

