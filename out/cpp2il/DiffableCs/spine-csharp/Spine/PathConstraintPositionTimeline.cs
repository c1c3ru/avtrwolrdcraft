namespace Spine;

public class PathConstraintPositionTimeline : CurveTimeline1
{
	private readonly int constraintIndex; //Field offset: 0x28

	public int PathConstraintIndex
	{
		 get { } //Length: 8
	}

	public PathConstraintPositionTimeline(int frameCount, int bezierCount, int pathConstraintIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public int get_PathConstraintIndex() { }

}

