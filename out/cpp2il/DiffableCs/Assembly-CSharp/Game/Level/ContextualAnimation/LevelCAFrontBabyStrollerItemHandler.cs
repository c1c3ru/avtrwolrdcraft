namespace Game.Level.ContextualAnimation;

public class LevelCAFrontBabyStrollerItemHandler : LevelCAItemOnBoneHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public ICATarget babyOrToddler; //Field offset: 0x10
		public TrackEntryDelegate <>9__1; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal void <MakeBabyOrToddlerSmile>b__0() { }

		internal void <MakeBabyOrToddlerSmile>b__1(TrackEntry op) { }

	}

	[SerializeField]
	private LevelSitArea _sit; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCAFrontBabyStrollerItemHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	protected virtual string GetBoneName() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual SpineType GetSpineType() { }

	private void MakeBabyOrToddlerSmile(ICATarget babyOrToddler) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

