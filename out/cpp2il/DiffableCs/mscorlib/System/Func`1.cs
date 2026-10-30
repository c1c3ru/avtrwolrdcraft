namespace System;

public sealed class Func : MulticastDelegate
{

	public Func`1(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

	public override TResult EndInvoke(IAsyncResult result) { }

	public override TResult Invoke() { }

}

