namespace Unity.Services.Authentication.PlayerAccounts;

internal class AndroidBrowserUtils : IBrowserUtils
{
	private readonly ICloudProjectId m_CloudProjectId; //Field offset: 0x10
	private readonly UnityPlayerAccountSettings m_Settings; //Field offset: 0x18

	public AndroidBrowserUtils(ICloudProjectId cloudProjectId, UnityPlayerAccountSettings settings) { }

	public override bool Bind() { }

	public override void Dismiss() { }

	public override string GetRedirectUri() { }

	public override Task LaunchUrlAsync(string url) { }

}

