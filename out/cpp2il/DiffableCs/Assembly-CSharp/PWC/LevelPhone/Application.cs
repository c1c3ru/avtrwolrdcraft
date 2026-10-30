namespace PWC.LevelPhone;

public class Application : GameUIElement, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public bool value; //Field offset: 0x10
		public Application <>4__this; //Field offset: 0x18
		public int siblingIndex; //Field offset: 0x20
		public Action beforeOnCompleteAction; //Field offset: 0x28
		public Action overrideOnCompleteAction; //Field offset: 0x30

		public <>c__DisplayClass32_0() { }

		internal void <Animate>b__0() { }

	}

	[CompilerGenerated]
	private static Action<Application> OnApplicationClickAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Boolean> OnApplicationEndAnimationAction; //Field offset: 0x8
	[SerializeField]
	private ApplicationType _applicationType; //Field offset: 0x24
	[SerializeField]
	private ApplicationDownloader _downloader; //Field offset: 0x28
	[SerializeField]
	private bool _isDownloadable; //Field offset: 0x30
	[SerializeField]
	private bool _hasNotification; //Field offset: 0x31
	[ConditionalField("_hasNotification", True, True, (array) null)]
	[SerializeField]
	private bool _isNotificationTarget; //Field offset: 0x32
	[ConditionalField("_isDownloadable", True, True, (array) null)]
	[SerializeField]
	private Image _image; //Field offset: 0x38
	[ConditionalField("_isDownloadable", True, True, (array) null)]
	[SerializeField]
	private Sprite _enabledSprite; //Field offset: 0x40
	[ConditionalField("_isDownloadable", True, True, (array) null)]
	[SerializeField]
	private Sprite _disabledSprite; //Field offset: 0x48
	[SerializeField]
	private Image _notificationImage; //Field offset: 0x50
	private bool _isInteractable; //Field offset: 0x58
	private bool _isDownloaded; //Field offset: 0x59
	private bool _isDownloading; //Field offset: 0x5A
	private IApplicationsOwner _owner; //Field offset: 0x60

	public static event Action<Application> OnApplicationClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static event Action<Boolean> OnApplicationEndAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public ApplicationType ApplicationType
	{
		 get { } //Length: 8
	}

	public bool HasNotification
	{
		 get { } //Length: 8
	}

	public bool IsNotificationTarget
	{
		 get { } //Length: 8
	}

	public Application() { }

	[CompilerGenerated]
	public static void add_OnApplicationClickAction(Action<Application> value) { }

	[CompilerGenerated]
	public static void add_OnApplicationEndAnimationAction(Action<Boolean> value) { }

	public void Animate(bool value, Action beforeOnCompleteAction = null, Action overrideOnCompleteAction = null) { }

	private void Awake() { }

	public void ForceClick() { }

	public ApplicationType get_ApplicationType() { }

	public bool get_HasNotification() { }

	public bool get_IsNotificationTarget() { }

	public string GetStateKey() { }

	public void InitDownloadState(IApplicationsOwner owner, bool isDownloaded) { }

	private void OnDestroy() { }

	private void OnPhoneEndAnimation(bool value) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OpenApplicationFirstTimeIfNeeded() { }

	[CompilerGenerated]
	public static void remove_OnApplicationClickAction(Action<Application> value) { }

	[CompilerGenerated]
	public static void remove_OnApplicationEndAnimationAction(Action<Boolean> value) { }

	private void SetDownloaded() { }

	public void SetIsInteractable(bool isInteractable) { }

	private void UpdateNotificationIcon() { }

}

