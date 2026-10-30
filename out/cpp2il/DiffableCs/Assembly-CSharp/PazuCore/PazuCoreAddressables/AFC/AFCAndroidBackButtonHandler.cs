namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCAndroidBackButtonHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onClickEvent; //Field offset: 0x20

	public AFCAndroidBackButtonHandler() { }

	private void Awake() { }

	private bool OnBackButton() { }

	private void OnDestroy() { }

}

