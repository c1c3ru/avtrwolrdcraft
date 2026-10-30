namespace Unity.Services.Authentication;

internal class NetworkConfiguration : INetworkConfiguration
{
	private const int k_DefaultRetries = 2; //Field offset: 0x0
	private const int k_DefaultTimeout = 10; //Field offset: 0x0
	[CompilerGenerated]
	private int <Retries>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <Timeout>k__BackingField; //Field offset: 0x14

	public override int Retries
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override int Timeout
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public NetworkConfiguration() { }

	[CompilerGenerated]
	public override int get_Retries() { }

	[CompilerGenerated]
	public override int get_Timeout() { }

	[CompilerGenerated]
	public void set_Retries(int value) { }

	[CompilerGenerated]
	public void set_Timeout(int value) { }

}

