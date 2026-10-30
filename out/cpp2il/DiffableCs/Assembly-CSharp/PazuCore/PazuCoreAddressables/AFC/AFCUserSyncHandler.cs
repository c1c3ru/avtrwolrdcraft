namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCUserSyncHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onSubscriptionActiveEvent; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onSubscriptionNotActiveEvent; //Field offset: 0x28

	public AFCUserSyncHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnUserSync(SyncType syncType) { }

}

