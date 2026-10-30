namespace UnityEngine.ResourceManagement.Exceptions;

public class ProviderException : OperationException
{
	[CompilerGenerated]
	private readonly IResourceLocation <Location>k__BackingField; //Field offset: 0x90

	public IResourceLocation Location
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public ProviderException(string message, IResourceLocation location = null, Exception innerException = null) { }

	[CompilerGenerated]
	public IResourceLocation get_Location() { }

}

