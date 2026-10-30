namespace PazuCore.AF.ActionBar;

[RequireComponent(typeof(Toggle))]
public abstract class ToggleBase : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IDeselectHandler
{
	[SerializeField]
	protected Text _text; //Field offset: 0x20
	[SerializeField]
	protected Image _image; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onSelected; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onUnSelected; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onPressed; //Field offset: 0x40
	private bool _lastValue; //Field offset: 0x48
	protected Toggle _toggle; //Field offset: 0x50
	private Sprite _normalSprite; //Field offset: 0x58

	protected ToggleBase() { }

	[CompilerGenerated]
	private void <OnValueChanged>b__9_0() { }

	protected override void Awake() { }

	public override void OnDeselect(BaseEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void OnPointerUp(PointerEventData eventData) { }

	protected override void OnSelected(bool byUserInput) { }

	protected override void OnUnSelected() { }

	private void OnValueChanged(bool value) { }

	protected abstract void OnValueChangedOverride(bool value) { }

}

