namespace Game.Level;

[AddComponentMenu(null)]
public class LevelBroom : LevelItemOnCharacterBase
{

	public LevelBroom() { }

	protected virtual string GetCharacterAnimationName() { }

	protected virtual string GetCharacterBoneName() { }

	public virtual void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

}

