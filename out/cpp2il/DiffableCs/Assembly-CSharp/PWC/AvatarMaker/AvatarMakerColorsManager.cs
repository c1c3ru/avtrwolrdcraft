namespace PWC.AvatarMaker;

public class AvatarMakerColorsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<AvatarMakerColorThumb> <>9__22_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <AnimateColorsInIfNeeded>b__22_0(AvatarMakerColorThumb thumb) { }

	}

	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x20
	[SerializeField]
	private RectTransform _categories; //Field offset: 0x28
	[SerializeField]
	private RectTransform _divider; //Field offset: 0x30
	[SerializeField]
	private AvatarMakerMultiColorsPanel _multiColorPanel; //Field offset: 0x38
	private AvatarMakerColorThumb _colorThumbPrefab; //Field offset: 0x40
	private RectTransform _rectTransform; //Field offset: 0x48
	private Vector2 _enabledAnchoredPosition; //Field offset: 0x50
	private Vector2 _disabledAnchoredPosition; //Field offset: 0x58
	private bool _hasMeasuredAnchoredPositions; //Field offset: 0x60
	private bool _isEnabled; //Field offset: 0x61
	private readonly List<AvatarMakerColorThumb> _colorThumbs; //Field offset: 0x68
	private SerializableDictionaryBase<Int32, AWSpineColorsList> _colorsByCategoryType; //Field offset: 0x70
	[CompilerGenerated]
	private AvatarMakerColorsConfigBase <ColorsConfig>k__BackingField; //Field offset: 0x78

	public private AvatarMakerColorsConfigBase ColorsConfig
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public AvatarMakerColorsManager() { }

	[CompilerGenerated]
	private void <Animate>b__21_0(object anchoredPosition) { }

	[CompilerGenerated]
	private void <Init>b__18_0() { }

	private void Animate(bool value) { }

	public void AnimateColorsInIfNeeded(int categoryType) { }

	private void Awake() { }

	[CompilerGenerated]
	public AvatarMakerColorsConfigBase get_ColorsConfig() { }

	private int GetMultiColorIndex() { }

	public AWSpineColorModel GetRandomColor(int categoryType) { }

	private void HideMultiColorPanel() { }

	public void Init() { }

	private void MeasureAnchoredPositionsIfNeeded() { }

	private void OnCategoryButtonClick(int _) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private void set_ColorsConfig(AvatarMakerColorsConfigBase value) { }

	private void ShowMultiColorPanel(int categoryType, int multiColorCount) { }

}

