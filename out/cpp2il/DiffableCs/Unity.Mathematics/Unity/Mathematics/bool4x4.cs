namespace Unity.Mathematics;

[DefaultMember("Item")]
[Il2CppEagerStaticClassConstruction]
public struct bool4x4 : IEquatable<bool4x4>
{
	public bool4 c0; //Field offset: 0x0
	public bool4 c1; //Field offset: 0x4
	public bool4 c2; //Field offset: 0x8
	public bool4 c3; //Field offset: 0xC

	public bool4 Item
	{
		 get { } //Length: 8
	}

	public bool4x4(bool4 c0, bool4 c1, bool4 c2, bool4 c3) { }

	public bool4x4(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13, bool m20, bool m21, bool m22, bool m23, bool m30, bool m31, bool m32, bool m33) { }

	public bool4x4(bool v) { }

	public virtual bool Equals(object o) { }

	public override bool Equals(bool4x4 rhs) { }

	public bool4 get_Item(int index) { }

	public virtual int GetHashCode() { }

	public static bool4x4 op_BitwiseAnd(bool lhs, bool4x4 rhs) { }

	public static bool4x4 op_BitwiseAnd(bool4x4 lhs, bool4x4 rhs) { }

	public static bool4x4 op_BitwiseAnd(bool4x4 lhs, bool rhs) { }

	public static bool4x4 op_BitwiseOr(bool4x4 lhs, bool4x4 rhs) { }

	public static bool4x4 op_BitwiseOr(bool4x4 lhs, bool rhs) { }

	public static bool4x4 op_BitwiseOr(bool lhs, bool4x4 rhs) { }

	public static bool4x4 op_Equality(bool lhs, bool4x4 rhs) { }

	public static bool4x4 op_Equality(bool4x4 lhs, bool rhs) { }

	public static bool4x4 op_Equality(bool4x4 lhs, bool4x4 rhs) { }

	public static bool4x4 op_ExclusiveOr(bool4x4 lhs, bool4x4 rhs) { }

	public static bool4x4 op_ExclusiveOr(bool4x4 lhs, bool rhs) { }

	public static bool4x4 op_ExclusiveOr(bool lhs, bool4x4 rhs) { }

	public static bool4x4 op_Implicit(bool v) { }

	public static bool4x4 op_Inequality(bool4x4 lhs, bool rhs) { }

	public static bool4x4 op_Inequality(bool4x4 lhs, bool4x4 rhs) { }

	public static bool4x4 op_Inequality(bool lhs, bool4x4 rhs) { }

	public static bool4x4 op_LogicalNot(bool4x4 val) { }

	public virtual string ToString() { }

}

