namespace Unity.Services.Relay.ErrorMitigation;

internal sealed class ExceptionPredicate : MulticastDelegate
{

	public ExceptionPredicate(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(Exception ex, AsyncCallback callback, object object) { }

	public override Exception EndInvoke(IAsyncResult result) { }

	public override Exception Invoke(Exception ex) { }

}

