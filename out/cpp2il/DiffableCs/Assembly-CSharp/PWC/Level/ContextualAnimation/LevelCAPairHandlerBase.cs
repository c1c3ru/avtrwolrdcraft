namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAPairHandlerBase : LevelCAHandlerBase
{
	[CompilerGenerated]
	private static Action<ICATarget, LevelItem, LevelCAConfig> OnAnimationBeginWithPairItemAction; //Field offset: 0x0
	private ICATarget _owner; //Field offset: 0x80
	private LevelItem _pairLevelItem; //Field offset: 0x88
	private SkeletonAnimation _ownerSkeletonAnimation; //Field offset: 0x90
	private readonly Dictionary<String, Bone> _cachedBones; //Field offset: 0x98

	public static event Action<ICATarget, LevelItem, LevelCAConfig> OnAnimationBeginWithPairItemAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	protected ICATarget Owner
	{
		 get { } //Length: 8
	}

	protected SkeletonAnimation OwnerSkeletonAnimation
	{
		 get { } //Length: 8
	}

	protected LevelItem PairLevelItem
	{
		 get { } //Length: 8
	}

	protected LevelCAPairHandlerBase() { }

	[CompilerGenerated]
	public static void add_OnAnimationBeginWithPairItemAction(Action<ICATarget, LevelItem, LevelCAConfig> value) { }

	protected virtual void Awake() { }

	protected ICATarget get_Owner() { }

	protected SkeletonAnimation get_OwnerSkeletonAnimation() { }

	protected LevelItem get_PairLevelItem() { }

	protected Bone GetOwnerBone(string boneName) { }

	protected Vector2 GetOwnerBoneWorldPosition(string boneName) { }

	public virtual int GetPriority() { }

	public void Init(ICATarget owner, LevelItem pairLevelItem, SkeletonAnimation ownerSkeletonAnimation) { }

	protected void InvokeOnAnimationBeginWithPairItem(LevelCAConfig config) { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	private void OnAnimationBeginWithPairItem(ICATarget caTarget, LevelItem pairLevelItem, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_OnAnimationBeginWithPairItemAction(Action<ICATarget, LevelItem, LevelCAConfig> value) { }

}

