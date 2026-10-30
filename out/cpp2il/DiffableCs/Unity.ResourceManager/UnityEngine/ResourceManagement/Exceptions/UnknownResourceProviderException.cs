namespace UnityEngine.ResourceManagement.Exceptions;

public class UnknownResourceProviderException : ResourceManagerException
{
	[CompilerGenerated]
	private IResourceLocation <Location>k__BackingField; //Field offset: 0x90

	public private IResourceLocation Location
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public virtual string Message
	{
		 get { } //Length: 444
	}

	public UnknownResourceProviderException(IResourceLocation location) { }

	public UnknownResourceProviderException() { }

	public UnknownResourceProviderException(string message) { }

	public UnknownResourceProviderException(string message, Exception innerException) { }

	protected UnknownResourceProviderException(SerializationInfo message, StreamingContext context) { }

	[CompilerGenerated]
	public IResourceLocation get_Location() { }

	public virtual string get_Message() { }

	[CompilerGenerated]
	private void set_Location(IResourceLocation value) { }

	public virtual string ToString() { }

}

