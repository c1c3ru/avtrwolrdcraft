namespace WebSocketSharp.Net;

internal sealed class EndPointManager
{
	private static readonly Dictionary<IPEndPoint, EndPointListener> _endpoints; //Field offset: 0x0

	private static EndPointManager() { }

	private EndPointManager() { }

	public static void AddListener(HttpListener listener) { }

	private static void addPrefix(string uriPrefix, HttpListener listener) { }

	public static void AddPrefix(string uriPrefix, HttpListener listener) { }

	private static IPAddress convertToIPAddress(string hostname) { }

	internal static bool RemoveEndPoint(IPEndPoint endpoint) { }

	public static void RemoveListener(HttpListener listener) { }

	private static void removePrefix(string uriPrefix, HttpListener listener) { }

	public static void RemovePrefix(string uriPrefix, HttpListener listener) { }

}

