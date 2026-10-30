namespace Unity.Collections;

[Obsolete("FixedListByte32DebugView is deprecated. (UnityUpgradable) -> FixedList32BytesDebugView<byte>", True)]
internal sealed class FixedListByte32DebugView
{
	private FixedList32Bytes<Byte> m_List; //Field offset: 0x10

	public Byte[] Items
	{
		 get { } //Length: 72
	}

	public FixedListByte32DebugView(FixedList32Bytes<Byte> list) { }

	public Byte[] get_Items() { }

}

