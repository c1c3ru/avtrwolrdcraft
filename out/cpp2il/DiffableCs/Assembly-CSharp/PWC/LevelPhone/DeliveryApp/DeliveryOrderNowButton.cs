namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryOrderNowButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__4_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnPointerClick>b__4_1() { }

	}

	[CompilerGenerated]
	private static Action OnOrderNowButtonClickAction; //Field offset: 0x0
	private bool _isInteractable; //Field offset: 0x20

	public static event Action OnOrderNowButtonClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public DeliveryOrderNowButton() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__4_0() { }

	[CompilerGenerated]
	public static void add_OnOrderNowButtonClickAction(Action value) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnOrderNowButtonClickAction(Action value) { }

	public void SetInteractable() { }

}

