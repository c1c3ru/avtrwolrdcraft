namespace Game.Level.ContextualAnimation;

public class LevelCACookingPanItemHandler : LevelCAItemHandlerBase
{
	[SerializeField]
	private LevelTwoStateHangHandler _stateHandler; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCACookingPanItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

