namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRAnalyticsContextSetter : AFCUnityMessageDrivenHandlerBase
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
	private bool _sendContextRemovedEventIfOtherContextExist; //Field offset: 0x30
	[SerializeField]
	private bool _resetContextForEverySetCall; //Field offset: 0x31
	[SerializeField]
	private String[] _parameters; //Field offset: 0x38
	[SerializeField]
	private CloudResponsePath[] _cloudPaths; //Field offset: 0x40
	private String[] _parametersToUse; //Field offset: 0x48

	public AFCCRAnalyticsContextSetter() { }

	public String[] GetContext() { }

	public virtual void PerformAction() { }

	public void ResetContext() { }

	public void SetContext() { }

}

