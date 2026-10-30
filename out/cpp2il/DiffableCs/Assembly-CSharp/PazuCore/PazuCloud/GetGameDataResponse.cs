namespace PazuCore.PazuCloud;

public class GetGameDataResponse : Response
{
	public readonly string gameDataJson; //Field offset: 0x58
	public readonly bool hasData; //Field offset: 0x60

	public GetGameDataResponse(string responseText) { }

}

