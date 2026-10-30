namespace PazuCore.PazuCloud;

public class ClientStateResponse : UserDataResponse
{
	public readonly List<Int32> installedGames; //Field offset: 0x88
	public readonly string pazuCloudId; //Field offset: 0x90
	public readonly long serverTime; //Field offset: 0x98
	public readonly long localTime; //Field offset: 0xA0
	public readonly Item avatarPassRewardItemToClaim; //Field offset: 0xA8

	public ClientStateResponse(string responseText) { }

}

