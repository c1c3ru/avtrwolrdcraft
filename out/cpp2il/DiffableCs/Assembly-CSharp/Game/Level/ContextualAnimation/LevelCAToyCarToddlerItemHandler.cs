namespace Game.Level.ContextualAnimation;

public class LevelCAToyCarToddlerItemHandler : LevelCAItemHandlerBase
{
	private const string PLAYING_WITH_TOY_CAR_ANIMATION_NAME = "Playing_With_Toy_Car"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88
	private LevelToddler _toddler; //Field offset: 0x90

	public LevelCAToyCarToddlerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetAnimationSuffix() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

