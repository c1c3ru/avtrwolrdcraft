namespace Game.Level.ContextualAnimation;

public class LevelCABabyTwinsStrollerItemHandler : LevelCAItemOnBoneHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public LevelBaby levelBaby; //Field offset: 0x10
		public TrackEntryDelegate <>9__1; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <PutBabyToSleep>b__0() { }

		internal void <PutBabyToSleep>b__1(TrackEntry op) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public LevelBaby levelBaby; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal void <MayBabyCry>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public LevelBaby levelBaby; //Field offset: 0x10
		public TrackEntryDelegate <>9__1; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <MakeBabySmile>b__0() { }

		internal void <MakeBabySmile>b__1(TrackEntry op) { }

	}

	[SerializeField]
	private LevelBabyDropArea _leftBaby; //Field offset: 0x98
	[SerializeField]
	private LevelBabyDropArea _rightBaby; //Field offset: 0xA0
	[SerializeField]
	private Vector2 _offsetVector; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xB0

	public LevelCABabyTwinsStrollerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	private void MakeBabySmile(LevelBaby levelBaby) { }

	private void MayBabyCry(LevelBaby levelBaby) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	private void PutBabyToSleep(LevelBaby levelBaby) { }

}

