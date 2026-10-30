namespace PazuCore;

public class FakeStore : Window
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public string productName; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal bool <Init>b__0(Product x) { }

	}

	[CompilerGenerated]
	private static bool <IsOnScreen>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private Text _text; //Field offset: 0x30
	[SerializeField]
	private RectTransform _window; //Field offset: 0x38
	private string _productId; //Field offset: 0x40

	public private static bool IsOnScreen
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public FakeStore() { }

	public virtual void CloseWindow() { }

	[CompilerGenerated]
	public static bool get_IsOnScreen() { }

	public void Init(string productName) { }

	public void OnBuyButtonClick() { }

	public void OnCancelButtonClick() { }

	protected virtual void OnDestroy() { }

	public void OnFailureButtonClick() { }

	[CompilerGenerated]
	private static void set_IsOnScreen(bool value) { }

	public static void Show(string productName) { }

}

