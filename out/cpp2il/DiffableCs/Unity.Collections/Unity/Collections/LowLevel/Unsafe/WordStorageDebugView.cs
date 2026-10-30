namespace Unity.Collections.LowLevel.Unsafe;

[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
internal sealed class WordStorageDebugView
{
	private WordStorage m_wordStorage; //Field offset: 0x10

	public FixedString128Bytes[] Table
	{
		 get { } //Length: 208
	}

	public WordStorageDebugView(WordStorage wordStorage) { }

	public FixedString128Bytes[] get_Table() { }

}

