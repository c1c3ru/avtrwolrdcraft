namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryProductsManager : DeliveryPageManagerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public DeliveryProductsManager <>4__this; //Field offset: 0x10
		public Action onCompleteAnimationAction; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <Animate>b__0(float value) { }

		internal void <Animate>b__1() { }

	}

	[SerializeField]
	private Transform _content; //Field offset: 0x28
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x30
	[SerializeField]
	private DeliveryProductThumb _prefab; //Field offset: 0x38
	[SerializeField]
	private DeliveryProductsBottomBar _bottomBar; //Field offset: 0x40
	[SerializeField]
	private Transform _topBar; //Field offset: 0x48
	[SerializeField]
	private DeliveryOrderNowButton _orderNowButton; //Field offset: 0x50
	[SerializeField]
	private List<DeliveryContentCategoryButton> _categoryButtons; //Field offset: 0x58
	private int _tweenID; //Field offset: 0x60
	private DeliveryBusinessData _currentBusinessData; //Field offset: 0x68
	private int _currentDisplayedIndex; //Field offset: 0x70
	private readonly List<DeliveryProductThumb> _thumbs; //Field offset: 0x78
	private readonly Dictionary<String, ProductState> _productsState; //Field offset: 0x80

	public DeliveryProductsManager() { }

	private void Animate(Action onCompleteAnimationAction = null) { }

	private void AnimateProductsOff() { }

	private void AnimateProductsOn() { }

	private void Awake() { }

	public void ClearProducts() { }

	public void DisableCategoryButton() { }

	public List<ProductState> GetProductsStates() { }

	private void InitIfNeeded() { }

	private void OnDestroy() { }

	private void OnPoductThumbClick(ProductData productData, int amount) { }

	public virtual void OnSetActive(bool isActive, Action onCompleteSetActiveAction = null) { }

	public void SetBusinessData(DeliveryBusinessData businessData) { }

	public void SetCategoryIndex(int newIndex) { }

	public void SetInitialCategoryIndex(int newIndex) { }

	private void UpdateProducts() { }

}

