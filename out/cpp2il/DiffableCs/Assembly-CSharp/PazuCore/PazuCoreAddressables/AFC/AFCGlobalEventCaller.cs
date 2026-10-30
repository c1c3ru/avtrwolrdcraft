namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCGlobalEventCaller : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private string _eventName; //Field offset: 0x28

	public AFCGlobalEventCaller() { }

	public virtual void PerformAction() { }

	public static bool TryCallEvent(string eventName) { }

}

