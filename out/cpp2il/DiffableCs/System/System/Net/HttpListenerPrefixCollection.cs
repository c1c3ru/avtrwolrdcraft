namespace System.Net;

public class HttpListenerPrefixCollection : ICollection<String>, IEnumerable<String>, IEnumerable
{
	private List<String> prefixes; //Field offset: 0x10
	private HttpListener listener; //Field offset: 0x18

	public override int Count
	{
		 get { } //Length: 72
	}

	public override bool IsReadOnly
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

	public override IEnumerator<String> GetEnumerator() { }

	public override bool Remove(string uriPrefix) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

