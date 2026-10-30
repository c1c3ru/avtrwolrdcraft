namespace WebSocketSharp.Net;

public class HttpListenerPrefixCollection : ICollection<String>, IEnumerable<String>, IEnumerable
{
	private HttpListener _listener; //Field offset: 0x10
	private List<String> _prefixes; //Field offset: 0x18

	public override int Count
	{
		 get { } //Length: 72
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 8
	}

	public bool IsSynchronized
	{
		 get { } //Length: 8
	}

	internal HttpListenerPrefixCollection(HttpListener listener) { }

	public override void Add(string uriPrefix) { }

	public override void Clear() { }

	public override bool Contains(string uriPrefix) { }

	public override void CopyTo(String[] array, int offset) { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public bool get_IsSynchronized() { }

	public override IEnumerator<String> GetEnumerator() { }

	public override bool Remove(string uriPrefix) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

