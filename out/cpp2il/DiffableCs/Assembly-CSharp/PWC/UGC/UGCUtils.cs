namespace PWC.UGC;

public static class UGCUtils
{
	[CompilerGenerated]
	private struct <>c__DisplayClass4_0
	{
		public float cos; //Field offset: 0x0
		public float sin; //Field offset: 0x4

	}

	private class Matrix2x2
	{
		public Vector2 iColumn; //Field offset: 0x10
		public Vector2 jColumn; //Field offset: 0x18

		public Matrix2x2() { }

	}

	private static Matrix2x2 _skewMatrix; //Field offset: 0x0
	private static Matrix2x2 _inverseSkewMatrix; //Field offset: 0x8

	[CompilerGenerated]
	internal static Vector2 <GetSkewMatrix>g__MultiplyRotate|4_0(Vector2 point, ref <>c__DisplayClass4_0 unnamed_param_1) { }

	public static void ApplySkewToCShape(CShape cShape) { }

	public static void GetInverseSkewMatrix(out Vector2 matrixI, out Vector2 matrixJ) { }

	public static ValueTuple<Vector2, Vector2> GetMinMaxInProjected2D(Vector2[] worldPoints, float zValue) { }

	public static ValueTuple<Vector2, Vector2> GetMinMaxInProjected2D(Vector2 minWorld, Vector2 maxWorld, float zValue) { }

	public static void GetSkewMatrix(out Vector2 matrixI, out Vector2 matrixJ) { }

	private static void InverseMatrix(ref Vector2 matrixI, ref Vector2 matrixJ) { }

	public static Vector2 MultiplyMatrixWithPoint(in Vector2 matrixI, in Vector2 matrixJ, in Vector2 point) { }

}

