namespace Game.Level.ContextualAnimation;

public class LevelCAKettleItemHandler : LevelCAPouringItemHandler
{
	private const string TOUCHING_HOT_ANIMATION_NAME = "Touching_It_Is_Hot"; //Field offset: 0x0
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAKettleItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

