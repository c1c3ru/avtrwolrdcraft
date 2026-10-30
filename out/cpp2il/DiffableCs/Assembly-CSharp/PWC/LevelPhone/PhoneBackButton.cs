namespace PWC.LevelPhone;

public class PhoneBackButton : GameUIElement, IPointerDownHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public bool value; //Field offset: 0x10
		public PhoneBackButton <>4__this; //Field offset: 0x18
		public Action onCompleteAction; //Field offset: 0x20

		public <>c__DisplayClass6_0() { }

		internal void <Animate>b__0() { }

	}

	[CompilerGenerated]
	private static Action OnBackButtonClickAction; //Field offset: 0x0
	private bool _isInteractable; //Field offset: 0x21
	private int _tweenID; //Field offset: 0x24

	public static event Action OnBackButtonClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public PhoneBackButton() { }

	[CompilerGenerated]
	public static void add_OnBackButtonClickAction(Action value) { }

	public void Animate(bool value, Action onCompleteAction = null) { }

	public virtual void OnPointerDown(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnBackButtonClickAction(Action value) { }

}

