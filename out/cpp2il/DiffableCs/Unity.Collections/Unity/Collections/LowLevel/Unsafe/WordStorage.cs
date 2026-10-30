namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerTypeProxy(typeof(WordStorageDebugView))]
[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
public struct WordStorage
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static EventHandler <>9__13_0; //Field offset: 0x8
		public static EventHandler <>9__13_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <Initialize>b__13_0(object _, EventArgs __) { }

		internal void <Initialize>b__13_1(object _, EventArgs __) { }

	}

	private struct Entry
	{
		public int offset; //Field offset: 0x0
		public int length; //Field offset: 0x4

	}

	private const int kMaxEntries = 16384; //Field offset: 0x0
	private const int kMaxChars = 2097152; //Field offset: 0x0
	public const int kMaxCharsPerEntry = 4096; //Field offset: 0x0
	private NativeArray<Byte> buffer; //Field offset: 0x0
	private NativeArray<Entry> entry; //Field offset: 0x10
	private NativeMultiHashMap<Int32, Int32> hash; //Field offset: 0x20
	private int chars; //Field offset: 0x30
	private int entries; //Field offset: 0x34

	public int Entries
	{
		 get { } //Length: 8
	}

	[NotBurstCompatible]
	public static WordStorage Instance
	{
		 get { } //Length: 88
	}

	[NotBurstCompatible]
	public static void Clear() { }

	public bool Contains(ref T value) { }

	[NotBurstCompatible]
	public bool Contains(string value) { }

	public int get_Entries() { }

	public static WordStorage get_Instance() { }

	public void GetFixedString(int index, ref T temp) { }

	public int GetIndexFromHashAndFixedString(int h, ref T temp) { }

	public int GetOrCreateIndex(ref T value) { }

	[NotBurstCompatible]
	public static void Initialize() { }

	[NotBurstCompatible]
	public static void Setup() { }

	[NotBurstCompatible]
	public static void Shutdown() { }

}

