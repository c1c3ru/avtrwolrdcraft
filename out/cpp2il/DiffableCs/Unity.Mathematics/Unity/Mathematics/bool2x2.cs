namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct bool2x2 : IEquatable<bool2x2>
{
	public bool2 c0; //Field offset: 0x0
	public bool2 c1; //Field offset: 0x2

	public bool2 Item
	{
		 get { } //Length: 8
	}

	public bool2x2(bool2 c0, bool2 c1) { }

	public bool2x2(bool m00, bool m01, bool m10, bool m11) { }

	public bool2x2(bool v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(bool2x2 rhs) { }

	public bool2 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static bool2x2 op_BitwiseAnd(bool lhs, bool2x2 rhs) { }

	public static bool2x2 op_BitwiseAnd(bool2x2 lhs, bool2x2 rhs) { }

	public static bool2x2 op_BitwiseAnd(bool2x2 lhs, bool rhs) { }

	public static bool2x2 op_BitwiseOr(bool2x2 lhs, bool2x2 rhs) { }

	public static bool2x2 op_BitwiseOr(bool2x2 lhs, bool rhs) { }

	public static bool2x2 op_BitwiseOr(bool lhs, bool2x2 rhs) { }

	public static bool2x2 op_Equality(bool lhs, bool2x2 rhs) { }

	public static bool2x2 op_Equality(bool2x2 lhs, bool rhs) { }

	public static bool2x2 op_Equality(bool2x2 lhs, bool2x2 rhs) { }

	public static bool2x2 op_ExclusiveOr(bool2x2 lhs, bool2x2 rhs) { }

	public static bool2x2 op_ExclusiveOr(bool2x2 lhs, bool rhs) { }

	public static bool2x2 op_ExclusiveOr(bool lhs, bool2x2 rhs) { }

	public static bool2x2 op_Implicit(bool v) { }

	public static bool2x2 op_Inequality(bool2x2 lhs, bool rhs) { }

	public static bool2x2 op_Inequality(bool2x2 lhs, bool2x2 rhs) { }

	public static bool2x2 op_Inequality(bool lhs, bool2x2 rhs) { }

	public static bool2x2 op_LogicalNot(bool2x2 val) { }

	public virtual string ToString() { }

}

