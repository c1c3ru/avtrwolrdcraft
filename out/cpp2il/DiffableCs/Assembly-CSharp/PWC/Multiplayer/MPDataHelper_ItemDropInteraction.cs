namespace PWC.Multiplayer;

public static class MPDataHelper_ItemDropInteraction
{
	internal interface IInteractableItem : IMultiplayer_NetworkIdentityBase
	{

		public void Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	}


	public static void HandleData(MPData_ItemDropInteraction data) { }

	public static void TrySendEvent(LevelItem item, ILevelConsumer consumer, MPEventIdentifierData idData) { }

}

