namespace PazuCore.PazuGameMode;

public class PazuGameModeResponse : Response
{
	public readonly bool isGameInReview; //Field offset: 0x58
	public readonly GameMarketingMode gameMarketingMode; //Field offset: 0x5C
	public readonly bool shouldSendAnalyticsEvents; //Field offset: 0x60
	public readonly Config config; //Field offset: 0x68

	public PazuGameModeResponse(string responseText) { }

}

