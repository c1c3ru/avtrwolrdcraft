//Type is in global namespace

public class LTBezier
{
	public float length; //Field offset: 0x10
	private Vector3 a; //Field offset: 0x14
	private Vector3 aa; //Field offset: 0x20
	private Vector3 bb; //Field offset: 0x2C
	private Vector3 cc; //Field offset: 0x38
	private float len; //Field offset: 0x44
	private Single[] arcLengths; //Field offset: 0x48

	public LTBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float precision) { }

	private Vector3 bezierPoint(float t) { }

	private float map(float u) { }

	public Vector3 point(float t) { }

}

