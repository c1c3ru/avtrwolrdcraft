namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct bool2x3 : IEquatable<bool2x3>
{
	public bool2 c0; //Field offset: 0x0
	public bool2 c1; //Field offset: 0x2
	public bool2 c2; //Field offset: 0x4

	public bool2 Item
	{
		 get { } //Length: 8
	}

	public bool2x3(bool2 c0, bool2 c1, bool2 c2) { }

	public bool2x3(bool m00, bool m01, bool m02, bool m10, bool m11, bool m12) { }

	public bool2x3(bool v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(bool2x3 rhs) { }

	public bool2 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static bool2x3 op_BitwiseAnd(bool lhs, bool2x3 rhs) { }

	public static bool2x3 op_BitwiseAnd(bool2x3 lhs, bool2x3 rhs) { }

	public static bool2x3 op_BitwiseAnd(bool2x3 lhs, bool rhs) { }

	public static bool2x3 op_BitwiseOr(bool2x3 lhs, bool2x3 rhs) { }

	public static bool2x3 op_BitwiseOr(bool2x3 lhs, bool rhs) { }

	public static bool2x3 op_BitwiseOr(bool lhs, bool2x3 rhs) { }

	public static bool2x3 op_Equality(bool lhs, bool2x3 rhs) { }

	public static bool2x3 op_Equality(bool2x3 lhs, bool rhs) { }

	public static bool2x3 op_Equality(bool2x3 lhs, bool2x3 rhs) { }

	public static bool2x3 op_ExclusiveOr(bool2x3 lhs, bool2x3 rhs) { }

	public static bool2x3 op_ExclusiveOr(bool2x3 lhs, bool rhs) { }

	public static bool2x3 op_ExclusiveOr(bool lhs, bool2x3 rhs) { }

	public static bool2x3 op_Implicit(bool v) { }

	public static bool2x3 op_Inequality(bool2x3 lhs, bool rhs) { }

	public static bool2x3 op_Inequality(bool2x3 lhs, bool2x3 rhs) { }

	public static bool2x3 op_Inequality(bool lhs, bool2x3 rhs) { }

	public static bool2x3 op_LogicalNot(bool2x3 val) { }

	public virtual string ToString() { }

}

