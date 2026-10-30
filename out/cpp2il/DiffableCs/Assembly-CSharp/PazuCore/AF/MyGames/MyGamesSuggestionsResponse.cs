namespace PazuCore.AF.MyGames;

public class MyGamesSuggestionsResponse : Response
{
	public readonly MyGamesSuggestionsData myGamesSuggestionsData; //Field offset: 0x58
	public readonly string myGamesSuggestionsText; //Field offset: 0x60

	public MyGamesSuggestionsResponse(string responseText, string baseData = null) { }

}

