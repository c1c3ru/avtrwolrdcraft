namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPurchaseFailedHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onEvent; //Field offset: 0x20

	public AFCPurchaseFailedHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPurchaseFailed(string productId, string message) { }

}

