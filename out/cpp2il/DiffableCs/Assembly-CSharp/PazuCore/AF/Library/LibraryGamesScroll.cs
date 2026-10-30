namespace PazuCore.AF.Library;

public class LibraryGamesScroll : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LibraryGame> <>9__12_0; //Field offset: 0x8
		public static Func<LibraryGame, Boolean> <>9__12_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <Init>b__12_0(LibraryGame lGame) { }

		internal bool <Init>b__12_1(LibraryGame lGame) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LibraryGamesScroll <>4__this; //Field offset: 0x10
		public LibrarySection section; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <Init>b__2(bool success) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public LibraryGamesScroll <>4__this; //Field offset: 0x10
		public string tilledImageUrl; //Field offset: 0x18
		public bool isHeader; //Field offset: 0x20
		public int sectionId; //Field offset: 0x24
		public string imageUrl; //Field offset: 0x28

		public <>c__DisplayClass13_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_1
	{
		public LibraryHeaderOrFooterImage libraryHeaderOrFooterImage; //Field offset: 0x10
		public RectTransform headerOrFooter; //Field offset: 0x18
		public <>c__DisplayClass13_0 CS$<>8__locals1; //Field offset: 0x20
		public Action<Boolean> <>9__1; //Field offset: 0x28
		public Action<Boolean> <>9__2; //Field offset: 0x30

		public <>c__DisplayClass13_1() { }

		internal void <SetHedderOrFooter>b__0(bool success) { }

		internal void <SetHedderOrFooter>b__1(bool successTilled) { }

		internal void <SetHedderOrFooter>b__2(bool successTilled) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_2
	{
		public LibraryHeaderOrFooterImage libraryHeaderOrFooterImage; //Field offset: 0x10
		public RectTransform headerOrFooter; //Field offset: 0x18
		public <>c__DisplayClass13_0 CS$<>8__locals2; //Field offset: 0x20

		public <>c__DisplayClass13_2() { }

		internal void <SetHedderOrFooter>b__3(bool success) { }

	}

	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x20
	[SerializeField]
	private LibraryGameItem _itemPrefab; //Field offset: 0x28
	[SerializeField]
	private Image _icon; //Field offset: 0x30
	[SerializeField]
	private Text _title; //Field offset: 0x38
	[CompilerGenerated]
	private AppearanceType <SectionAppearanceType>k__BackingField; //Field offset: 0x40
	private RectTransform _headerOrFooterImagePrefab; //Field offset: 0x48

	public ScrollRect ScrollRect
	{
		 get { } //Length: 8
	}

	public private AppearanceType SectionAppearanceType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public LibraryGamesScroll() { }

	[CompilerGenerated]
	private void <FadeIconIn>b__17_0(object value) { }

	private void Awake() { }

	public void CorrectContentWidth() { }

	private void FadeIconIn() { }

	private void FitToScreen() { }

	public void FixWidthIfScaled() { }

	public ScrollRect get_ScrollRect() { }

	[CompilerGenerated]
	public AppearanceType get_SectionAppearanceType() { }

	public void Init(LibrarySection section, RectTransform headerOrFooterImagePrefab) { }

	[CompilerGenerated]
	private void set_SectionAppearanceType(AppearanceType value) { }

	private void SetHedderOrFooter(int sectionId, RectTransform prefab, string imageUrl, string tilledImageUrl, bool isHeader) { }

}

