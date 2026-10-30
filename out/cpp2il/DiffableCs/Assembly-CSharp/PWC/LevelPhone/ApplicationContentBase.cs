namespace PWC.LevelPhone;

public abstract class ApplicationContentBase : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<Boolean> OnApplicationContentCloseAction; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <IsAnimating>k__BackingField; //Field offset: 0x8
	[SerializeField]
	protected ApplicationType _applicationType; //Field offset: 0x20
	[SerializeField]
	protected GameObject _content; //Field offset: 0x28
	protected bool _isActive; //Field offset: 0x30

	public static event Action<Boolean> OnApplicationContentCloseAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static bool IsAnimating
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		 set { } //Length: 80
	}

	protected ApplicationContentBase() { }

	[CompilerGenerated]
	public static void add_OnApplicationContentCloseAction(Action<Boolean> value) { }

	protected override void Awake() { }

	protected override void CallOnApplicationContentCloseAction() { }

	[CompilerGenerated]
	public static bool get_IsAnimating() { }

	protected override bool GetShouldBackToApps() { }

	protected override void OnApplicationClick(Application application) { }

	protected override void OnApplicationEndAnimation(bool value) { }

	private void OnApplicationEndAnimationInternal(bool value) { }

	protected override void OnBackButtonClick() { }

	protected override void OnDestroy() { }

	protected override void OnSetActive(bool value) { }

	[CompilerGenerated]
	public static void remove_OnApplicationContentCloseAction(Action<Boolean> value) { }

	[CompilerGenerated]
	protected static void set_IsAnimating(bool value) { }

	public void SetActiveImplement(bool isActive) { }

}

