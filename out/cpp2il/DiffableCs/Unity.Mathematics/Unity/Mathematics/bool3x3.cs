namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct bool3x3 : IEquatable<bool3x3>
{
	public bool3 c0; //Field offset: 0x0
	public bool3 c1; //Field offset: 0x3
	public bool3 c2; //Field offset: 0x6

	public bool3 Item
	{
		 get { } //Length: 16
	}

	public bool3x3(bool3 c0, bool3 c1, bool3 c2) { }

	public bool3x3(bool m00, bool m01, bool m02, bool m10, bool m11, bool m12, bool m20, bool m21, bool m22) { }

	public bool3x3(bool v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(bool3x3 rhs) { }

	public bool3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static bool3x3 op_BitwiseAnd(bool lhs, bool3x3 rhs) { }

	public static bool3x3 op_BitwiseAnd(bool3x3 lhs, bool3x3 rhs) { }

	public static bool3x3 op_BitwiseAnd(bool3x3 lhs, bool rhs) { }

	public static bool3x3 op_BitwiseOr(bool3x3 lhs, bool3x3 rhs) { }

	public static bool3x3 op_BitwiseOr(bool3x3 lhs, bool rhs) { }

	public static bool3x3 op_BitwiseOr(bool lhs, bool3x3 rhs) { }

	public static bool3x3 op_Equality(bool lhs, bool3x3 rhs) { }

	public static bool3x3 op_Equality(bool3x3 lhs, bool rhs) { }

	public static bool3x3 op_Equality(bool3x3 lhs, bool3x3 rhs) { }

	public static bool3x3 op_ExclusiveOr(bool3x3 lhs, bool3x3 rhs) { }

	public static bool3x3 op_ExclusiveOr(bool3x3 lhs, bool rhs) { }

	public static bool3x3 op_ExclusiveOr(bool lhs, bool3x3 rhs) { }

	public static bool3x3 op_Implicit(bool v) { }

	public static bool3x3 op_Inequality(bool3x3 lhs, bool rhs) { }

	public static bool3x3 op_Inequality(bool3x3 lhs, bool3x3 rhs) { }

	public static bool3x3 op_Inequality(bool lhs, bool3x3 rhs) { }

	public static bool3x3 op_LogicalNot(bool3x3 val) { }

	public virtual string ToString() { }

}

