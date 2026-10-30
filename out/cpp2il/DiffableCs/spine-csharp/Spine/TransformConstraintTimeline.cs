namespace Spine;

public class TransformConstraintTimeline : CurveTimeline
{
	public const int ENTRIES = 7; //Field offset: 0x0
	private const int ROTATE = 1; //Field offset: 0x0
	private const int X = 2; //Field offset: 0x0
	private const int Y = 3; //Field offset: 0x0
	private const int SCALEX = 4; //Field offset: 0x0
	private const int SCALEY = 5; //Field offset: 0x0
	private const int SHEARY = 6; //Field offset: 0x0
	private readonly int constraintIndex; //Field offset: 0x28

	public virtual int FrameEntries
	{
		 get { } //Length: 8
	}

	public int TransformConstraintIndex
	{
		 get { } //Length: 8
	}

	public TransformConstraintTimeline(int frameCount, int bezierCount, int transformConstraintIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public virtual int get_FrameEntries() { }

	public int get_TransformConstraintIndex() { }

	public void GetCurveValue(out float rotate, out float x, out float y, out float scaleX, out float scaleY, out float shearY, float time) { }

	public void SetFrame(int frame, float time, float mixRotate, float mixX, float mixY, float mixScaleX, float mixScaleY, float mixShearY) { }

}

