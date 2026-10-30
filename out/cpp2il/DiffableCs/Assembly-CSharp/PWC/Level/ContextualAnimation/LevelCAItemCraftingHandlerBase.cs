namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAItemCraftingHandlerBase : LevelCAItemHandlerBase, ILevelHintBubbleLeadingTarget, ILevelHintBubbleTarget
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public LevelCAItemCraftingHandlerBase <>4__this; //Field offset: 0x10
		public ILevelHasHands handsOwner; //Field offset: 0x18

		public <>c__DisplayClass18_0() { }

		internal void <OnItemPlacedOnAvatar>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass27_0
	{
		public LevelCAItemCraftingHandlerBase <>4__this; //Field offset: 0x10
		public LevelHintBubbleType hintBubbleType; //Field offset: 0x18
		public int matchId; //Field offset: 0x1C

		public <>c__DisplayClass27_0() { }

		internal bool <OnAddedToTarget>b__0(SubMatch subMatch) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass27_1
	{
		public bool shouldGetOutcomesFromPacks; //Field offset: 0x10
		public string packPrefabGuid; //Field offset: 0x18
		public HashSet<LevelCraftingType> craftingTypesInLevel; //Field offset: 0x20
		public <>c__DisplayClass27_0 CS$<>8__locals1; //Field offset: 0x28

		public <>c__DisplayClass27_1() { }

		internal bool <OnAddedToTarget>b__1(SubMatch subMatch) { }

	}

	internal class Result
	{
		public Sprite hudThumb; //Field offset: 0x10
		public List<ValueTuple`2<PDPrefab, Sprite>> outcomes; //Field offset: 0x18

		public Result() { }

	}

	private const string TIME_DAMPER_KEY_PREFIX = "Crafting_"; //Field offset: 0x0
	[SerializeField]
	protected LevelCraftingDataItem _craftingData; //Field offset: 0x88
	[SerializeField]
	protected Sprite _hintBubbleSprite; //Field offset: 0x90
	[SerializeField]
	protected GameSoundPlayer _soundPlayer; //Field offset: 0x98
	[SerializeField]
	protected string _craftingSoundName; //Field offset: 0xA0
	[SerializeField]
	protected bool _isPoofEffect; //Field offset: 0xA8
	[SerializeField]
	protected AvatarHandType _forceHandType; //Field offset: 0xAC
	protected Sprite _hudThumb; //Field offset: 0xB0
	protected readonly Dictionary<LevelCraftingType, Result> _results; //Field offset: 0xB8
	protected LevelItem _currentCraftableItem; //Field offset: 0xC0
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"pdPrefab", "sprite"})]
	protected List<ValueTuple`2<PDPrefab, Sprite>> _currentAvailableOutcomes; //Field offset: 0xC8
	protected int _currentConfigIndexPlaying; //Field offset: 0xD0
	private int _hintBubbleItemIndex; //Field offset: 0xD4

	public LevelCraftingDataItem CraftingData
	{
		 get { } //Length: 8
	}

	protected LevelCAItemCraftingHandlerBase() { }

	protected virtual void Awake() { }

	public LevelCraftingDataItem get_CraftingData() { }

	protected abstract string GetAnimationNameForAllConfigItems() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	private string GetTimeDamperKey() { }

	public virtual bool isMainThumbFullSize() { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnDestroy() { }

	public virtual void OnItemAddedToTarget(ICATarget target, LevelItem levelItem) { }

	public virtual void OnItemDetachedFromTarget(ICATarget target, LevelItem levelItem) { }

	private void OnItemPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected void PlaySound(string soundName) { }

	private override LevelHintBubbleType PWC.Level.HintBubble.ILevelHintBubbleTarget.GetHintBubbleType() { }

	private override int PWC.Level.HintBubble.ILevelHintBubbleTarget.GetMatchID() { }

	private override Sprite PWC.Level.HintBubble.ILevelHintBubbleTarget.GetSprite() { }

	private override bool PWC.Level.HintBubble.ILevelHintBubbleTarget.IsMatching(ILevelHintBubbleTarget other) { }

	protected bool TryCraftCurrentItem(LevelCharacter character) { }

	protected override bool TryGetItemToCraft(ICATarget target, out LevelItem levelItem, out List<ValueTuple`2<PDPrefab, Sprite>>& outcomes, out Sprite hudThumb) { }

	protected bool TryGetOutcomesForPrefabGuid(LevelCraftingType craftingType, out List<ValueTuple`2<PDPrefab, Sprite>>& outcomes, out Sprite hudThumb) { }

	public virtual bool TryOverrideConfigThumb(int configIndex, out Sprite spite) { }

	public virtual bool TryOverrideMainThumb(out Sprite spite) { }

	public virtual bool TryOverridePanelSprite(out Sprite sprite) { }

}

