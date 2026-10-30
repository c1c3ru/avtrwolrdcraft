namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCActiveSceneChangedHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onActiveSceneChangedEvent; //Field offset: 0x20

	public AFCActiveSceneChangedHandler() { }

	private void Awake() { }

	private void OnActiveSceneChanged(Scene from, Scene to) { }

	private void OnDestroy() { }

}

