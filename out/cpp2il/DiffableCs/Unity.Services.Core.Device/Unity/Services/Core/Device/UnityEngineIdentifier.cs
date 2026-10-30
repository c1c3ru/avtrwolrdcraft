namespace Unity.Services.Core.Device;

internal class UnityEngineIdentifier : IUserIdentifierProvider
{

	public override string UserId
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public UnityEngineIdentifier() { }

	public override string get_UserId() { }

	public override void set_UserId(string value) { }

}

