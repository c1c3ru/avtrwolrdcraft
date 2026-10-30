namespace System;

public sealed class Action : MulticastDelegate
{

	public Action`1(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(T obj, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(T obj) { }

}

