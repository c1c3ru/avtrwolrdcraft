namespace Game.Level;

public class LevelGivenToCharacterForExchangeItemOnceBasedOnGuidConditionHandler : LevelGivenToCharacterForExchangeItemConditionBase, ILevelResetLevelWithItemData
{
	private const string DATA = "Recieved_Gift_Once"; //Field offset: 0x0

	public LevelGivenToCharacterForExchangeItemOnceBasedOnGuidConditionHandler() { }

	protected virtual void CanPlaceOnAvatarHands(ILevelAvatar avatar, LevelItem levelItem, ref bool canPlace) { }

	private string KeyFromlevelItem(LevelItem item) { }

	private override void PWC.Level.ILevelResetLevelWithItemData.OnResetLevelWithItemData() { }

}

