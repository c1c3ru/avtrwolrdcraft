namespace Unity.Collections;

[Obsolete("FixedListByte4096DebugView is deprecated. (UnityUpgradable) -> FixedList4096BytesDebugView<byte>", True)]
internal sealed class FixedListByte4096DebugView
{
	private FixedList4096Bytes<Byte> m_List; //Field offset: 0x10

	public Byte[] Items
	{
		 get { } //Length: 72
	}

	public FixedListByte4096DebugView(FixedList4096Bytes<Byte> list) { }

	public Byte[] get_Items() { }

}

