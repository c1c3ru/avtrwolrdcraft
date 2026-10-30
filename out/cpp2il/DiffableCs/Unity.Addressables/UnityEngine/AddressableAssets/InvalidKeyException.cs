namespace UnityEngine.AddressableAssets;

public class InvalidKeyException : Exception
{
	private const string BaseInvalidKeyMessageFormat = "{0}, Key={1}, Type={2}"; //Field offset: 0x0
	[CompilerGenerated]
	private object <Key>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private Type <Type>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private readonly Nullable<MergeMode> <MergeMode>k__BackingField; //Field offset: 0xA0
	private AddressablesImpl m_Addressables; //Field offset: 0xA8

	public private object Key
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public Nullable<MergeMode> MergeMode
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public virtual string Message
	{
		 get { } //Length: 1808
	}

	public private Type Type
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public InvalidKeyException(string message) { }

	protected InvalidKeyException(SerializationInfo message, StreamingContext context) { }

	public InvalidKeyException(string message, Exception innerException) { }

	public InvalidKeyException() { }

	internal InvalidKeyException(object key, Type type, MergeMode mergeMode, AddressablesImpl addr) { }

	public InvalidKeyException(object key) { }

	public InvalidKeyException(object key, Type type) { }

	internal InvalidKeyException(object key, Type type, AddressablesImpl addr) { }

	public InvalidKeyException(object key, Type type, MergeMode mergeMode) { }

	[CompilerGenerated]
	public object get_Key() { }

	[CompilerGenerated]
	public Nullable<MergeMode> get_MergeMode() { }

	public virtual string get_Message() { }

	[CompilerGenerated]
	public Type get_Type() { }

	private string GetCSVString(IEnumerable<String> enumerator, string prefixSingle, string prefixPlural) { }

	private string GetMessageforMergeKeys(List<String> keys) { }

	private string GetMessageForSingleKey(string keyString) { }

	private string GetMultipleAssignableTypesMessage(string keyString, HashSet<Type> typesAvailableForKey) { }

	private string GetNotFoundMessage(string keyString) { }

	private string GetTypeNotAssignableMessage(string keyString, HashSet<Type> typesAvailableForKey) { }

	private HashSet<Type> GetTypesForKey(string keyString) { }

	private bool GetTypeToKeys(string key, Dictionary<Type, List`1<String>> typeToKeys) { }

	[CompilerGenerated]
	private void set_Key(object value) { }

	[CompilerGenerated]
	private void set_Type(Type value) { }

}

