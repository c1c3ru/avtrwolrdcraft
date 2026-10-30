namespace PazuCore.PazuCoreAddressables.AFC.RD;

public class AFCRDCloudCallHandler : AFCRDHandlerBase
{
	private string _op; //Field offset: 0x40
	private string _postData; //Field offset: 0x48

	public AFCRDCloudCallHandler() { }

	[CompilerGenerated]
	private void <ExecuteImplement>b__3_0(string responseText) { }

	protected virtual void ExecuteImplement() { }

	public void SetData(string op, string postData = null) { }

}

