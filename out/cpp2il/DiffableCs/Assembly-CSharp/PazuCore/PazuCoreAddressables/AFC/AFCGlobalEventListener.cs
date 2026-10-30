namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCGlobalEventListener : MonoBehaviour
{
	[SerializeField]
	private string _eventName; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onEventCall; //Field offset: 0x28

	public AFCGlobalEventListener() { }

	private void Awake() { }

	private void CallEvent() { }

	private void OnDestroy() { }

}

