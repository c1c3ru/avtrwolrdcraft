namespace Game.Level.ContextualAnimation;

public class LevelCAAirHockeyPlayerDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelCAAirHockeyPlayerDropAreaHandler <>4__this; //Field offset: 0x10
		public LevelHockeyStrikerItemHandler striker; //Field offset: 0x18

		public <>c__DisplayClass4_0() { }

		internal void <OnAnimationBegin>b__0(float t) { }

	}

	[SerializeField]
	private LevelSingleItemCharactersOnlyDropArea _otherPlayerDropArea; //Field offset: 0x80
	[SerializeField]
	private LevelHockeyDropArea _airHockeyField; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCAAirHockeyPlayerDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

