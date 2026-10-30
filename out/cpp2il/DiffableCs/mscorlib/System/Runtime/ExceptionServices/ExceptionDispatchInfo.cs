namespace System.Runtime.ExceptionServices;

public sealed class ExceptionDispatchInfo
{
	private Exception m_Exception; //Field offset: 0x10
	private object m_stackTrace; //Field offset: 0x18

	internal object BinaryStackTraceArray
	{
		internal get { } //Length: 8
	}

	public Exception SourceException
	{
		 get { } //Length: 8
	}

	private ExceptionDispatchInfo(Exception exception) { }

	internal ExceptionDispatchInfo() { }

	public static ExceptionDispatchInfo Capture(Exception source) { }

	internal object get_BinaryStackTraceArray() { }

	public Exception get_SourceException() { }

	[StackTraceHidden]
	public void Throw() { }

	[StackTraceHidden]
	public static void Throw(Exception source) { }

}

