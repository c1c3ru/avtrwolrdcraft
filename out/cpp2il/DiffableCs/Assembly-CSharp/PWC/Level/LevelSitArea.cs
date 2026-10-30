namespace PWC.Level;

public class LevelSitArea : LevelAvatarRestAreaBase
{
	private LevelMakerItem _parentMakerItem; //Field offset: 0x78
	private LevelItem _parentLevelItem; //Field offset: 0x80

	public LevelSitArea() { }

	protected virtual void Awake() { }

	public virtual ILevelAvatar GetFirstAvatar() { }

	public virtual bool HasItemsOnSelf() { }

	public virtual bool IsAvailableForAvatar() { }

	protected virtual void OnDestroy() { }

	private void OnSyncIsFlippedStateAction(LevelItem _, bool state) { }

	private void OnSyncIsFlippedStateAction(LevelMakerItem _, bool state) { }

}

