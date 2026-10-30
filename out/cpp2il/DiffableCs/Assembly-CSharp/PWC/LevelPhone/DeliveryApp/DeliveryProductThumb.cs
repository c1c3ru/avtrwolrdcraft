namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryProductThumb : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public Action onCompleteAnimationAction; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal void <Animate>b__0() { }

	}

	[CompilerGenerated]
	private static Action<ProductData, Int32> OnPoductThumbClickAction; //Field offset: 0x0
	[SerializeField]
	private Image _icon; //Field offset: 0x20
	[SerializeField]
	private Image _background; //Field offset: 0x28
	[SerializeField]
	private TextMeshProUGUI _amountText; //Field offset: 0x30
	private PDPrefab _myPDPrefab; //Field offset: 0x38
	private ProductData _productData; //Field offset: 0x40
	private int _currentAmount; //Field offset: 0x48
	private int _tweenID; //Field offset: 0x4C

	public static event Action<ProductData, Int32> OnPoductThumbClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public DeliveryProductThumb() { }

	[CompilerGenerated]
	public static void add_OnPoductThumbClickAction(Action<ProductData, Int32> value) { }

	public void Animate(bool value, Action onCompleteAnimationAction = null) { }

	public List<Int32> GetCategoryIndex() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnPoductThumbClickAction(Action<ProductData, Int32> value) { }

	public void SetData(ProductData productData, Sprite backgroundSprite) { }

	private void SetIconSprite(Sprite sprite) { }

}

