namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCRateAppHandler : MonoBehaviour
{
	[SerializeField]
	private bool _parentalGate; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onSuccessEvent; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onFailureEvent; //Field offset: 0x30

	public AFCRateAppHandler() { }

	[CompilerGenerated]
	private void <RateApp>b__3_0(bool success) { }

	public void RateApp() { }

}

