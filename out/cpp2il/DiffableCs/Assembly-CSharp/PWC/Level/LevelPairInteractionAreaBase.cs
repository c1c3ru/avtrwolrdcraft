namespace PWC.Level;

public abstract class LevelPairInteractionAreaBase : LevelDropActionArea
{
	internal class Pair
	{
		public readonly LevelItem levelItem; //Field offset: 0x10
		public readonly LevelCAPairHandlerBase caHandler; //Field offset: 0x18

		public Pair(LevelItem levelItem, LevelCAPairHandlerBase caHandler) { }

	}

	private ICATarget _caTarget; //Field offset: 0x78
	private Pair _currentPair; //Field offset: 0x80

	public Pair CurrentPair
	{
		 get { } //Length: 8
	}

	protected ICATarget Target
	{
		 get { } //Length: 8
	}

	protected LevelPairInteractionAreaBase() { }

	protected virtual void Awake() { }

	protected virtual bool FilterItem(LevelItem levelItem) { }

	public Pair get_CurrentPair() { }

	protected ICATarget get_Target() { }

	protected override SkeletonAnimation GetSkeletonAnimation() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnItemEndLand(LevelItem levelItem) { }

	protected virtual void OnOwnerItemEndLand(List<LevelItem> levelItems) { }

	private void OnOwnerPostDetachFromParentIfExistsCall(LevelItem levelItem) { }

	private void OnPairItemPostDetachFromParentIfExistsCall(LevelItem levelItem) { }

	protected virtual bool ShouldListenToItemEndLandEvents() { }

	protected virtual bool ShouldPerformTestOnOwnerEndLand() { }

	public bool TryAddCAHandler(LevelItem levelItem) { }

	protected abstract bool TryGetCAHandlerForType(Type pairType, out Type caHandlerType) { }

	public bool TryRemoveCurrentCAHandler() { }

}

