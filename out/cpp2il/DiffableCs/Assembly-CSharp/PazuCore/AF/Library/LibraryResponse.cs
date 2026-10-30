namespace PazuCore.AF.Library;

public class LibraryResponse : Response
{
	private const string ALREADY_UP_TO_DATE = "ALREADY_UP_TO_DATE"; //Field offset: 0x0
	public readonly string libraryJson; //Field offset: 0x58
	public readonly bool isAlreadyUpToDate; //Field offset: 0x60

	public LibraryResponse(string responseText) { }

}

