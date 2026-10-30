namespace Game.Level.ContextualAnimation;

public class LevelCASqueezerItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelPouringItemHandler _squeezer; //Field offset: 0x88
	private readonly Single[2] _startAndEndDelayForLiquidParticles; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCASqueezerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void StartPouring() { }

	private void StopPouring() { }

}

