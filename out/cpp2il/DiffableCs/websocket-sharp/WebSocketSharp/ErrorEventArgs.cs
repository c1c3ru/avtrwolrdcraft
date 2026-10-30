namespace WebSocketSharp;

public class ErrorEventArgs : EventArgs
{
	private Exception _exception; //Field offset: 0x10
	private string _message; //Field offset: 0x18

	public Exception Exception
	{
		 get { } //Length: 8
	}

	public string Message
	{
		 get { } //Length: 8
	}

	internal ErrorEventArgs(string message) { }

	internal ErrorEventArgs(string message, Exception exception) { }

	public Exception get_Exception() { }

	public string get_Message() { }

}

