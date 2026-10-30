namespace PWC.GamePopups;

public class PromotionPopup : GamePopup
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public PromotionPopup <>4__this; //Field offset: 0x10
		public Vector3 fromPosition; //Field offset: 0x18
		public Vector3 toPosition; //Field offset: 0x24
		public bool value; //Field offset: 0x30

		public <>c__DisplayClass8_0() { }

		internal void <Animate>b__0(float t) { }

		internal void <Animate>b__1() { }

	}

	[SerializeField]
	private Image _bundleTitle; //Field offset: 0x48
	[SerializeField]
	private Image _packTitle; //Field offset: 0x50
	[SerializeField]
	private PromotionPopUpTitleLocalization _promotionPopUpTitleLocalization; //Field offset: 0x58
	[SerializeField]
	private AFCLocalizedTextMeshPro _afcLocalizedTextMeshPro; //Field offset: 0x60
	[SerializeField]
	private GameObject _bundleTitleBadge; //Field offset: 0x68
	private Transform _startPoint; //Field offset: 0x70
	private bool _isBundle; //Field offset: 0x78

	public PromotionPopup() { }

	protected virtual void Animate(bool value) { }

	public virtual void Init(Sprite sprite = null, Sprite customSprite = null, float customSpriteScale = 1, GameObject prefab = null, bool disableImage = true) { }

	public virtual void OnButtonPress(bool value) { }

	public void SetIsBundle(bool isBundle) { }

	public void SetStartPoint(Transform transform) { }

}

