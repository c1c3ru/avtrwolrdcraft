namespace System.Runtime.Serialization.Formatters.Binary;

[DefaultMember("Item")]
internal sealed class IntSizedArray : ICloneable
{
	internal Int32[] objects; //Field offset: 0x10
	internal Int32[] negObjects; //Field offset: 0x18

	internal int Item
	{
		internal get { } //Length: 120
		internal set { } //Length: 184
	}

	public IntSizedArray() { }

	private IntSizedArray(IntSizedArray sizedArray) { }

	public override object Clone() { }

	internal int get_Item(int index) { }

	internal void IncreaseCapacity(int index) { }

	internal void set_Item(int index, int value) { }

}

