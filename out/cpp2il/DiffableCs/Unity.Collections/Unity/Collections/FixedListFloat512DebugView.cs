namespace Unity.Collections;

[Obsolete("FixedListFloat512DebugView is deprecated. (UnityUpgradable) -> FixedList512BytesDebugView<float>", True)]
internal sealed class FixedListFloat512DebugView
{
	private FixedList512Bytes<Single> m_List; //Field offset: 0x10

	public Single[] Items
	{
		 get { } //Length: 72
	}

	public FixedListFloat512DebugView(FixedList512Bytes<Single> list) { }

	public Single[] get_Items() { }

}

