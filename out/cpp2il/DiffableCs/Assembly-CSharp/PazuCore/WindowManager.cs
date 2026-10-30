namespace PazuCore;

public class WindowManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Window> <>9__23_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <GetActiveWindow>b__23_0(Window x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public WindowManager <>4__this; //Field offset: 0x10
		public string windowName; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal void <OpenWindowWithPerentalControl>b__0() { }

		internal void <OpenWindowWithPerentalControl>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public WindowManager <>4__this; //Field offset: 0x10
		public string path; //Field offset: 0x18

		public <>c__DisplayClass29_0() { }

		internal void <OpenWindowWithPerentalControlFromPath>b__0() { }

		internal void <OpenWindowWithPerentalControlFromPath>b__1() { }

	}

	public static WindowManager instance; //Field offset: 0x0
	public static Func<Boolean> OnBackButtonAction; //Field offset: 0x8
	[SerializeField]
	private Name_Back_Scene nameBackScene; //Field offset: 0x20
	[SerializeField]
	private PazuNotification notification; //Field offset: 0x28
	[SerializeField]
	private AndroidDialog androidDialog; //Field offset: 0x30
	[SerializeField]
	private ClickBlocker clickBlocker; //Field offset: 0x38
	public string prentelControlPopUpSoundName; //Field offset: 0x40
	public string prentelControlHideSoundName; //Field offset: 0x48
	private readonly List<Window> _openWindows; //Field offset: 0x50
	private ParentalGateDate _parentalGateDate; //Field offset: 0x58
	private ParentalGateMath _parentalGateMath; //Field offset: 0x60
	[CompilerGenerated]
	private bool <IsBackButtonEnable>k__BackingField; //Field offset: 0x68
	private ScreenType _screenType; //Field offset: 0x6C

	public bool IsBackButtonEnable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public Transform ParentalControlTransform
	{
		 get { } //Length: 28
	}

	public WindowManager() { }

	public void AddNameBackScene(Name_Back_Scene nameBackScene) { }

	public bool AreThereAnyVisibleWindows() { }

	private void Awake() { }

	public void CloseAllWindows() { }

	private void EnsureScreenType() { }

	public void FitCanvasScalerToScreen() { }

	[CompilerGenerated]
	public bool get_IsBackButtonEnable() { }

	public Transform get_ParentalControlTransform() { }

	public MonoBehaviour GetActiveWindow() { }

	private ParentalGateDate GetParentalGateDate() { }

	private ParentalGateMath GetParentalGateMath() { }

	public void HideClickBlocker() { }

	public void OnWindowDestroyed(Window window) { }

	public void OpenNotification(string massage) { }

	public void OpenPerentalControlWithAction(Action onRightAnswer, Action onWrongAnswer = null, bool useDate = true, string context = "") { }

	public Window OpenWindow(string windowName, string prefabSuffx = null) { }

	public Window OpenWindowFromPath(string path, bool allowMultipleOfTheSameType = false) { }

	public Window OpenWindowFromPrefab(Window prefab, bool allowMultipleOfTheSameType = false) { }

	public void OpenWindowWithPerentalControl(string windowName, bool useDate = true, string context = "") { }

	public void OpenWindowWithPerentalControlFromPath(string path, bool useDate = true, string context = "") { }

	public void PlayHideSound() { }

	private void PlaySound(string soundName) { }

	[CompilerGenerated]
	public void set_IsBackButtonEnable(bool value) { }

	public void ShowAndroidDialog() { }

	public void ShowClickBlocker(float visibleAfterDuration = 0) { }

	public Message ShowErrorMessage(string text, Action onCtaClick = null) { }

	public Message ShowMessage(string title, string text, string buttonText, Action onCtaClick = null, bool showCloseButton = true, Action onCloseClick = null, bool showLogo = false) { }

	public Message ShowSuccessMessage(string text, Action onCtaClick = null) { }

	private void Start() { }

	private void Update() { }

}

