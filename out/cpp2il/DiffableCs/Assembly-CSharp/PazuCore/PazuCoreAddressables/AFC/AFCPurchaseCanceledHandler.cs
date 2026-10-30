namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPurchaseCanceledHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onEvent; //Field offset: 0x20

	public AFCPurchaseCanceledHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPurchaseCanceled(string message) { }

}

