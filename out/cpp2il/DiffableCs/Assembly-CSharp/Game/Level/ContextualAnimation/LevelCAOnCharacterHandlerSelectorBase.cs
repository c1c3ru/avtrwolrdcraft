namespace Game.Level.ContextualAnimation;

public abstract class LevelCAOnCharacterHandlerSelectorBase : MonoBehaviour
{
	private static readonly Dictionary<String, Boolean> _texturePathCache; //Field offset: 0x0
	protected LevelItem _levelItem; //Field offset: 0x20

	private static LevelCAOnCharacterHandlerSelectorBase() { }

	protected LevelCAOnCharacterHandlerSelectorBase() { }

	protected abstract void AddCarrierHandler(LevelCharacter character) { }

	protected override void Awake() { }

	protected bool IsReleventTextureInAvatar(LevelCharacter character, out string skinName) { }

	private void OnBeforePlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected override void OnDestroy() { }

	private void OnLevelPostInit() { }

}

