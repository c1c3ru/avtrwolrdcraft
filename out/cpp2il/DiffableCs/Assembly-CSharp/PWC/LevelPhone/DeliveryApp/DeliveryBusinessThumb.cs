namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryBusinessThumb : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public Action onCompleteSetActiveAction; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal void <Animate>b__0() { }

	}

	[CompilerGenerated]
	private static Action<DeliveryBusinessData> OnBusinessThumbClickAction; //Field offset: 0x0
	[SerializeField]
	private Image _banner; //Field offset: 0x20
	private bool _isComingSoon; //Field offset: 0x28
	private int _tweenID; //Field offset: 0x2C
	private DeliveryBusinessData _businessData; //Field offset: 0x30

	public static event Action<DeliveryBusinessData> OnBusinessThumbClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public DeliveryBusinessThumb() { }

	[CompilerGenerated]
	public static void add_OnBusinessThumbClickAction(Action<DeliveryBusinessData> value) { }

	public void Animate(bool value, Action onCompleteSetActiveAction = null) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnBusinessThumbClickAction(Action<DeliveryBusinessData> value) { }

	public void SetData(DeliveryBusinessData businessData) { }

}

