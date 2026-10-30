namespace ClipperLib;

internal struct Int128
{
	private long hi; //Field offset: 0x0
	private ulong lo; //Field offset: 0x8

	public Int128(long _lo) { }

	public Int128(long _hi, ulong _lo) { }

	public Int128(Int128 val) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

	public static Int128 Int128Mul(long lhs, long rhs) { }

	public bool IsNegative() { }

	public static Int128 op_Addition(Int128 lhs, Int128 rhs) { }

	public static bool op_Equality(Int128 val1, Int128 val2) { }

	public static double op_Explicit(Int128 val) { }

	public static bool op_GreaterThan(Int128 val1, Int128 val2) { }

	public static bool op_Inequality(Int128 val1, Int128 val2) { }

	public static bool op_LessThan(Int128 val1, Int128 val2) { }

	public static Int128 op_Subtraction(Int128 lhs, Int128 rhs) { }

	public static Int128 op_UnaryNegation(Int128 val) { }

}

