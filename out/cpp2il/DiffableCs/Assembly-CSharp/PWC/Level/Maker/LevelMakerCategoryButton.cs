namespace PWC.Level.Maker;

public class LevelMakerCategoryButton : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	internal enum NewIndicatorType
	{
		None = 0,
		Spine = 1,
		Dot = 2,
	}

	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private Image _frame; //Field offset: 0x30
	[SerializeField]
	private GameObject _premiumFrame; //Field offset: 0x38
	[SerializeField]
	private Image _background; //Field offset: 0x40
	[SerializeField]
	private Image _tag; //Field offset: 0x48
	[SerializeField]
	private LevelMakerNewPackIndicator _newPackIndicatorPrefab; //Field offset: 0x50
	[SerializeField]
	private GameObject _newIndicator; //Field offset: 0x58
	private Action _action; //Field offset: 0x60
	private bool _isPack; //Field offset: 0x68

	public LevelMakerCategoryButton() { }

	public override void Init(DataType dataType, Sprite iconSprite, bool isPremium, Action action, Sprite backgroundSprite = null, Sprite tagSprite = null, NewIndicatorType newIndicatorType = 0, string packName = null) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public void PerformAction() { }

}

