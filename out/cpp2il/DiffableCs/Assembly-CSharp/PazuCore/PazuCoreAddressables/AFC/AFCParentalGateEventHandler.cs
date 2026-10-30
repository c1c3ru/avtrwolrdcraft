namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCParentalGateEventHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onSuccessEvent; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onFailureEvent; //Field offset: 0x28

	public AFCParentalGateEventHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnParentalGateClose(bool success) { }

}

