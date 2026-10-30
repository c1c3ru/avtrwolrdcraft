namespace Game.Level;

public class LevelGivenToCharacterForExchangeItemOnceForEachAvatarConditionHandler : LevelGivenToCharacterForExchangeItemConditionBase, ILevelResetLevelWithItemData
{
	private const string DATA = "Recieved_Gift_Once"; //Field offset: 0x0
	[SerializeField]
	[Tooltip("A unique label to attach to the avatar receiving the gift.")]
	private string _giftLabel; //Field offset: 0x28

	public LevelGivenToCharacterForExchangeItemOnceForEachAvatarConditionHandler() { }

	protected virtual void CanPlaceOnAvatarHands(ILevelAvatar avatar, LevelItem levelItem, ref bool canPlace) { }

	private string KeyFromAvatar(int avatarID) { }

	private override void PWC.Level.ILevelResetLevelWithItemData.OnResetLevelWithItemData() { }

}

