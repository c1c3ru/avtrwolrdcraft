namespace PWC.AvatarMaker;

public class AvatarMakerThumbsSection : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<AvatarMakerThumb> <>9__15_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <TryGetSelectedThumb>b__15_0(AvatarMakerThumb thumb) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public Action<AvatarMakerThumb> action; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal void <ForEachActiveThumb>b__0(AvatarMakerThumb thumb) { }

	}

	[SerializeField]
	private Image _background; //Field offset: 0x20
	[SerializeField]
	private RectTransform _header; //Field offset: 0x28
	[SerializeField]
	private Image _headerBump; //Field offset: 0x30
	[SerializeField]
	private RectTransform _badge; //Field offset: 0x38
	[SerializeField]
	private Image _packIcon; //Field offset: 0x40
	[SerializeField]
	private GridLayoutGroup _grid; //Field offset: 0x48
	[SerializeField]
	private Sprite[] _headerBumpSprites; //Field offset: 0x50
	[SerializeField]
	private Color[] _colors; //Field offset: 0x58
	private readonly List<AvatarMakerThumb> _thumbs; //Field offset: 0x60

	public GridLayoutGroup Grid
	{
		 get { } //Length: 8
	}

	public AvatarMakerThumbsSection() { }

	public void ForEachActiveThumb(Action<AvatarMakerThumb> action) { }

	public GridLayoutGroup get_Grid() { }

	private static T GetStyle(IReadOnlyList<T> styles, int sectionIndex, T fallback) { }

	public void Init(int sectionIndex, bool isTabletScreen) { }

	public void InitAsPack(int sectionIndex, InventoryFlagType flagType, bool isTabletScreen) { }

	public void SetThumbs(List<AvatarMakerThumb> thumbs) { }

	public bool TryGetSelectedThumb(out AvatarMakerThumb selectedThumb) { }

}

