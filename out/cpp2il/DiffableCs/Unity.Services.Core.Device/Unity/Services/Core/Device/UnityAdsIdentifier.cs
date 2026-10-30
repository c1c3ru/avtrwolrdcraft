namespace Unity.Services.Core.Device;

internal class UnityAdsIdentifier : IUserIdentifierProvider
{

	private static string IdentifierForInstallAndroid
	{
		private get { } //Length: 120
		private set { } //Length: 104
	}

	public override string UserId
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public UnityAdsIdentifier() { }

	private static string get_IdentifierForInstallAndroid() { }

	public override string get_UserId() { }

	private static void set_IdentifierForInstallAndroid(string value) { }

	public override void set_UserId(string value) { }

}

