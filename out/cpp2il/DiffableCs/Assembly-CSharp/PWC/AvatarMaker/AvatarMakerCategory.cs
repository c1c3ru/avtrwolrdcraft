namespace PWC.AvatarMaker;

public class AvatarMakerCategory : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private static Action<Int32> OnCategoryButtonClickAction; //Field offset: 0x0
	protected RectTransform _rectTransform; //Field offset: 0x20
	protected bool _isPressed; //Field offset: 0x28
	protected int _categoryType; //Field offset: 0x2C
	protected Sprite _unpressedSprite; //Field offset: 0x30
	protected Sprite _pressedSprite; //Field offset: 0x38
	protected RectTransform _indicator; //Field offset: 0x40
	private bool _isWaitingForSpecialInteraction; //Field offset: 0x48
	private AvatarMakerCategoriesManager _manager; //Field offset: 0x50
	[SerializeField]
	protected Image _image; //Field offset: 0x58
	[SerializeField]
	private GameObject _new; //Field offset: 0x60
	public bool IsHiddenOnDefault; //Field offset: 0x68

	public static event Action<Int32> OnCategoryButtonClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public int CategoryType
	{
		 get { } //Length: 8
	}

	public AvatarMakerCategory() { }

	[CompilerGenerated]
	public static void add_OnCategoryButtonClickAction(Action<Int32> value) { }

	private void AnimateIndicator() { }

	private void Awake() { }

	protected override void CallOnCategoryButtonClickAction() { }

	public override void ForceClick() { }

	public int get_CategoryType() { }

	public override void Init(AvatarMakerCategoriesManager manager, CategoryData categoryData, RectTransform indicator) { }

	protected bool IsUnseenCategory() { }

	protected override void OnCategoryButtonClick(int categoryType) { }

	protected override void OnCategoryButtonClickInternal(int categoryType) { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnSpecialInteractionPerformed(int categoryType) { }

	public static void RemoteCategoryClick(int categoryType) { }

	[CompilerGenerated]
	public static void remove_OnCategoryButtonClickAction(Action<Int32> value) { }

	protected void SetNew(bool value) { }

	public void SetPressed(bool isPressed) { }

}

