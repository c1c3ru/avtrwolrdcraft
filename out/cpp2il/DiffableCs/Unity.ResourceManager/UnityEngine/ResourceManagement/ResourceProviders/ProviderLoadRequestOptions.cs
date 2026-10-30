namespace UnityEngine.ResourceManagement.ResourceProviders;

public class ProviderLoadRequestOptions
{
	[SerializeField]
	private bool m_IgnoreFailures; //Field offset: 0x10
	private int m_WebRequestTimeout; //Field offset: 0x14

	public bool IgnoreFailures
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public int WebRequestTimeout
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ProviderLoadRequestOptions() { }

	public ProviderLoadRequestOptions Copy() { }

	public bool get_IgnoreFailures() { }

	public int get_WebRequestTimeout() { }

	public void set_IgnoreFailures(bool value) { }

	public void set_WebRequestTimeout(int value) { }

}

