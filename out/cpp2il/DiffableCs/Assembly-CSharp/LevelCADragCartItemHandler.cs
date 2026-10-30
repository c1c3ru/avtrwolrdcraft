//Type is in global namespace

public class LevelCADragCartItemHandler : LevelCAItemOnBoneHandlerBase
{
	[SerializeField]
	private Sprite _sprite; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCADragCartItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

