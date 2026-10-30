namespace PazuCore;

public class RateUs : Window
{
	[CompilerGenerated]
	private static Action HideRateUsForeverHandler; //Field offset: 0x0
	[SerializeField]
	private WindowWithCat _windowWithCat; //Field offset: 0x30
	[CompilerGenerated]
	private Action<Boolean> OnButtonClick; //Field offset: 0x38

	public static event Action HideRateUsForeverHandler
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public event Action<Boolean> OnButtonClick
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public RateUs() { }

	[CompilerGenerated]
	public static void add_HideRateUsForeverHandler(Action value) { }

	[CompilerGenerated]
	public void add_OnButtonClick(Action<Boolean> value) { }

	private void Awake() { }

	public virtual void CloseWindow() { }

	public void OnCloseButtonClick() { }

	public void OnEmojiClick(int number) { }

	public static Window OpenWindow() { }

	[CompilerGenerated]
	public static void remove_HideRateUsForeverHandler(Action value) { }

	[CompilerGenerated]
	public void remove_OnButtonClick(Action<Boolean> value) { }

	private void Start() { }

}

