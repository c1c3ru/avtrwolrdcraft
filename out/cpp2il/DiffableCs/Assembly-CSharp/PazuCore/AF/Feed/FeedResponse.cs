namespace PazuCore.AF.Feed;

public class FeedResponse : Response
{
	private const string ALREADY_UP_TO_DATE = "ALREADY_UP_TO_DATE"; //Field offset: 0x0
	public readonly long publishTimestamp; //Field offset: 0x58
	public readonly bool isAlreadyUpToDate; //Field offset: 0x60
	public readonly string feedData; //Field offset: 0x68

	public FeedResponse(string responseText) { }

	public virtual void Log(string op) { }

}

