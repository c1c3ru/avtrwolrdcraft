namespace Unity.Services.Relay;

internal interface IRelayServiceSdk
{

	public IAccessToken AccessToken
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IRelayAllocationsApiClient AllocationsApi
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Configuration Configuration
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IQosResults QosResults
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IAccessToken get_AccessToken() { }

	public IRelayAllocationsApiClient get_AllocationsApi() { }

	public Configuration get_Configuration() { }

	public IQosResults get_QosResults() { }

	public void set_AccessToken(IAccessToken value) { }

	public void set_AllocationsApi(IRelayAllocationsApiClient value) { }

	public void set_Configuration(Configuration value) { }

	public void set_QosResults(IQosResults value) { }

}

