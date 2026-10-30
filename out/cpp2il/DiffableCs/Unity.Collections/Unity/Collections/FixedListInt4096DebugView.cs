namespace Unity.Collections;

[Obsolete("FixedListInt4096DebugView is deprecated. (UnityUpgradable) -> FixedList4096BytesDebugView<int>", True)]
internal sealed class FixedListInt4096DebugView
{
	private FixedList4096Bytes<Int32> m_List; //Field offset: 0x10

	public Int32[] Items
	{
		 get { } //Length: 72
	}

	public FixedListInt4096DebugView(FixedList4096Bytes<Int32> list) { }

	public Int32[] get_Items() { }

}

