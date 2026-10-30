//Type is in global namespace

public class LTSpline
{
	public static int DISTANCE_COUNT; //Field offset: 0x0
	public static int SUBLINE_COUNT; //Field offset: 0x4
	public float distance; //Field offset: 0x10
	public bool constantSpeed; //Field offset: 0x14
	public Vector3[] pts; //Field offset: 0x18
	public Vector3[] ptsAdj; //Field offset: 0x20
	public int ptsAdjLength; //Field offset: 0x28
	public bool orientToPath; //Field offset: 0x2C
	public bool orientToPath2d; //Field offset: 0x2D
	private int numSections; //Field offset: 0x30
	private int currPt; //Field offset: 0x34

	private static LTSpline() { }

	public LTSpline(Vector3[] pts) { }

	public LTSpline(Vector3[] pts, bool constantSpeed) { }

	public static void drawGizmo(Transform[] arr, Color color) { }

	public void drawGizmo(Color color) { }

	public static void drawLine(Transform[] arr, float width, Color color) { }

	public void drawLinesGLLines(Material outlineMaterial, Color color, float width) { }

	public Vector3[] generateVectors() { }

	public void gizmoDraw(float t = -1) { }

	private void init(Vector3[] pts, bool constantSpeed) { }

	public Vector3 interp(float t) { }

	public Vector3 map(float u) { }

	public void place(Transform transform, float ratio, Vector3 worldUp) { }

	public void place(Transform transform, float ratio) { }

	public void place2d(Transform transform, float ratio) { }

	public void placeLocal(Transform transform, float ratio) { }

	public void placeLocal(Transform transform, float ratio, Vector3 worldUp) { }

	public void placeLocal2d(Transform transform, float ratio) { }

	public Vector3 point(float ratio) { }

	public float ratioAtPoint(Vector3 pt) { }

}

