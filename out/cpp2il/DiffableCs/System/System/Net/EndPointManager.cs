namespace System.Net;

internal sealed class EndPointManager
{
	private static Hashtable ip_to_endpoints; //Field offset: 0x0

	private static EndPointManager() { }

	public static void AddListener(HttpListener listener) { }

	public static void AddPrefix(string prefix, HttpListener listener) { }

	private static void AddPrefixInternal(string p, HttpListener listener) { }

	private static EndPointListener GetEPListener(string host, int port, HttpListener listener, bool secure) { }

	public static void RemoveEndPoint(EndPointListener epl, IPEndPoint ep) { }

	public static void RemoveListener(HttpListener listener) { }

	public static void RemovePrefix(string prefix, HttpListener listener) { }

	private static void RemovePrefixInternal(string prefix, HttpListener listener) { }

}

