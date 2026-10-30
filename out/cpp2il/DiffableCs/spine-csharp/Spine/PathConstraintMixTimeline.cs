namespace Spine;

public class PathConstraintMixTimeline : CurveTimeline
{
	public const int ENTRIES = 4; //Field offset: 0x0
	private const int ROTATE = 1; //Field offset: 0x0
	private const int X = 2; //Field offset: 0x0
	private const int Y = 3; //Field offset: 0x0
	private readonly int constraintIndex; //Field offset: 0x28

	public virtual int FrameEntries
	{
		 get { } //Length: 8
	}

	public int PathConstraintIndex
	{
		 get { } //Length: 8
	}

	public PathConstraintMixTimeline(int frameCount, int bezierCount, int pathConstraintIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public virtual int get_FrameEntries() { }

	public int get_PathConstraintIndex() { }

	public void SetFrame(int frame, float time, float mixRotate, float mixX, float mixY) { }

}

