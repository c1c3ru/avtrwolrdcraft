namespace Game.Level;

public class LevelSleepingBagSleepArea : LevelSleepArea
{
	[SerializeField]
	private GameObject _mask; //Field offset: 0x80
	[SerializeField]
	private Vector3 _finalScale; //Field offset: 0x88
	private Vector3 _initialScale; //Field offset: 0x94
	private LevelCharacter _currentlyHeldCharacter; //Field offset: 0xA0

	public LevelSleepingBagSleepArea() { }

	private void AnimateMask(bool value) { }

	protected virtual void Awake() { }

	public virtual void OnAvatarEndDrop(ILevelAvatar avatar) { }

	public virtual void OnAvatarPickUp(ILevelAvatar avatar) { }

	public void SetCharacterMasked(bool value) { }

}

