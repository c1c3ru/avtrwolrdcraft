namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct bool3x4 : IEquatable<bool3x4>
{
	public bool3 c0; //Field offset: 0x0
	public bool3 c1; //Field offset: 0x3
	public bool3 c2; //Field offset: 0x6
	public bool3 c3; //Field offset: 0x9

	public bool3 Item
	{
		 get { } //Length: 16
	}

	public bool3x4(bool3 c0, bool3 c1, bool3 c2, bool3 c3) { }

	public bool3x4(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13, bool m20, bool m21, bool m22, bool m23) { }

	public bool3x4(bool v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(bool3x4 rhs) { }

	public bool3 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static bool3x4 op_BitwiseAnd(bool lhs, bool3x4 rhs) { }

	public static bool3x4 op_BitwiseAnd(bool3x4 lhs, bool3x4 rhs) { }

	public static bool3x4 op_BitwiseAnd(bool3x4 lhs, bool rhs) { }

	public static bool3x4 op_BitwiseOr(bool3x4 lhs, bool3x4 rhs) { }

	public static bool3x4 op_BitwiseOr(bool3x4 lhs, bool rhs) { }

	public static bool3x4 op_BitwiseOr(bool lhs, bool3x4 rhs) { }

	public static bool3x4 op_Equality(bool lhs, bool3x4 rhs) { }

	public static bool3x4 op_Equality(bool3x4 lhs, bool rhs) { }

	public static bool3x4 op_Equality(bool3x4 lhs, bool3x4 rhs) { }

	public static bool3x4 op_ExclusiveOr(bool3x4 lhs, bool3x4 rhs) { }

	public static bool3x4 op_ExclusiveOr(bool3x4 lhs, bool rhs) { }

	public static bool3x4 op_ExclusiveOr(bool lhs, bool3x4 rhs) { }

	public static bool3x4 op_Implicit(bool v) { }

	public static bool3x4 op_Inequality(bool3x4 lhs, bool rhs) { }

	public static bool3x4 op_Inequality(bool3x4 lhs, bool3x4 rhs) { }

	public static bool3x4 op_Inequality(bool lhs, bool3x4 rhs) { }

	public static bool3x4 op_LogicalNot(bool3x4 val) { }

	public virtual string ToString() { }

}

