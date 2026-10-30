namespace CShapes;

public static class CShapeSpineUtils
{
	internal class Config
	{
		public Bone bone; //Field offset: 0x10
		public Vector2 size; //Field offset: 0x18
		public Vector2 offset; //Field offset: 0x20

		public Config(Bone bone, Vector2 size, Vector2 offset = null) { }

	}


	public static void UpdatePoints(CShape cShape, Config[] configs, bool shouldInitPoints, out Vector2 min, out Vector2 max) { }

}

