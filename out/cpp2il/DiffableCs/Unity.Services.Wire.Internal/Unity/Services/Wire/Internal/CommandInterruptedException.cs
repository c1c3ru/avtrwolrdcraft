namespace Unity.Services.Wire.Internal;

public class CommandInterruptedException : RequestFailedException
{
	[CompilerGenerated]
	private CentrifugeCloseCode <m_Code>k__BackingField; //Field offset: 0x90

	public private CentrifugeCloseCode m_Code
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public CommandInterruptedException(string reason, CentrifugeCloseCode code) { }

	[CompilerGenerated]
	public CentrifugeCloseCode get_m_Code() { }

	[CompilerGenerated]
	private void set_m_Code(CentrifugeCloseCode value) { }

}

