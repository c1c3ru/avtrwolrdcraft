namespace PazuCore.Analytics.Internal;

public class AnalyticsResponse : Response
{
	public readonly bool isBadVersion; //Field offset: 0x58
	public readonly float intervalOverride; //Field offset: 0x5C

	public AnalyticsResponse() { }

	public AnalyticsResponse(string responseText) { }

}

