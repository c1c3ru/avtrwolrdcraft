namespace WebSocketSharp.Net;

[DefaultMember("Item")]
public class CookieCollection : ICollection<Cookie>, IEnumerable<Cookie>, IEnumerable
{
	private List<Cookie> _list; //Field offset: 0x10
	private bool _readOnly; //Field offset: 0x18
	private object _sync; //Field offset: 0x20

	public override int Count
	{
		 get { } //Length: 72
	}

	public internal override bool IsReadOnly
	{
		 get { } //Length: 8
		internal set { } //Length: 12
	}

	public bool IsSynchronized
	{
		 get { } //Length: 8
	}

	public Cookie Item
	{
		 get { } //Length: 188
	}

	public Cookie Item
	{
		 get { } //Length: 908
	}

	internal IList<Cookie> List
	{
		internal get { } //Length: 8
	}

	internal IEnumerable<Cookie> Sorted
	{
		internal get { } //Length: 260
	}

	public object SyncRoot
	{
		 get { } //Length: 8
	}

	public CookieCollection() { }

	private void add(Cookie cookie) { }

	public void Add(CookieCollection cookies) { }

	public override void Add(Cookie cookie) { }

	public override void Clear() { }

	private static int compareForSort(Cookie x, Cookie y) { }

	private static int compareForSorted(Cookie x, Cookie y) { }

	public override bool Contains(Cookie cookie) { }

	public override void CopyTo(Cookie[] array, int index) { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public bool get_IsSynchronized() { }

	public Cookie get_Item(int index) { }

	public Cookie get_Item(string name) { }

	internal IList<Cookie> get_List() { }

	internal IEnumerable<Cookie> get_Sorted() { }

	public object get_SyncRoot() { }

	public override IEnumerator<Cookie> GetEnumerator() { }

	internal static CookieCollection Parse(string value, bool response) { }

	private static CookieCollection parseRequest(string value) { }

	private static CookieCollection parseResponse(string value) { }

	public override bool Remove(Cookie cookie) { }

	private int search(Cookie cookie) { }

	internal void set_IsReadOnly(bool value) { }

	internal void SetOrRemove(CookieCollection cookies) { }

	internal void SetOrRemove(Cookie cookie) { }

	internal void Sort() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private static string urlDecode(string s, Encoding encoding) { }

}

