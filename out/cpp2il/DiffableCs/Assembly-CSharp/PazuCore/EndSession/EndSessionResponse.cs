namespace PazuCore.EndSession;

public class EndSessionResponse : Response
{
	public readonly List<Int32> gameIds; //Field offset: 0x58
	public readonly long cardsInterval; //Field offset: 0x60
	public readonly string bottomTitleText; //Field offset: 0x68
	public readonly string topTitleText; //Field offset: 0x70
	public readonly int cardsAmount; //Field offset: 0x78

	public EndSessionResponse(string responseText) { }

}

