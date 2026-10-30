namespace PWC.Multiplayer;

public static class MPDataHelper_ItemDropCharacterInteraction
{
	internal interface IInteractableItem : IMultiplayer_NetworkIdentityBase
	{

		public void Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	}


	public static void HandleData(MPData_ItemDropCharacterInteraction data) { }

	public static void TrySendEvent(LevelItem item, LevelCharacter character, MPEventIdentifierData idData) { }

}

