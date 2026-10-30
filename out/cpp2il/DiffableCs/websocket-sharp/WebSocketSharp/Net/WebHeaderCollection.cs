namespace WebSocketSharp.Net;

[ComVisible(True)]
[DefaultMember("Item")]
public class WebHeaderCollection : NameValueCollection, ISerializable
{
	private static readonly Dictionary<String, HttpHeaderInfo> _headers; //Field offset: 0x0
	private bool _internallyUsed; //Field offset: 0x68
	private HttpHeaderType _state; //Field offset: 0x6C

	public virtual String[] AllKeys
	{
		 get { } //Length: 8
	}

	public virtual int Count
	{
		 get { } //Length: 8
	}

	public string Item
	{
		 get { } //Length: 188
		 set { } //Length: 4
	}

	public string Item
	{
		 get { } //Length: 188
		 set { } //Length: 4
	}

	public virtual KeysCollection Keys
	{
		 get { } //Length: 8
	}

	internal HttpHeaderType State
	{
		internal get { } //Length: 8
	}

	private static WebHeaderCollection() { }

	internal WebHeaderCollection(HttpHeaderType state, bool internallyUsed) { }

	protected WebHeaderCollection(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	public WebHeaderCollection() { }

	private void add(string name, string value, HttpHeaderType headerType) { }

	public void Add(HttpRequestHeader header, string value) { }

	public void Add(string header) { }

	public void Add(HttpResponseHeader header, string value) { }

	public virtual void Add(string name, string value) { }

	protected void AddWithoutValidate(string headerName, string headerValue) { }

	private void checkAllowed(HttpHeaderType headerType) { }

	private static string checkName(string name, string paramName) { }

	private void checkRestricted(string name, HttpHeaderType headerType) { }

	private static string checkValue(string value, string paramName) { }

	public virtual void Clear() { }

	public virtual string Get(int index) { }

	public virtual string Get(string name) { }

	public virtual String[] get_AllKeys() { }

	public virtual int get_Count() { }

	public string get_Item(HttpResponseHeader header) { }

	public string get_Item(HttpRequestHeader header) { }

	public virtual KeysCollection get_Keys() { }

	internal HttpHeaderType get_State() { }

	public virtual IEnumerator GetEnumerator() { }

	private static HttpHeaderInfo getHeaderInfo(string name) { }

	private static string getHeaderName(string key) { }

	private static HttpHeaderType getHeaderType(string name) { }

	public virtual string GetKey(int index) { }

	public virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	public virtual String[] GetValues(string name) { }

	public virtual String[] GetValues(int index) { }

	internal void InternalRemove(string name) { }

	internal void InternalSet(string name, string value, bool response) { }

	internal void InternalSet(string header, bool response) { }

	private static bool isMultiValue(string name, bool response) { }

	private static bool isRestricted(string name, bool response) { }

	public static bool IsRestricted(string headerName) { }

	public static bool IsRestricted(string headerName, bool response) { }

	public virtual void OnDeserialization(object sender) { }

	public void Remove(HttpRequestHeader header) { }

	public void Remove(HttpResponseHeader header) { }

	public virtual void Remove(string name) { }

	private void set(string name, string value, HttpHeaderType headerType) { }

	public virtual void Set(string name, string value) { }

	public void Set(HttpRequestHeader header, string value) { }

	public void Set(HttpResponseHeader header, string value) { }

	public void set_Item(HttpResponseHeader header, string value) { }

	public void set_Item(HttpRequestHeader header, string value) { }

	private override void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext) { }

	public Byte[] ToByteArray() { }

	public virtual string ToString() { }

	internal string ToStringMultiValue(bool response) { }

}

