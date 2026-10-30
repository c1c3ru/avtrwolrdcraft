namespace Game.Level.ContextualAnimation;

public class LevelCADogOnCharacterHandler : LevelCAPetOnCharacterHandlerBase
{
	private const string DOG_HOLDING_CAT_ANIMATION_NAME = "Avatar_Interactions_Held/Holding_Dog"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCADogOnCharacterHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	protected virtual Nullable<Vector2> GetPivotOnBone() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

