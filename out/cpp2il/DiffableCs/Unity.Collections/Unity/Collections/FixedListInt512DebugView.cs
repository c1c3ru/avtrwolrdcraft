namespace Unity.Collections;

[Obsolete("FixedListInt512DebugView is deprecated. (UnityUpgradable) -> FixedList512BytesDebugView<int>", True)]
internal sealed class FixedListInt512DebugView
{
	private FixedList512Bytes<Int32> m_List; //Field offset: 0x10

	public Int32[] Items
	{
		 get { } //Length: 72
	}

	public FixedListInt512DebugView(FixedList512Bytes<Int32> list) { }

	public Int32[] get_Items() { }

}

