namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCAnalyticsEventCreator : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private String[] _parameters; //Field offset: 0x28

	public AFCAnalyticsEventCreator() { }

	public void CreateAnalyticsEvent() { }

	public virtual void PerformAction() { }

}

