namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct bool2x4 : IEquatable<bool2x4>
{
	public bool2 c0; //Field offset: 0x0
	public bool2 c1; //Field offset: 0x2
	public bool2 c2; //Field offset: 0x4
	public bool2 c3; //Field offset: 0x6

	public bool2 Item
	{
		 get { } //Length: 8
	}

	public bool2x4(bool2 c0, bool2 c1, bool2 c2, bool2 c3) { }

	public bool2x4(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13) { }

	public bool2x4(bool v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(bool2x4 rhs) { }

	public bool2 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static bool2x4 op_BitwiseAnd(bool lhs, bool2x4 rhs) { }

	public static bool2x4 op_BitwiseAnd(bool2x4 lhs, bool2x4 rhs) { }

	public static bool2x4 op_BitwiseAnd(bool2x4 lhs, bool rhs) { }

	public static bool2x4 op_BitwiseOr(bool2x4 lhs, bool2x4 rhs) { }

	public static bool2x4 op_BitwiseOr(bool2x4 lhs, bool rhs) { }

	public static bool2x4 op_BitwiseOr(bool lhs, bool2x4 rhs) { }

	public static bool2x4 op_Equality(bool lhs, bool2x4 rhs) { }

	public static bool2x4 op_Equality(bool2x4 lhs, bool rhs) { }

	public static bool2x4 op_Equality(bool2x4 lhs, bool2x4 rhs) { }

	public static bool2x4 op_ExclusiveOr(bool2x4 lhs, bool2x4 rhs) { }

	public static bool2x4 op_ExclusiveOr(bool2x4 lhs, bool rhs) { }

	public static bool2x4 op_ExclusiveOr(bool lhs, bool2x4 rhs) { }

	public static bool2x4 op_Implicit(bool v) { }

	public static bool2x4 op_Inequality(bool2x4 lhs, bool rhs) { }

	public static bool2x4 op_Inequality(bool2x4 lhs, bool2x4 rhs) { }

	public static bool2x4 op_Inequality(bool lhs, bool2x4 rhs) { }

	public static bool2x4 op_LogicalNot(bool2x4 val) { }

	public virtual string ToString() { }

}

