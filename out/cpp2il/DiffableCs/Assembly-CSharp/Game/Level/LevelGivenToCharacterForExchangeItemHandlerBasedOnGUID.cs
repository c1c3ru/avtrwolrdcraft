namespace Game.Level;

public class LevelGivenToCharacterForExchangeItemHandlerBasedOnGUID : LevelGivenToCharacterForExchangeItemHandler, ILevelResetLevelWithItemData
{
	private string _prefabGuid; //Field offset: 0x98

	public LevelGivenToCharacterForExchangeItemHandlerBasedOnGUID() { }

	protected virtual void Awake() { }

	protected override string GetBulkDataKey() { }

	protected virtual void OnAcceptedByCharacter() { }

	protected virtual void OnPlacedOnAvatarWithHands(ILevelAvatar avatar, ItemOnAvatarType type, MethodGivenToCharacter givenMethod) { }

	private override void PWC.Level.ILevelResetLevelWithItemData.OnResetLevelWithItemData() { }

}

