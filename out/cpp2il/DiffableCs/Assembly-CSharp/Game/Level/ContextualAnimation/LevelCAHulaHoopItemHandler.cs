namespace Game.Level.ContextualAnimation;

public class LevelCAHulaHoopItemHandler : LevelCAItemWithSkinHandlerBase
{
	[SerializeField]
	private string _skinId; //Field offset: 0xB0
	[SerializeField]
	private Sprite _thumbSprite; //Field offset: 0xB8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC0

	public LevelCAHulaHoopItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual string GetSkinName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected virtual void OnSkinAdded() { }

	protected virtual void OnSkinRemoved() { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

}

