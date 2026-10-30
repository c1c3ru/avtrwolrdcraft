namespace PWC.Multiplayer;

public class MPSigninCloudResponse : Response
{
	public readonly string idToken; //Field offset: 0x58
	public readonly string sessionToken; //Field offset: 0x60

	public MPSigninCloudResponse(string responseText) { }

}

