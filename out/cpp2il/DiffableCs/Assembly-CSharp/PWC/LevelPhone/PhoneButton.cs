namespace PWC.LevelPhone;

public class PhoneButton : GameUIElement, IPointerDownHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public bool value; //Field offset: 0x10
		public PhoneButton <>4__this; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <Animate>b__0() { }

	}

	[CompilerGenerated]
	private static Action OnPhoneButtonClickAction; //Field offset: 0x0
	public static bool ShouldUpdateNotification; //Field offset: 0x8
	[SerializeField]
	private Image _notificationImage; //Field offset: 0x28
	[SerializeField]
	private PopupNotificationButton _popupNotificationButton; //Field offset: 0x30
	private bool _isInteractable; //Field offset: 0x38

	public static event Action OnPhoneButtonClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public PhoneButton() { }

	[CompilerGenerated]
	public static void add_OnPhoneButtonClickAction(Action value) { }

	private void Animate(bool value) { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelMakerItemsMenuSetVisible(bool isVisible) { }

	private void OnPhoneEndAnimation(bool value) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	private void OnPosnInit() { }

	private void OnSplitLevelModeChange(bool isSplitLevelOn) { }

	[CompilerGenerated]
	public static void remove_OnPhoneButtonClickAction(Action value) { }

	private void UpdateNotificationIfNeeded() { }

}

