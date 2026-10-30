namespace PWC.QA.RTA;

public class RTAQuickClicksPanelSpawner : RTAMonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private static float MAX_CLICK_DELAY_SEC; //Field offset: 0x0
	[SerializeField]
	private int _pressesInvoke; //Field offset: 0x20
	private int _currentClickCount; //Field offset: 0x24
	private float _lastClickTime; //Field offset: 0x28

	private static RTAQuickClicksPanelSpawner() { }

	public RTAQuickClicksPanelSpawner() { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

