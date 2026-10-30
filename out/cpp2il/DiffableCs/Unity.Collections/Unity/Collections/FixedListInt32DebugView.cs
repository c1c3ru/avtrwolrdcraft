namespace Unity.Collections;

[Obsolete("FixedListInt32DebugView is deprecated. (UnityUpgradable) -> FixedList32BytesDebugView<int>", True)]
internal sealed class FixedListInt32DebugView
{
	private FixedList32Bytes<Int32> m_List; //Field offset: 0x10

	public Int32[] Items
	{
		 get { } //Length: 72
	}

	public FixedListInt32DebugView(FixedList32Bytes<Int32> list) { }

	public Int32[] get_Items() { }

}

