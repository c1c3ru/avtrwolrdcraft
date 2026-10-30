namespace WebSocketSharp.Net;

internal sealed class QueryStringCollection : NameValueCollection
{

	public QueryStringCollection() { }

	public QueryStringCollection(int capacity) { }

	public static QueryStringCollection Parse(string query) { }

	public static QueryStringCollection Parse(string query, Encoding encoding) { }

	public virtual string ToString() { }

	private static string urlDecode(string s, Encoding encoding) { }

}

