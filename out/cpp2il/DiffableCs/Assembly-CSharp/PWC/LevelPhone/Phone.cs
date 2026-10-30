namespace PWC.LevelPhone;

public class Phone : GameUIElement
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public Phone <>4__this; //Field offset: 0x10
		public float destination; //Field offset: 0x18
		public bool isImmediate; //Field offset: 0x1C
		public Action onCompleteAction; //Field offset: 0x20
		public Action <>9__4; //Field offset: 0x28
		public Action <>9__6; //Field offset: 0x30
		public Action <>9__5; //Field offset: 0x38

		public <>c__DisplayClass30_0() { }

		internal void <Animate>b__0() { }

		internal void <Animate>b__1() { }

		internal void <Animate>b__2() { }

		internal void <Animate>b__3() { }

		internal void <Animate>b__4() { }

		internal void <Animate>b__5() { }

		internal void <Animate>b__6() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public bool value; //Field offset: 0x10
		public Phone <>4__this; //Field offset: 0x18

		public <>c__DisplayClass31_0() { }

		internal void <AnimateMainUI>b__0() { }

		internal void <AnimateMainUI>b__1() { }

		internal void <AnimateMainUI>b__2() { }

	}

	[CompilerGenerated]
	private static Action<Boolean> OnPhoneBeginAnimateAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Boolean> OnPhoneEndAnimationAction; //Field offset: 0x8
	[SerializeField]
	private GameObject _parent; //Field offset: 0x28
	[SerializeField]
	private GameObject _collapseTab; //Field offset: 0x30
	[SerializeField]
	private RectTransform _phoneContent; //Field offset: 0x38
	[SerializeField]
	private RectTransform _header; //Field offset: 0x40
	[SerializeField]
	private RectTransform _seperator; //Field offset: 0x48
	[SerializeField]
	private PhoneApplications _applications; //Field offset: 0x50
	[SerializeField]
	private PhoneTime _time; //Field offset: 0x58
	[SerializeField]
	private PhoneBackButton _backButton; //Field offset: 0x60
	[SerializeField]
	private PhoneBody _body; //Field offset: 0x68
	private float _initialXLocalPosition; //Field offset: 0x70
	private bool _isActive; //Field offset: 0x74
	private bool _isAnimating; //Field offset: 0x75

	public static event Action<Boolean> OnPhoneBeginAnimateAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static event Action<Boolean> OnPhoneEndAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public PhoneBody Body
	{
		 get { } //Length: 8
	}

	public Phone() { }

	[CompilerGenerated]
	private void <AnimateHeader>b__32_0(float bottom) { }

	[CompilerGenerated]
	private void <AnimateHeader>b__32_1(float anchoredYPosition) { }

	[CompilerGenerated]
	private void <AnimateHeader>b__32_2(float normalizedValue) { }

	[CompilerGenerated]
	public static void add_OnPhoneBeginAnimateAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public static void add_OnPhoneEndAnimationAction(Action<Boolean> value) { }

	private void Animate(bool value, bool isImmediate = false) { }

	private void AnimateHeader(bool value, Action onCompleteAction) { }

	private void AnimateMainUI(bool value) { }

	private void Awake() { }

	private void CheckAutoOpenForAchievementsApplication() { }

	private void CheckForAutoOpenApplication() { }

	public void CollapseTabClick() { }

	[ContextMenu("Notification/DeleteNotificationExistingData")]
	public void DeleteNotificationExistingData() { }

	public void ForceClickOnApplication(int appIndex) { }

	public PhoneBody get_Body() { }

	public static string GetBulkDataOffValue() { }

	public static string GetBulkDataOnValue() { }

	public static string GlobalPhoneNotificationKey() { }

	public static string GlobalPhoneOpenAchievementsApplication() { }

	public void Init() { }

	public static string LoadNotificationStatus() { }

	private void OnAchievementHuntResetHunt(int _) { }

	private void OnAnimationMenuOpen() { }

	private void OnApplicationClick(Application application) { }

	private void OnApplicationContentClose(bool shouldBackToApps) { }

	private void OnCharacterSpawnOnDrag() { }

	private void OnDestroy() { }

	public static void OnNotificationTargetClick() { }

	private void OnPhoneButtonClick() { }

	private void OnSplitLevelModeChange(bool isSplitLevelOn) { }

	[CompilerGenerated]
	public static void remove_OnPhoneBeginAnimateAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public static void remove_OnPhoneEndAnimationAction(Action<Boolean> value) { }

	[ContextMenu("Notification/ResetNotificationOnApp")]
	public void ResetNotificationOnAppOnUpdate() { }

	[ContextMenu("Notification/Turn Off Notification Status")]
	public void TurnOffNotificationStatus() { }

	[ContextMenu("Notification/Turn On Notification Status")]
	public void TurnOnNotificationStatus() { }

	private void Update() { }

}

