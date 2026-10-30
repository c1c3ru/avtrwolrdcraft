namespace PazuCore.GameUpdate.Internal;

public class GameUpdateResponse : Response
{
	public readonly bool hasUpdate; //Field offset: 0x58
	public readonly bool isRequired; //Field offset: 0x59
	public readonly string coverPhotoUrl; //Field offset: 0x60

	public GameUpdateResponse(string responseText) { }

}

