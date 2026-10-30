namespace System;

public class UnhandledExceptionEventArgs : EventArgs
{
	private object _exception; //Field offset: 0x10
	private bool _isTerminating; //Field offset: 0x18

	public object ExceptionObject
	{
		 get { } //Length: 8
	}

	public bool IsTerminating
	{
		 get { } //Length: 8
	}

	public UnhandledExceptionEventArgs(object exception, bool isTerminating) { }

	public object get_ExceptionObject() { }

	public bool get_IsTerminating() { }

}

