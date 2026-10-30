namespace Spine;

public abstract class CurveTimeline : Timeline
{
	public const int LINEAR = 0; //Field offset: 0x0
	public const int STEPPED = 1; //Field offset: 0x0
	public const int BEZIER = 2; //Field offset: 0x0
	public const int BEZIER_SIZE = 18; //Field offset: 0x0
	internal Single[] curves; //Field offset: 0x20

	public CurveTimeline(int frameCount, int bezierCount, String[] propertyIds) { }

	public float GetBezierValue(float time, int frameIndex, int valueOffset, int i) { }

	public float GetCurveType(int frame) { }

	public void SetBezier(int bezier, int frame, int value, float time1, float value1, float cx1, float cy1, float cx2, float cy2, float time2, float value2) { }

	public void SetLinear(int frame) { }

	public void SetStepped(int frame) { }

	public void Shrink(int bezierCount) { }

}

