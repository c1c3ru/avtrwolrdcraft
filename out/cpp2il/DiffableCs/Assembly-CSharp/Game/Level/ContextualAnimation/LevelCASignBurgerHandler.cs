namespace Game.Level.ContextualAnimation;

public class LevelCASignBurgerHandler : LevelCAHandlerBase
{
	private const string GREETING_ANIMATION_NAME = "Greeting"; //Field offset: 0x0
	[SerializeField]
	private LevelAOScareRobotHandler _robot; //Field offset: 0x80
	private int _tweenId; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCASignBurgerHandler() { }

	[CompilerGenerated]
	private void <OnAnimationBegin>b__6_0() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

