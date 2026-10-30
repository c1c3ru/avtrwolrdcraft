namespace Spine;

public abstract class PhysicsConstraintTimeline : CurveTimeline1
{
	private readonly int constraintIndex; //Field offset: 0x28

	public int PhysicsConstraintIndex
	{
		 get { } //Length: 8
	}

	public PhysicsConstraintTimeline(int frameCount, int bezierCount, int physicsConstraintIndex, Property property) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	protected abstract float Get(PhysicsConstraint constraint) { }

	public int get_PhysicsConstraintIndex() { }

	protected abstract bool Global(PhysicsConstraintData constraint) { }

	protected abstract void Set(PhysicsConstraint constraint, float value) { }

	protected abstract float Setup(PhysicsConstraint constraint) { }

}

