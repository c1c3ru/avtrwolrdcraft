namespace PazuCore;

public class RateUsWidget : Selectable, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private SkeletonGraphic _cat; //Field offset: 0x100
	[SerializeField]
	private Graphic[] _graphics; //Field offset: 0x108

	public RateUsWidget() { }

	protected virtual void Awake() { }

	protected virtual void DoStateTransition(SelectionState state, bool instant) { }

	private void HideRateUsButton() { }

	protected virtual void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	protected virtual void Start() { }

}

