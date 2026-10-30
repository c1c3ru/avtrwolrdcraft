namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCUnityMessageHandler : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private UnityEvent _onEvent; //Field offset: 0x28

	public AFCUnityMessageHandler() { }

	public virtual void PerformAction() { }

}

