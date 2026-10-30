namespace Game.Level.ContextualAnimation;

public class LevelCAToddlerTwinsStrollerItemHandler : LevelCAItemOnBoneHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public ICATarget babyOrToddler; //Field offset: 0x10
		public TrackEntryDelegate <>9__1; //Field offset: 0x18
		public TrackEntryDelegate <>9__2; //Field offset: 0x20

		public <>c__DisplayClass5_0() { }

		internal void <PutBabyToSleep>b__0() { }

		internal void <PutBabyToSleep>b__1(TrackEntry op) { }

		internal void <PutBabyToSleep>b__2(TrackEntry op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public ICATarget babyOrToddler; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal void <MayBabyCry>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public ICATarget babyOrToddler; //Field offset: 0x10
		public TrackEntryDelegate <>9__1; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <MakeBabyOrToddlerSmile>b__0() { }

		internal void <MakeBabyOrToddlerSmile>b__1(TrackEntry op) { }

	}

	[SerializeField]
	private LevelSitArea _leftToddler; //Field offset: 0x98
	[SerializeField]
	private LevelSitArea _rightToddler; //Field offset: 0xA0
	[SerializeField]
	private Vector2 _offsetVector; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCAToddlerTwinsStrollerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	private void MakeBabyOrToddlerSmile(ICATarget babyOrToddler) { }

	private void MayBabyCry(ICATarget babyOrToddler) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void PutBabyToSleep(ICATarget babyOrToddler) { }

}

