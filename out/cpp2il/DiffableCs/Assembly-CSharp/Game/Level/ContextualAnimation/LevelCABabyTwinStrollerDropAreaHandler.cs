namespace Game.Level.ContextualAnimation;

public class LevelCABabyTwinStrollerDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public ICATarget otherBaby; //Field offset: 0x10
		public LevelCABabyTwinStrollerDropAreaHandler <>4__this; //Field offset: 0x18
		public int index; //Field offset: 0x20

		public <>c__DisplayClass4_0() { }

		internal void <OnAnimationBegin>b__0() { }

	}

	[SerializeField]
	private LevelBabyDropArea _otherBabyDropArea; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88
	private readonly List<String> _reactionAnimations; //Field offset: 0x90
	private readonly List<Single> _reactionDelayTimes; //Field offset: 0x98

	public LevelCABabyTwinStrollerDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

}

