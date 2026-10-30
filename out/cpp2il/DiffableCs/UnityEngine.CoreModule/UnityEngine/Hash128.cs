namespace UnityEngine;

[NativeHeader("Runtime/Export/Hashing/Hash128.bindings.h")]
[NativeHeader("Runtime/Utilities/Hash128.h")]
[UsedByNativeCode]
public struct Hash128 : IComparable, IComparable<Hash128>, IEquatable<Hash128>
{
	internal ulong u64_0; //Field offset: 0x0
	internal ulong u64_1; //Field offset: 0x8

	public bool isValid
	{
		 get { } //Length: 32
	}

	public Hash128(ulong u64_0, ulong u64_1) { }

	public override int CompareTo(object obj) { }

	public override int CompareTo(Hash128 rhs) { }

	public static Hash128 Compute(string data) { }

	[FreeFunction("ComputeHash128FromScriptString", IsThreadSafe = True)]
	private static void ComputeFromString(string data, ref Hash128 hash) { }

	public override bool Equals(Hash128 obj) { }

	public virtual bool Equals(object obj) { }

	public bool get_isValid() { }

	public virtual int GetHashCode() { }

	[FreeFunction("Hash128ToString", IsThreadSafe = True)]
	private static string Hash128ToStringImpl(Hash128 hash) { }

	private static string Hash128ToStringImpl_Injected(ref Hash128 hash) { }

	public static bool op_Equality(Hash128 hash1, Hash128 hash2) { }

	public static bool op_GreaterThan(Hash128 x, Hash128 y) { }

	public static bool op_Inequality(Hash128 hash1, Hash128 hash2) { }

	public static bool op_LessThan(Hash128 x, Hash128 y) { }

	[FreeFunction("StringToHash128", IsThreadSafe = True)]
	public static Hash128 Parse(string hashString) { }

	private static void Parse_Injected(string hashString, out Hash128 ret) { }

	public virtual string ToString() { }

}

