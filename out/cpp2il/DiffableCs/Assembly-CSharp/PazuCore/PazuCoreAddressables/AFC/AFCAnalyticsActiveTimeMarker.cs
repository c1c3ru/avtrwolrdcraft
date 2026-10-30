namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCAnalyticsActiveTimeMarker : AFCUnityMessageDrivenHandlerBase
{
	public static readonly Dictionary<String, Double> SavedValues; //Field offset: 0x0
	[SerializeField]
	private string _key; //Field offset: 0x28
	[SerializeField]
	private bool _keepValueOnDestroy; //Field offset: 0x30

	private static AFCAnalyticsActiveTimeMarker() { }

	public AFCAnalyticsActiveTimeMarker() { }

	protected virtual void OnDestroy() { }

	public virtual void PerformAction() { }

}

