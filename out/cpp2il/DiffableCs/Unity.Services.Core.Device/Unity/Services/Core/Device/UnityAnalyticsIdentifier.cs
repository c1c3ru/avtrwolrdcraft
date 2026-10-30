namespace Unity.Services.Core.Device;

internal class UnityAnalyticsIdentifier : IUserIdentifierProvider
{

	public override string UserId
	{
		 get { } //Length: 68
		 set { } //Length: 204
	}

	public UnityAnalyticsIdentifier() { }

	public override string get_UserId() { }

	public override void set_UserId(string value) { }

}

