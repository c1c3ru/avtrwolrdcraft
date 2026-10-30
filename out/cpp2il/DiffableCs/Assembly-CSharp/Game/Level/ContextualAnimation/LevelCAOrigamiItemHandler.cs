namespace Game.Level.ContextualAnimation;

public abstract class LevelCAOrigamiItemHandler : LevelCAItemHandlerBase
{
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	protected LevelCAOrigamiItemHandler() { }

	protected List<LevelCAConfig> GetCAConfigsWithBase(LevelCAConfig config) { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

