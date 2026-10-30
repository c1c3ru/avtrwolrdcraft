namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCRestoreFailedHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onEvent; //Field offset: 0x20

	public AFCRestoreFailedHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnRestoreFailed(string message) { }

}

