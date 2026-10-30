namespace PWC.GamePopups;

public class GamePopup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public Vector2 localPosition; //Field offset: 0x10
		public GamePopup <>4__this; //Field offset: 0x18
		public bool value; //Field offset: 0x20

		public <>c__DisplayClass12_0() { }

		internal void <Animate>b__0(float localYPosition) { }

		internal void <Animate>b__1() { }

	}

	[CompilerGenerated]
	private static Action<Boolean> OnButtonPressAction; //Field offset: 0x0
	[CompilerGenerated]
	private Action<Boolean> OnInstanceButtonPressAction; //Field offset: 0x20
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	protected Image _customSpriteImage; //Field offset: 0x30
	protected bool _isInteractable; //Field offset: 0x38
	protected RectTransform _rectTransform; //Field offset: 0x40

	public static event Action<Boolean> OnButtonPressAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public event Action<Boolean> OnInstanceButtonPressAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public GamePopup() { }

	[CompilerGenerated]
	public static void add_OnButtonPressAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public void add_OnInstanceButtonPressAction(Action<Boolean> value) { }

	protected override void Animate(bool value) { }

	protected override void Awake() { }

	protected void ClearInstanceButtonPressSubscribers() { }

	public override void Init(Sprite sprite = null, Sprite customSprite = null, float customSpriteScale = 1, GameObject prefab = null, bool disableImage = true) { }

	protected override bool OnAndroidBack() { }

	public override void OnButtonPress(bool value) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_OnButtonPressAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public void remove_OnInstanceButtonPressAction(Action<Boolean> value) { }

}

