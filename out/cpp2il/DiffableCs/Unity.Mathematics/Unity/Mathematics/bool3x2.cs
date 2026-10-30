namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct bool3x2 : IEquatable<bool3x2>
{
	public bool3 c0; //Field offset: 0x0
	public bool3 c1; //Field offset: 0x3

	public bool3 Item
	{
		 get { } //Length: 16
	}

	public bool3x2(bool3 c0, bool3 c1) { }

	public bool3x2(bool m00, bool m01, bool m10, bool m11, bool m20, bool m21) { }

	public bool3x2(bool v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(bool3x2 rhs) { }

	public bool3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static bool3x2 op_BitwiseAnd(bool lhs, bool3x2 rhs) { }

	public static bool3x2 op_BitwiseAnd(bool3x2 lhs, bool3x2 rhs) { }

	public static bool3x2 op_BitwiseAnd(bool3x2 lhs, bool rhs) { }

	public static bool3x2 op_BitwiseOr(bool3x2 lhs, bool3x2 rhs) { }

	public static bool3x2 op_BitwiseOr(bool3x2 lhs, bool rhs) { }

	public static bool3x2 op_BitwiseOr(bool lhs, bool3x2 rhs) { }

	public static bool3x2 op_Equality(bool lhs, bool3x2 rhs) { }

	public static bool3x2 op_Equality(bool3x2 lhs, bool rhs) { }

	public static bool3x2 op_Equality(bool3x2 lhs, bool3x2 rhs) { }

	public static bool3x2 op_ExclusiveOr(bool3x2 lhs, bool3x2 rhs) { }

	public static bool3x2 op_ExclusiveOr(bool3x2 lhs, bool rhs) { }

	public static bool3x2 op_ExclusiveOr(bool lhs, bool3x2 rhs) { }

	public static bool3x2 op_Implicit(bool v) { }

	public static bool3x2 op_Inequality(bool3x2 lhs, bool rhs) { }

	public static bool3x2 op_Inequality(bool3x2 lhs, bool3x2 rhs) { }

	public static bool3x2 op_Inequality(bool lhs, bool3x2 rhs) { }

	public static bool3x2 op_LogicalNot(bool3x2 val) { }

	public virtual string ToString() { }

}

