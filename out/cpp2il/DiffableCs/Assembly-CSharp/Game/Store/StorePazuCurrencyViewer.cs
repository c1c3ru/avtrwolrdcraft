namespace Game.Store;

public class StorePazuCurrencyViewer : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private TextMeshProUGUI _text; //Field offset: 0x20
	[SerializeField]
	private GameObject _tooltip; //Field offset: 0x28
	private StoreTweenToolipHandle _tooltipHandle; //Field offset: 0x30

	public StorePazuCurrencyViewer() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void ShowTooltip() { }

	public void SyncText() { }

}

