namespace Game.Level;

public class LevelGivenToCharacterForExchangeItemWithBroadcastSystem : LevelGivenToCharacterForExchangeItemHandlerBasedOnGUID
{
	[SerializeField]
	private SecretFullId _secretToCheck; //Field offset: 0xA0

	public LevelGivenToCharacterForExchangeItemWithBroadcastSystem() { }

	protected virtual void OnPlacedOnAvatarWithHands(ILevelAvatar avatar, ItemOnAvatarType type, MethodGivenToCharacter givenMethod) { }

}

