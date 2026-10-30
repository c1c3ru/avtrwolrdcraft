namespace PWC.Multiplayer;

public static class MPDataHelper_ItemDragInteraction
{
	internal interface IInteractableItem : IMultiplayer_NetworkIdentityBase
	{

		public void Multiplayer_DragInteract(ILevelConsumer consumer, Multiplayer_EventType eventType, MPEventIdentifierData idData) { }

	}


	public static void HandleData(MPData_ItemDragInteraction data) { }

	public static void TrySendEvent(LevelItem item, GameObject dragActionHandler, ILevelConsumer consumer, Multiplayer_EventType eventType, MPEventIdentifierData idData) { }

}

