namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
[DebuggerDisplay("Key = {Key}, Value = {Value}")]
public struct KeyValue
{
	internal UnsafeHashMapData* m_Buffer; //Field offset: 0x0
	internal int m_Index; //Field offset: 0x0
	internal int m_Next; //Field offset: 0x0

	public TKey Key
	{
		 get { } //Length: 104
	}

	public static KeyValue<TKey, TValue> Null
	{
		 get { } //Length: 12
	}

	public TValue Value
	{
		 get { } //Length: 96
	}

	public TKey get_Key() { }

	public static KeyValue<TKey, TValue> get_Null() { }

	public TValue get_Value() { }

	public bool GetKeyValue(out TKey key, out TValue value) { }

}

