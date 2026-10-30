namespace Unity.Collections;

[BurstCompatible]
[BurstCompatible]
[BurstCompatible]
[BurstCompile]
public static class xxHash3
{
	public static class Hash128Long_00000726$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0
		private static IntPtr DeferredCompilation; //Field offset: 0x8

		private static Hash128Long_00000726$BurstDirectCall() { }

		public static void Constructor() { }

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static void Initialize() { }

		public static void Invoke(Byte* input, Byte* dest, long length, Byte* secret, out uint4 result) { }

	}

	public sealed class Hash128Long_00000726$PostfixBurstDelegate : MulticastDelegate
	{

		public Hash128Long_00000726$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(Byte* input, Byte* dest, long length, Byte* secret, out uint4 result, AsyncCallback unnamed_param_5, object unnamed_param_6) { }

		public override void EndInvoke(IAsyncResult unnamed_param_0) { }

		public override void Invoke(Byte* input, Byte* dest, long length, Byte* secret, out uint4 result) { }

	}

	public static class Hash64Long_0000071F$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0
		private static IntPtr DeferredCompilation; //Field offset: 0x8

		private static Hash64Long_0000071F$BurstDirectCall() { }

		public static void Constructor() { }

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static void Initialize() { }

		public static ulong Invoke(Byte* input, Byte* dest, long length, Byte* secret) { }

	}

	public sealed class Hash64Long_0000071F$PostfixBurstDelegate : MulticastDelegate
	{

		public Hash64Long_0000071F$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(Byte* input, Byte* dest, long length, Byte* secret, AsyncCallback unnamed_param_4, object unnamed_param_5) { }

		public override ulong EndInvoke(IAsyncResult unnamed_param_0) { }

		public override ulong Invoke(Byte* input, Byte* dest, long length, Byte* secret) { }

	}

	[BurstCompatible]
	internal struct StreamingState
	{
		private struct StreamingStateData
		{
			public ulong Acc; //Field offset: 0x0
			public byte Buffer; //Field offset: 0x40
			public int IsHash64; //Field offset: 0x140
			public int BufferedSize; //Field offset: 0x144
			public int NbStripesSoFar; //Field offset: 0x148
			public long TotalLength; //Field offset: 0x150
			public ulong Seed; //Field offset: 0x158
			public byte SecretKey; //Field offset: 0x160
			public byte _PadEnd; //Field offset: 0x21C

		}

		private static readonly int SECRET_LIMIT; //Field offset: 0x0
		private static readonly int NB_STRIPES_PER_BLOCK; //Field offset: 0x4
		private static readonly int INTERNAL_BUFFER_SIZE; //Field offset: 0x8
		private static readonly int INTERNAL_BUFFER_STRIPES; //Field offset: 0xC
		private StreamingStateData State; //Field offset: 0x0

		private UInt64* Acc
		{
			[DebuggerStepThrough]
			private get { } //Length: 4
		}

		private Byte* Buffer
		{
			[DebuggerStepThrough]
			private get { } //Length: 8
		}

		private Byte* SecretKey
		{
			[DebuggerStepThrough]
			private get { } //Length: 8
		}

		private static StreamingState() { }

		public StreamingState(bool isHash64, ulong seed = 0) { }

		[BurstDiscard]
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckKeySize(int isHash64) { }

		private void ConsumeStripes(UInt64* acc, ref int nbStripesSoFar, Byte* input, long totalStripes, Byte* secret, int isHash64) { }

		public uint4 DigestHash128() { }

		public uint2 DigestHash64() { }

		private void DigestLong(UInt64* acc, Byte* secret, int isHash64) { }

		[DebuggerStepThrough]
		private UInt64* get_Acc() { }

		[DebuggerStepThrough]
		private Byte* get_Buffer() { }

		[DebuggerStepThrough]
		private Byte* get_SecretKey() { }

		public void Reset(bool isHash64, ulong seed = 0) { }

		public void Update(Void* input, int length) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void Update(in T input) { }

	}

	private struct ulong2
	{
		public ulong x; //Field offset: 0x0
		public ulong y; //Field offset: 0x8

		public ulong2(ulong x, ulong y) { }

	}

	private const int STRIPE_LEN = 64; //Field offset: 0x0
	private const int MIDSIZE_STARTOFFSET = 3; //Field offset: 0x0
	private const int MIDSIZE_MAX = 240; //Field offset: 0x0
	private const ulong PRIME64_5 = 2870177450012600261; //Field offset: 0x0
	private const ulong PRIME64_4 = 9650029242287828579; //Field offset: 0x0
	private const ulong PRIME64_3 = 1609587929392839161; //Field offset: 0x0
	private const ulong PRIME64_2 = 14029467366897019727; //Field offset: 0x0
	private const ulong PRIME64_1 = 11400714785074694791; //Field offset: 0x0
	private const uint PRIME32_5 = 374761393; //Field offset: 0x0
	private const int MIDSIZE_LASTOFFSET = 17; //Field offset: 0x0
	private const uint PRIME32_3 = 3266489917; //Field offset: 0x0
	private const uint PRIME32_1 = 2654435761; //Field offset: 0x0
	private const int BLOCK_LEN = 1024; //Field offset: 0x0
	private const int NB_ROUNDS = 16; //Field offset: 0x0
	private const int SECRET_LASTACC_START = 7; //Field offset: 0x0
	private const int SECRET_KEY_MIN_SIZE = 136; //Field offset: 0x0
	private const int SECRET_KEY_SIZE = 192; //Field offset: 0x0
	private const int SECRET_CONSUME_RATE = 8; //Field offset: 0x0
	private const int ACC_NB = 8; //Field offset: 0x0
	private const uint PRIME32_2 = 2246822519; //Field offset: 0x0
	private const int SECRET_MERGEACCS_START = 11; //Field offset: 0x0

	private static ulong Avalanche(ulong h64) { }

	private static ulong AvalancheH64(ulong h64) { }

	internal static void Avx2Accumulate(UInt64* acc, Byte* input, Byte* dest, Byte* secret, long nbStripes, int isHash64) { }

	internal static void Avx2Accumulate512(UInt64* acc, Byte* input, Byte* dest, Byte* secret) { }

	internal static void Avx2HashLongInternalLoop(UInt64* acc, Byte* input, Byte* dest, long length, Byte* secret, int isHash64) { }

	internal static void Avx2ScrambleAcc(UInt64* acc, Byte* secret) { }

	internal static void DefaultAccumulate(UInt64* acc, Byte* input, Byte* dest, Byte* secret, long nbStripes, int isHash64) { }

	internal static void DefaultAccumulate512(UInt64* acc, Byte* input, Byte* dest, Byte* secret, int isHash64) { }

	private static void DefaultHashLongInternalLoop(UInt64* acc, Byte* input, Byte* dest, long length, Byte* secret, int isHash64) { }

	internal static void DefaultScrambleAcc(UInt64* acc, Byte* secret) { }

	internal static void EncodeSecretKey(Byte* dst, Byte* secret, ulong seed) { }

	public static uint4 Hash128(Void* input, Void* destination, long length, ulong seed) { }

	public static uint4 Hash128(Void* input, long length, ulong seed) { }

	public static uint4 Hash128(Void* input, Void* destination, long length) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static uint4 Hash128(in T input) { }

	public static uint4 Hash128(Void* input, long length) { }

	internal static void Hash128Internal(Byte* input, Byte* dest, long length, Byte* secret, ulong seed, out uint4 result) { }

	private static void Hash128Len0To16(Byte* input, long length, Byte* secret, ulong seed, out uint4 result) { }

	private static void Hash128Len129To240(Byte* input, long length, Byte* secret, ulong seed, out uint4 result) { }

	private static void Hash128Len17To128(Byte* input, long length, Byte* secret, ulong seed, out uint4 result) { }

	private static void Hash128Len1To3(Byte* input, long length, Byte* secret, ulong seed, out uint4 result) { }

	private static void Hash128Len4To8(Byte* input, long len, Byte* secret, ulong seed, out uint4 result) { }

	private static void Hash128Len9To16(Byte* input, long len, Byte* secret, ulong seed, out uint4 result) { }

	[BurstCompile]
	private static void Hash128Long(Byte* input, Byte* dest, long length, Byte* secret, out uint4 result) { }

	[BurstCompile]
	internal static void Hash128Long$BurstManaged(Byte* input, Byte* dest, long length, Byte* secret, out uint4 result) { }

	public static uint2 Hash64(Void* input, long length) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static uint2 Hash64(in T input) { }

	public static uint2 Hash64(Void* input, long length, ulong seed) { }

	internal static ulong Hash64Internal(Byte* input, Byte* dest, long length, Byte* secret, ulong seed) { }

	private static ulong Hash64Len0To16(Byte* input, long length, Byte* secret, ulong seed) { }

	private static ulong Hash64Len129To240(Byte* input, long length, Byte* secret, ulong seed) { }

	private static ulong Hash64Len17To128(Byte* input, long length, Byte* secret, ulong seed) { }

	private static ulong Hash64Len1To3(Byte* input, long len, Byte* secret, ulong seed) { }

	private static ulong Hash64Len4To8(Byte* input, long length, Byte* secret, ulong seed) { }

	private static ulong Hash64Len9To16(Byte* input, long length, Byte* secret, ulong seed) { }

	[BurstCompile]
	private static ulong Hash64Long(Byte* input, Byte* dest, long length, Byte* secret) { }

	[BurstCompile]
	internal static ulong Hash64Long$BurstManaged(Byte* input, Byte* dest, long length, Byte* secret) { }

	internal static ulong MergeAcc(UInt64* acc, Byte* secret, ulong start) { }

	private static ulong Mix16(Byte* input, Byte* secret, ulong seed) { }

	private static ulong Mix2Acc(ulong acc0, ulong acc1, Byte* secret) { }

	private static ulong2 Mix32(ulong2 acc, Byte* input_1, Byte* input_2, Byte* secret, ulong seed) { }

	private static ulong Mul128Fold64(ulong lhs, ulong rhs) { }

	private static ulong Mul32To64(uint x, uint y) { }

	private static uint Read32LE(Void* addr) { }

	private static void Read32LE(Void* addr, uint value) { }

	private static ulong Read64LE(Void* addr) { }

	private static uint RotL32(uint x, int r) { }

	private static ulong RotL64(ulong x, int r) { }

	private static ulong rrmxmx(ulong h64, ulong length) { }

	private static uint Swap32(uint x) { }

	private static ulong Swap64(ulong x) { }

	internal static uint2 ToUint2(ulong u) { }

	internal static uint4 ToUint4(ulong ul0, ulong ul1) { }

	private static void Write64LE(Void* addr, ulong value) { }

	private static ulong XorShift64(ulong v64, int shift) { }

}

