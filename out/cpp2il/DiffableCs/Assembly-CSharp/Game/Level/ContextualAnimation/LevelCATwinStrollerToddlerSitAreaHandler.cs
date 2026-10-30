namespace Game.Level.ContextualAnimation;

public class LevelCATwinStrollerToddlerSitAreaHandler : LevelCAParentHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public ICATarget otherCATarget; //Field offset: 0x10
		public LevelCATwinStrollerToddlerSitAreaHandler <>4__this; //Field offset: 0x18
		public LevelCAConfig config; //Field offset: 0x20

		public <>c__DisplayClass5_0() { }

		internal void <OnAnimationBegin>b__0() { }

		internal void <OnAnimationBegin>b__1() { }

	}

	[SerializeField]
	private LevelSitArea _otherSitArea; //Field offset: 0x80
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x88
	private readonly List<String> _reactionBabyAnimations; //Field offset: 0x90
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"name", "loop"})]
	private readonly List<ValueTuple`2<String, Boolean>> _reactionToddlerAnimations; //Field offset: 0x98
	private readonly List<Single> _reactionDelayTimes; //Field offset: 0xA0

	public LevelCATwinStrollerToddlerSitAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual string GetSpacialTrackAnimationName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

