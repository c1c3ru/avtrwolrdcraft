namespace Unity.Services.Wire.Internal;

internal interface IWebsocketFactory
{

	public IWebSocket CreateInstance(string url) { }

}

