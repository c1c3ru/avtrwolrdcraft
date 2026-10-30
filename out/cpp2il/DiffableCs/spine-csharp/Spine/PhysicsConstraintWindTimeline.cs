namespace Spine;

public class PhysicsConstraintWindTimeline : PhysicsConstraintTimeline
{

	public PhysicsConstraintWindTimeline(int frameCount, int bezierCount, int physicsConstraintIndex) { }

	protected virtual float Get(PhysicsConstraint constraint) { }

	protected virtual bool Global(PhysicsConstraintData constraint) { }

	protected virtual void Set(PhysicsConstraint constraint, float value) { }

	protected virtual float Setup(PhysicsConstraint constraint) { }

}

