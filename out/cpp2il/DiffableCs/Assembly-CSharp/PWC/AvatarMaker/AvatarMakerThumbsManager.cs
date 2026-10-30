namespace PWC.AvatarMaker;

public class AvatarMakerThumbsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Sprite, Boolean> <>9__40_2; //Field offset: 0x8
		public static Comparison<Sprite> <>9__40_6; //Field offset: 0x10
		public static Action<AvatarMakerThumb> <>9__61_1; //Field offset: 0x18
		public static Action<AvatarMakerThumbsSection> <>9__61_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal bool <AfterThumbsScaleDownAnimation>b__40_2(Sprite sprite) { }

		internal int <AfterThumbsScaleDownAnimation>b__40_6(Sprite a, Sprite b) { }

		internal void <SetThumbsSelectedIfNeeded>b__61_0(AvatarMakerThumbsSection section) { }

		internal void <SetThumbsSelectedIfNeeded>b__61_1(AvatarMakerThumb thumb) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_0
	{
		public bool value; //Field offset: 0x10
		public Action<AvatarMakerThumb> <>9__1; //Field offset: 0x18

		public <>c__DisplayClass38_0() { }

		internal void <ScaleThumbs>b__0(AvatarMakerThumbsSection section) { }

		internal void <ScaleThumbs>b__1(AvatarMakerThumb thumb) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public Action<AvatarMakerThumbsSection> action; //Field offset: 0x10

		public <>c__DisplayClass39_0() { }

		internal void <ForEachActiveSection>b__0(AvatarMakerThumbsSection section) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public AvatarMakerThumbsManager <>4__this; //Field offset: 0x10
		public int currentCategoryType; //Field offset: 0x18
		public AvatarMakerThumbsSection baseSection; //Field offset: 0x20
		public SpineType spineType; //Field offset: 0x28
		public Action<Single> <>9__7; //Field offset: 0x30

		public <>c__DisplayClass40_0() { }

		internal void <AfterThumbsScaleDownAnimation>b__1() { }

		internal bool <AfterThumbsScaleDownAnimation>b__4(Sprite sprite) { }

		internal bool <AfterThumbsScaleDownAnimation>b__5(Sprite sprite) { }

		internal void <AfterThumbsScaleDownAnimation>b__7(float verticalNormalizedPosition) { }

		internal string <AfterThumbsScaleDownAnimation>g__GetBreedName|3(Sprite sprite) { }

		internal List<AvatarMakerThumb> <AfterThumbsScaleDownAnimation>g__InitThumbs|0(string spriteAtlasPath, Func<Sprite, Boolean> predicate = null) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass52_0
	{
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"Authored", "Existing"})]
		public Dictionary<Sprite, ValueTuple`2<Int32, Int32>> placeBySprite; //Field offset: 0x10

		public <>c__DisplayClass52_0() { }

		internal int <ApplyAuthoredThumbOrder>b__0(Sprite a, Sprite b) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass54_0
	{
		public HashSet<String> premiumSprites; //Field offset: 0x10

		public <>c__DisplayClass54_0() { }

		internal int <ReorderItemSprites>b__0(Sprite itemSprite) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass64_0
	{
		public HashSet<String> excludedSpriteNames; //Field offset: 0x10

		public <>c__DisplayClass64_0() { }

		internal void <AddExpansionPackThumbs>b__0(Sprite excludedItemSprite) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass66_0
	{
		public List<InventoryFlagType> flagTypes; //Field offset: 0x10

		public <>c__DisplayClass66_0() { }

		internal bool <GetOwnedPackFlagsInTabOrder>b__0(InventoryFlagType flagType) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass69_0
	{
		public string numberOnlySkinName; //Field offset: 0x10

		public <>c__DisplayClass69_0() { }

		internal bool <TryGetSpriteFromThumbSolution>b__0(Sprite s) { }

	}

	[CompilerGenerated]
	private sealed class <AfterThumbsScaleDownAnimation>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AvatarMakerThumbsManager <>4__this; //Field offset: 0x20
		public int currentCategoryType; //Field offset: 0x28
		public float animationTime; //Field offset: 0x2C
		private <>c__DisplayClass40_0 <>8__1; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <AfterThumbsScaleDownAnimation>d__40(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly Dictionary<String, Int32> SpriteOrder; //Field offset: 0x0
	private const float SCALE_ANIMATION_TIME = 0,25; //Field offset: 0x0
	private const float IPAD_WIDTH = 465; //Field offset: 0x0
	private const float WIDE_WIDTH = 685; //Field offset: 0x0
	private static Dictionary<InventoryFlagType, Dictionary`2<SpineType, HashSet`1<String>>> _makerPremiumSkinsDataBySpineType; //Field offset: 0x8
	[SerializeField]
	private bool _includePremade; //Field offset: 0x20
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x28
	[SerializeField]
	private VerticalLayoutGroup _sectionsParent; //Field offset: 0x30
	[SerializeField]
	private Sprite _smallThumbSprite; //Field offset: 0x38
	[SerializeField]
	private Sprite _smallFrameSprite; //Field offset: 0x40
	[SerializeField]
	private Sprite _bigThumbSprite; //Field offset: 0x48
	[SerializeField]
	private Sprite _bigFrameSprite; //Field offset: 0x50
	[SerializeField]
	private Sprite _skinColorThumbSprite; //Field offset: 0x58
	[SerializeField]
	private Sprite _skinColorFrameSprite; //Field offset: 0x60
	[SerializeField]
	private Sprite _premiumFrame; //Field offset: 0x68
	[SerializeField]
	private AWSpineColorsList _skinColors; //Field offset: 0x70
	private readonly List<AvatarMakerThumbsSection> _sections; //Field offset: 0x78
	private RectTransform _rectTransform; //Field offset: 0x80
	private AvatarMakerThumb _thumbPrefab; //Field offset: 0x88
	private AvatarMakerThumbsSection _sectionPrefab; //Field offset: 0x90
	private readonly List<AvatarMakerThumb> _thumbPool; //Field offset: 0x98
	private readonly List<AvatarMakerThumb> _allActiveThumbs; //Field offset: 0xA0
	private int _thumbPoolCursor; //Field offset: 0xA8
	private Coroutine _setupThumbsCoroutine; //Field offset: 0xB0
	private Sprite _currentThumbSprite; //Field offset: 0xB8
	private Sprite _currentFrameSprite; //Field offset: 0xC0
	private Dictionary<Int32, List`1<Sprite>> _itemSpritesByCategoryType; //Field offset: 0xC8
	private Dictionary<InventoryFlagType, Dictionary`2<Int32, List`1<Sprite>>> _packItemSpritesByFlag; //Field offset: 0xD0
	private Dictionary<Int32, Single> _verticalNormalizedPositionByCategoryType; //Field offset: 0xD8
	private AvatarMakerThumbsConfigBase _thumbsConfig; //Field offset: 0xE0
	private InventorySkinsBuildData _skinsBuildData; //Field offset: 0xE8

	public static float WideIpadRatio
	{
		 get { } //Length: 12
	}

	private static AvatarMakerThumbsManager() { }

	public AvatarMakerThumbsManager() { }

	private int AddExpansionPackThumbs(InventoryFlagType flagType, SpineType spineType, int categoryType, Dictionary<Int32, List`1<Sprite>> target, Dictionary<Int32, List`1<Sprite>> excludedItemSpritesByCategoryType = null) { }

	private void AddItemSpritesOutsideAnyPack(SpineType spineType, int categoryType, List<Sprite> spritesAtlasList, List<Sprite> itemSprites) { }

	private void AddItemSpritesWithNoThumb(int categoryType, HashSet<String> packSkinNames, HashSet<String> alreadyAdded, List<Sprite> itemSprites) { }

	private void AddOwnedExpansionPacksThumbs(SpineType spineType, HashSet<Int32> categoryTypes, List<InventoryFlagType> ownedPackFlags) { }

	[IteratorStateMachine(typeof(<AfterThumbsScaleDownAnimation>d__40))]
	private IEnumerator AfterThumbsScaleDownAnimation(int currentCategoryType, float animationTime) { }

	private void ApplyAuthoredThumbOrder(SpineType spineType, int categoryType, InventoryFlagType flagType, List<Sprite> itemSprites) { }

	private void Awake() { }

	private void BeginThumbsRefresh() { }

	private void ClearCache() { }

	private void DeactivateSectionsFrom(int index) { }

	private void EndThumbsRefresh() { }

	private void FillColorSection(AvatarMakerThumbsSection section, int categoryType, AWSpineColorsList colorsList, bool isTabletScreen) { }

	private int FillSection(AvatarMakerThumbsSection section, Dictionary<Int32, List`1<Sprite>> itemSpritesByCategoryType, HashSet<Int32> categoryTypes, SpineType spineType, Dictionary<Int32, HashSet`1<String>> premiumItemNamesByCategoryType, bool isTabletScreen) { }

	private void FillSections(int currentCategoryType, SpineType spineType, HashSet<Int32> categoryTypes, List<InventoryFlagType> ownedPackFlags, bool isTabletScreen) { }

	private HashSet<String> FilterByClaimedInventoryFlags(SpineType spineType, int categoryType, ref List<Sprite>& itemSpritesList) { }

	private void ForEachActiveSection(Action<AvatarMakerThumbsSection> action) { }

	public static float get_WideIpadRatio() { }

	private int GetMarkedThumbCategoryType(int fallbackCategoryType) { }

	private static Vector2 GetNativeSize(Sprite sprite) { }

	private static int GetOrderKey(Sprite s) { }

	private List<InventoryFlagType> GetOwnedPackFlagsInTabOrder(InventorySkinsBuildData expansionPackData) { }

	private AvatarMakerThumbsSection GetPooledSection(int index, int categoryType) { }

	public HashSet<String> GetPremiumItemsNames(SpineType spineType, int categoryType) { }

	private HashSet<String> GetRelevantInventorySkins(SpineType spineType, int categoryType) { }

	private SpriteAtlas GetSpriteAtlas(SpineType spineType, int categoryType) { }

	private static string GetThumbOrderKey(string name, string categoryName) { }

	public void Init() { }

	private bool IsSpineSpriteRelevantForExpansionPack(Sprite sprite) { }

	private void OnCategoryButtonClick(int categoryType) { }

	private void OnDestroy() { }

	private void OnExpansionPackChanged(AvatarMakerExpansionPackCategory category) { }

	private void OnThumbClick(AvatarMakerThumb thumb) { }

	private void ReorderItemSprites(HashSet<String> premiumSprites, ref List<Sprite>& itemSprites) { }

	private float ScaleThumbs(bool value) { }

	private List<AvatarMakerThumb> SetSectionThumbs(AvatarMakerThumbsSection section, int numberOfThumbs) { }

	public void SetThumbsSelectedIfNeeded() { }

	private void SetupGridLayoutGroup(int categoryType, GridLayoutGroup gridLayoutGroup) { }

	private bool TryFillColorSections(int currentCategoryType, AvatarMakerExpansionPackCategory currentExpansionPack, bool isTabletScreen) { }

	private bool TryGetSpriteFromThumbSolution(SpineType spineType, int categoryType, string numberOnlySkinName, List<Sprite> spritesAtlas, out Sprite sprite) { }

}

