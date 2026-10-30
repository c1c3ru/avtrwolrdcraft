namespace Game.Level;

[AddComponentMenu(null)]
public class LevelMaskedSitArea : LevelSitArea
{
	[SerializeField]
	private bool _isVisibleInsideMask; //Field offset: 0x88

	public LevelMaskedSitArea() { }

	protected virtual void Awake() { }

	public virtual void OnAvatarEndDrop(ILevelAvatar avatar) { }

	public virtual void OnAvatarPickUp(ILevelAvatar avatar) { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	public void RemoteSetAvatarMasked() { }

	public void SetAvatarMasked(ILevelAvatar avatar, bool value) { }

}

