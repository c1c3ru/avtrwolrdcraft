namespace Unity.Services.Authentication.PlayerAccounts;

internal interface INetworkConfiguration
{

	public int Retries
	{
		 get { } //Length: 0
	}

	public int Timeout
	{
		 get { } //Length: 0
	}

	public int get_Retries() { }

	public int get_Timeout() { }

}

