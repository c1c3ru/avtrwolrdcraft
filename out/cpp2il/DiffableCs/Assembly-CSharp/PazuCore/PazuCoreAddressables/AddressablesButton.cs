namespace PazuCore.PazuCoreAddressables;

public class AddressablesButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerClickHandler
{
	[CompilerGenerated]
	private static Action<AddressablesButton> OnButtonClickAction; //Field offset: 0x0
	[CompilerGenerated]
	private Action OnButtonDownAction; //Field offset: 0x20
	[CompilerGenerated]
	private Action OnButtonUpAction; //Field offset: 0x28
	[SerializeField]
	private Sprite _staticSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _pressedSprite; //Field offset: 0x38
	[SerializeField]
	private string _id; //Field offset: 0x40
	private Image _image; //Field offset: 0x48

	public static event Action<AddressablesButton> OnButtonClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public event Action OnButtonDownAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action OnButtonUpAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public string ID
	{
		 get { } //Length: 8
	}

	public AddressablesButton() { }

	[CompilerGenerated]
	public static void add_OnButtonClickAction(Action<AddressablesButton> value) { }

	[CompilerGenerated]
	public void add_OnButtonDownAction(Action value) { }

	[CompilerGenerated]
	public void add_OnButtonUpAction(Action value) { }

	protected override void Awake() { }

	public string get_ID() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected override void OnPointerClickInternal() { }

	public override void OnPointerDown(PointerEventData eventData) { }

	protected override void OnPointerDownInternal() { }

	public override void OnPointerUp(PointerEventData eventData) { }

	protected override void OnPointerUpInternal() { }

	[CompilerGenerated]
	public static void remove_OnButtonClickAction(Action<AddressablesButton> value) { }

	[CompilerGenerated]
	public void remove_OnButtonDownAction(Action value) { }

	[CompilerGenerated]
	public void remove_OnButtonUpAction(Action value) { }

}

