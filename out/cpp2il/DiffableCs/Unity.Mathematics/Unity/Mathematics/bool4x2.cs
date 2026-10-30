namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct bool4x2 : IEquatable<bool4x2>
{
	public bool4 c0; //Field offset: 0x0
	public bool4 c1; //Field offset: 0x4

	public bool4 Item
	{
		 get { } //Length: 8
	}

	public bool4x2(bool4 c0, bool4 c1) { }

	public bool4x2(bool m00, bool m01, bool m10, bool m11, bool m20, bool m21, bool m30, bool m31) { }

	public bool4x2(bool v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(bool4x2 rhs) { }

	public bool4 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static bool4x2 op_BitwiseAnd(bool lhs, bool4x2 rhs) { }

	public static bool4x2 op_BitwiseAnd(bool4x2 lhs, bool4x2 rhs) { }

	public static bool4x2 op_BitwiseAnd(bool4x2 lhs, bool rhs) { }

	public static bool4x2 op_BitwiseOr(bool4x2 lhs, bool4x2 rhs) { }

	public static bool4x2 op_BitwiseOr(bool4x2 lhs, bool rhs) { }

	public static bool4x2 op_BitwiseOr(bool lhs, bool4x2 rhs) { }

	public static bool4x2 op_Equality(bool lhs, bool4x2 rhs) { }

	public static bool4x2 op_Equality(bool4x2 lhs, bool rhs) { }

	public static bool4x2 op_Equality(bool4x2 lhs, bool4x2 rhs) { }

	public static bool4x2 op_ExclusiveOr(bool4x2 lhs, bool4x2 rhs) { }

	public static bool4x2 op_ExclusiveOr(bool4x2 lhs, bool rhs) { }

	public static bool4x2 op_ExclusiveOr(bool lhs, bool4x2 rhs) { }

	public static bool4x2 op_Implicit(bool v) { }

	public static bool4x2 op_Inequality(bool4x2 lhs, bool rhs) { }

	public static bool4x2 op_Inequality(bool4x2 lhs, bool4x2 rhs) { }

	public static bool4x2 op_Inequality(bool lhs, bool4x2 rhs) { }

	public static bool4x2 op_LogicalNot(bool4x2 val) { }

	public virtual string ToString() { }

}

