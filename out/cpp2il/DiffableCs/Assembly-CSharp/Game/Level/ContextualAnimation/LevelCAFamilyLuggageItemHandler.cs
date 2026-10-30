namespace Game.Level.ContextualAnimation;

public class LevelCAFamilyLuggageItemHandler : LevelCAItemHandlerWithData
{
	[SerializeField]
	private Sprite _tiltedSprite; //Field offset: 0x90
	[SerializeField]
	private Sprite _normalSprite; //Field offset: 0x98
	[SerializeField]
	private Transform _tiledTagHangPoint; //Field offset: 0xA0
	[SerializeField]
	private LevelHangArea _tagHangArea; //Field offset: 0xA8
	[SerializeField]
	private LevelDoor _door; //Field offset: 0xB0
	[SerializeField]
	private Sprite _thumbSprite; //Field offset: 0xB8
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0xC0
	private Vector3 _currentHangPoint; //Field offset: 0xC8

	public LevelCAFamilyLuggageItemHandler() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void SetSpriteToBack() { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

