namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCAnalyticsContextRemover : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private bool _sendAnalyticsEvent; //Field offset: 0x24

	public AFCAnalyticsContextRemover() { }

	public void ClearContext() { }

	public virtual void PerformAction() { }

}

