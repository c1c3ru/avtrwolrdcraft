namespace Ugi.PlayInstallReferrerPlugin;

public class PlayInstallReferrerError
{
	[CompilerGenerated]
	private readonly int <ResponseCode>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Exception <Exception>k__BackingField; //Field offset: 0x18

	public Exception Exception
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public int ResponseCode
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	internal PlayInstallReferrerError(int responseCode, Exception exception) { }

	[CompilerGenerated]
	public Exception get_Exception() { }

	[CompilerGenerated]
	public int get_ResponseCode() { }

}

