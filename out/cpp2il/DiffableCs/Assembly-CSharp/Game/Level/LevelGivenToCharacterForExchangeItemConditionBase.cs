namespace Game.Level;

public abstract class LevelGivenToCharacterForExchangeItemConditionBase : MonoBehaviour
{
	private LevelGivenToCharacterForExchangeItemHandler[] conditionalExchangers; //Field offset: 0x20

	protected LevelGivenToCharacterForExchangeItemConditionBase() { }

	protected override void Awake() { }

	protected abstract void CanPlaceOnAvatarHands(ILevelAvatar avatar, LevelItem levelItem, ref bool canPlace) { }

	protected override void OnDestroy() { }

}

