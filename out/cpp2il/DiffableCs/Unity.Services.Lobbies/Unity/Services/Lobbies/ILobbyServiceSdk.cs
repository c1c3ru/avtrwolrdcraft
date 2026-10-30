namespace Unity.Services.Lobbies;

internal interface ILobbyServiceSdk
{

	public Configuration Configuration
	{
		 get { } //Length: 0
	}

	public ILobbyApiClient LobbyApi
	{
		 get { } //Length: 0
	}

	public IMetrics Metrics
	{
		 get { } //Length: 0
	}

	public IWire Wire
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Configuration get_Configuration() { }

	public ILobbyApiClient get_LobbyApi() { }

	public IMetrics get_Metrics() { }

	public IWire get_Wire() { }

	public void set_Wire(IWire value) { }

}

