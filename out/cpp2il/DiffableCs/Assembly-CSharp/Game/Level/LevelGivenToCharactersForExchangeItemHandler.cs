namespace Game.Level;

[HideParentPropertiesInInspector(new IL2CPP_TYPE_STRING[] {"_characterID"})]
public class LevelGivenToCharactersForExchangeItemHandler : LevelGivenToCharacterForExchangeItemHandler
{
	[Header("Characters That Can Accept The Gift")]
	[SerializeField]
	[Space]
	private List<Int32> _characterIds; //Field offset: 0x98

	public LevelGivenToCharactersForExchangeItemHandler() { }

	public virtual ReadOnlyCollection<Int32> GetAvatarIds() { }

	protected virtual void OnPlacedOnAvatarWithHands(ILevelAvatar avatar, ItemOnAvatarType type, MethodGivenToCharacter givenMethod) { }

}

