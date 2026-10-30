namespace Game.Level;

public class ValueWrapper
{
	internal enum ValueType
	{
		Int = 0,
		Float = 1,
		Bool = 2,
		String = 3,
		Object = 4,
	}

	public int IntValue; //Field offset: 0x10
	public float FloatValue; //Field offset: 0x14
	public bool BoolValue; //Field offset: 0x18
	public string StringValue; //Field offset: 0x20
	public object ObjectValue; //Field offset: 0x28
	public ValueType Type; //Field offset: 0x30

	public ValueWrapper() { }

	public object GetValue() { }

}

