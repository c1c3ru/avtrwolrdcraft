namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRAnalyticsEventCreator : AFCUnityMessageDrivenHandlerBase
{
	internal class CloudResponsePath
	{
		public string key; //Field offset: 0x10
		public String[] path; //Field offset: 0x18

		public CloudResponsePath() { }

	}

	[SerializeField]
	private bool _useCR; //Field offset: 0x24
	[SerializeField]
	private AFCCRAnalyticsContextSetter _context; //Field offset: 0x28
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x30
	[SerializeField]
	private String[] _parameters; //Field offset: 0x38
	[SerializeField]
	private CloudResponsePath[] _cloudPaths; //Field offset: 0x40

	public AFCCRAnalyticsEventCreator() { }

	public void CreateAnalyticsEvent() { }

	public virtual void PerformAction() { }

}

