namespace Spine;

public class PathConstraintSpacingTimeline : CurveTimeline1
{
	private readonly int constraintIndex; //Field offset: 0x28

	public int PathConstraintIndex
	{
		 get { } //Length: 8
	}

	public PathConstraintSpacingTimeline(int frameCount, int bezierCount, int pathConstraintIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction) { }

	public int get_PathConstraintIndex() { }

}

