namespace Game.Level.ContextualAnimation;

public class LevelCADogOnToddlerHandler : LevelCAPetOnToddlerHandlerBase
{
	private const string PET_ANIMATION_GROUP = "Toddler_Held_Standing_Interactions"; //Field offset: 0x0
	private const string HOLDING_PET_ANIMATION_NAME = "Toddler_Held_Standing_Interactions/Holding_Dog"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCADogOnToddlerHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetAnimationSuffix() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite sprite) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

