namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerBottleItemHandler : LevelCAItemHandlerBase
{
	private const string HAPPILY_CLINKS_AGAINST_FLOOR_ANIMATION_NAME = "Happily_Clinks_Against_Floor"; //Field offset: 0x0
	private const string BOTTLE_SITS_SIPS_SATISFIED_ANIMATION_NAME = "Bottle_Sits_Sips_Satisfied"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88
	private LevelToddler _toddler; //Field offset: 0x90
	private string _interruptedAnimationName; //Field offset: 0x98

	public LevelCAToddlerBottleItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetAnimationSuffix() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationPostBegin(ICATarget target, LevelCAConfig config, TrackEntry trackEntry) { }

}

