//Type is in global namespace

public class LTBezierPath
{
	public Vector3[] pts; //Field offset: 0x10
	public float length; //Field offset: 0x18
	public bool orientToPath; //Field offset: 0x1C
	public bool orientToPath2d; //Field offset: 0x1D
	private LTBezier[] beziers; //Field offset: 0x20
	private Single[] lengthRatio; //Field offset: 0x28
	private int currentBezier; //Field offset: 0x30
	private int previousBezier; //Field offset: 0x34

	public float distance
	{
		 get { } //Length: 8
	}

	public LTBezierPath() { }

	public LTBezierPath(Vector3[] pts_) { }

	public float get_distance() { }

	public void gizmoDraw(float t = -1) { }

	public void place(Transform transform, float ratio) { }

	public void place(Transform transform, float ratio, Vector3 worldUp) { }

	public void place2d(Transform transform, float ratio) { }

	public void placeLocal(Transform transform, float ratio) { }

	public void placeLocal(Transform transform, float ratio, Vector3 worldUp) { }

	public void placeLocal2d(Transform transform, float ratio) { }

	public Vector3 point(float ratio) { }

	public float ratioAtPoint(Vector3 pt, float precision = 0,01) { }

	public void setPoints(Vector3[] pts_) { }

}

