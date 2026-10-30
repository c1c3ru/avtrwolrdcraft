namespace PWC.Level;

public class TooltipUIHandler : MonoBehaviour
{
	[SerializeField]
	private GameObject _tooltipPrefab; //Field offset: 0x20
	[SerializeField]
	private Transform _tooltipParent; //Field offset: 0x28
	private GameObject _tooltip; //Field offset: 0x30
	private StoreTweenToolipHandle _tooltipHandle; //Field offset: 0x38

	public TooltipUIHandler() { }

	private void HideTooltip() { }

	private void HideTooltip(bool value) { }

	private void InstantiateTooltip() { }

	public void ShowTooltip(PointerEventData eventData) { }

	public void ShowTooltipWithText(PointerEventData eventData, string textContent) { }

}

