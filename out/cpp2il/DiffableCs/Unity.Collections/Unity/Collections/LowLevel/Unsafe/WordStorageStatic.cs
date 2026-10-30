namespace Unity.Collections.LowLevel.Unsafe;

[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
internal sealed class WordStorageStatic
{
	internal struct Thing
	{
		public WordStorage Data; //Field offset: 0x0

	}

	public static Thing Ref; //Field offset: 0x0

	private static WordStorageStatic() { }

	private WordStorageStatic() { }

}

