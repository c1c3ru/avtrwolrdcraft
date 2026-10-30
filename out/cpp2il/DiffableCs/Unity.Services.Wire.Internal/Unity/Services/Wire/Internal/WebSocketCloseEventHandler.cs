namespace Unity.Services.Wire.Internal;

internal sealed class WebSocketCloseEventHandler : MulticastDelegate
{

	public WebSocketCloseEventHandler(object object, IntPtr method) { }

	public override IAsyncResult BeginInvoke(WebSocketCloseCode closeCode, AsyncCallback callback, object object) { }

	public override void EndInvoke(IAsyncResult result) { }

	public override void Invoke(WebSocketCloseCode closeCode) { }

}

