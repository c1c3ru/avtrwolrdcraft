namespace PazuCore.PazuCloud;

public class RegisterDeviceResponse : Response
{
	public readonly string deviceToken; //Field offset: 0x58
	public readonly string jwtPassphrase; //Field offset: 0x60

	public RegisterDeviceResponse(string responseText) { }

}

