namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRAnalyticsContextOverrideValues : AFCUnityMessageDrivenHandlerBase
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
	private string _cloudResponseKey; //Field offset: 0x28
	[SerializeField]
	private String[] _pairs; //Field offset: 0x30
	[SerializeField]
	private CloudResponsePath[] _cloudPaths; //Field offset: 0x38
	private String[] _pairsToUse; //Field offset: 0x40

	public AFCCRAnalyticsContextOverrideValues() { }

	public String[] GetPairs() { }

	public virtual void PerformAction() { }

	public void SetContextOverrideValues() { }

}

