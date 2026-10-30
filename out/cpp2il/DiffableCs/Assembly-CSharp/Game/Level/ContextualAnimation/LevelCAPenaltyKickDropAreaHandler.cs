namespace Game.Level.ContextualAnimation;

public class LevelCAPenaltyKickDropAreaHandler : LevelCADropAreaHandlerBase
{
	[SerializeField]
	private LevelRunningAreaSingleItemCharactersOnlyDropArea _goalKeeperDropArea; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCAPenaltyKickDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

