namespace Game.Level;

[AddComponentMenu(null)]
public class LevelConsoleController : LevelItemOnCharacterBase
{
	private enum ColorType
	{
		None = 0,
		White = 1,
		Black = 2,
	}

	[SerializeField]
	private ColorType _colorType; //Field offset: 0x358

	public LevelConsoleController() { }

	protected virtual string GetCharacterAnimationName() { }

	protected virtual string GetCharacterBoneName() { }

	public virtual void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

}

