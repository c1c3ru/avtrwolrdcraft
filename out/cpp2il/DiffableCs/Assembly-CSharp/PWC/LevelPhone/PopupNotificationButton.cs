namespace PWC.LevelPhone;

public class PopupNotificationButton : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private static PopupNotificationButton <Instance>k__BackingField; //Field offset: 0x0
	public const string POPUP_NOTIFICATION_BUTTON_DATA_KEY = "PWC_LevelPhone_PopupNotificationButton_"; //Field offset: 0x0
	[SerializeField]
	private Image _Image; //Field offset: 0x28
	[SerializeField]
	private float _animationTime; //Field offset: 0x30
	[SerializeField]
	private float _animationDelayTime; //Field offset: 0x34
	[SerializeField]
	private string _clickSoundName; //Field offset: 0x38
	[SerializeField]
	private GameObject _startingPosition; //Field offset: 0x40
	private InventoryFlagType _flagType; //Field offset: 0x48
	private int _tweenId; //Field offset: 0x4C
	private bool _isAnimating; //Field offset: 0x50

	public private static PopupNotificationButton Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public PopupNotificationButton() { }

	[CompilerGenerated]
	private void <Animate>b__16_0() { }

	[CompilerGenerated]
	private void <Animate>b__16_1() { }

	[CompilerGenerated]
	private void <Animate>b__16_2() { }

	private void Animate() { }

	private void Awake() { }

	[CompilerGenerated]
	public static PopupNotificationButton get_Instance() { }

	public void Init(InventoryFlagType flagType) { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	private static void set_Instance(PopupNotificationButton value) { }

}

