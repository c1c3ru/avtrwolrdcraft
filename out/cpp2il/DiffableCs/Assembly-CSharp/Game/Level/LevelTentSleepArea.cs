namespace Game.Level;

public class LevelTentSleepArea : LevelSleepArea
{
	private LevelCharacter _currentCharacter; //Field offset: 0x80

	public LevelTentSleepArea() { }

	private void BackSkinsSetTransparent(bool value) { }

	public virtual void OnAvatarBeginDrop(ILevelAvatar avatar) { }

	public virtual void OnAvatarPickUp(ILevelAvatar avatar) { }

	public void OnTentFolded() { }

	private void SetCharacterMasked(bool value) { }

}

