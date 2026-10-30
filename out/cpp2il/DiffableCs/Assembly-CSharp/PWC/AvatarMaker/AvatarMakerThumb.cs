namespace PWC.AvatarMaker;

public class AvatarMakerThumb : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__61
	{
		public static readonly <>c__61<T> <>9; //Field offset: 0x0
		public static Predicate<AvatarMakerThumbPropertyBase> <>9__61_0; //Field offset: 0x0

		private static <>c__61`1() { }

		public <>c__61`1() { }

		internal bool <TryGetProperty>b__61_0(AvatarMakerThumbPropertyBase p) { }

	}

	[CompilerGenerated]
	private static Action<AvatarMakerThumb> OnThumbClickAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<AvatarMakerThumb> OnDeleteAction; //Field offset: 0x8
	private static Shader _multiColorShader; //Field offset: 0x10
	private static Shader _singleColorShader; //Field offset: 0x18
	private static Shader _gradientShader; //Field offset: 0x20
	[CompilerGenerated]
	private bool <IsNew>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <SkinName>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <CleanName>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private int <CategoryType>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private AWSpineColorModel <ColorModel>k__BackingField; //Field offset: 0x40
	[SerializeField]
	private Image _thumb; //Field offset: 0x48
	[SerializeField]
	private Image _frame; //Field offset: 0x50
	[SerializeField]
	private Image _item; //Field offset: 0x58
	[SerializeField]
	private Image _overlay; //Field offset: 0x60
	[SerializeField]
	private GameObject _colorIcon; //Field offset: 0x68
	[SerializeField]
	private GameObject _xButton; //Field offset: 0x70
	[SerializeField]
	private GameObject _comingSoon; //Field offset: 0x78
	[SerializeField]
	private GameObject _new; //Field offset: 0x80
	private bool _isScaled; //Field offset: 0x88
	private bool _isSelected; //Field offset: 0x89
	private bool _isRegistered; //Field offset: 0x8A
	private bool _isComingSoon; //Field offset: 0x8B
	private Vector3 _defaultThumbSize; //Field offset: 0x8C
	private Material _baseMaterial; //Field offset: 0x98
	private readonly Color _unchosenColor; //Field offset: 0xA0
	private readonly Color _chosenColor; //Field offset: 0xB0
	private List<AvatarMakerThumbPropertyBase> _properties; //Field offset: 0xC0

	public static event Action<AvatarMakerThumb> OnDeleteAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<AvatarMakerThumb> OnThumbClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public private int CategoryType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private string CleanName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private AWSpineColorModel ColorModel
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private bool IsNew
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public bool IsSelected
	{
		 get { } //Length: 8
	}

	public private string SkinName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public AvatarMakerThumb() { }

	[CompilerGenerated]
	public static void add_OnDeleteAction(Action<AvatarMakerThumb> value) { }

	[CompilerGenerated]
	public static void add_OnThumbClickAction(Action<AvatarMakerThumb> value) { }

	public void AddProperty(AvatarMakerThumbPropertyBase property) { }

	public void ClearProperties() { }

	[CompilerGenerated]
	public int get_CategoryType() { }

	[CompilerGenerated]
	public string get_CleanName() { }

	[CompilerGenerated]
	public AWSpineColorModel get_ColorModel() { }

	[CompilerGenerated]
	public bool get_IsNew() { }

	public bool get_IsSelected() { }

	[CompilerGenerated]
	public string get_SkinName() { }

	private void HandleColors(SpineType spineType, int categoryType) { }

	public void Init(int categoryType, Sprite thumbSprite, Sprite frameSprite, Sprite itemSprite, bool isTabletScreen, AWSpineColorModel colorModel = null) { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnThumbClick(AvatarMakerThumb thumb) { }

	[CompilerGenerated]
	public static void remove_OnDeleteAction(Action<AvatarMakerThumb> value) { }

	[CompilerGenerated]
	public static void remove_OnThumbClickAction(Action<AvatarMakerThumb> value) { }

	public void Scale(bool value, float time, float delay) { }

	private void SelectedSetActive(bool value) { }

	public void SelectedSetActiveIfNeeded() { }

	[CompilerGenerated]
	private void set_CategoryType(int value) { }

	[CompilerGenerated]
	private void set_CleanName(string value) { }

	[CompilerGenerated]
	private void set_ColorModel(AWSpineColorModel value) { }

	[CompilerGenerated]
	private void set_IsNew(bool value) { }

	[CompilerGenerated]
	private void set_SkinName(string value) { }

	public void SetComingSoon(bool value) { }

	public void SetNew(bool value) { }

	private void SUTInitMaterial(Material material, AvatarSpineColoringType avatarSpineColoringType) { }

	public bool TryGetProperty(out T property) { }

}

