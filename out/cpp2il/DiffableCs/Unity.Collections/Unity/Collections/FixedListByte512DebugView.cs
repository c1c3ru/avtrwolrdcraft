namespace Unity.Collections;

[Obsolete("FixedListByte512DebugView is deprecated. (UnityUpgradable) -> FixedList512BytesDebugView<byte>", True)]
internal sealed class FixedListByte512DebugView
{
	private FixedList512Bytes<Byte> m_List; //Field offset: 0x10

	public Byte[] Items
	{
		 get { } //Length: 72
	}

	public FixedListByte512DebugView(FixedList512Bytes<Byte> list) { }

	public Byte[] get_Items() { }

}

