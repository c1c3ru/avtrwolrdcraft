namespace Game.Level.ContextualAnimation;

public class LevelCASignRobotHandler : LevelCAHandlerBase
{
	private const string GREETING_ANIMATION_NAME = "Greeting"; //Field offset: 0x0
	[SerializeField]
	private LevelAOScareRobotHandler _robot; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88

	public LevelCASignRobotHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

