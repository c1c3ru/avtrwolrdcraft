namespace PWC.Multiplayer;

public static class MPDataHelper_ConsumerDropInteraction
{
	internal interface IInteractableItem : IMultiplayer_NetworkIdentityBase
	{

		public void Multiplayer_ConsumerDropInteract(LevelItem levelItem, MPEventIdentifierData idData) { }

	}


	public static void HandleData(MPData_ConsumerDropInteraction data) { }

	public static void TrySendEvent(LevelItem item, ILevelConsumer consumer, MPEventIdentifierData idData) { }

}

