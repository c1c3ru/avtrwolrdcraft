namespace Spine;

public class PhysicsConstraintMassTimeline : PhysicsConstraintTimeline
{

	public PhysicsConstraintMassTimeline(int frameCount, int bezierCount, int physicsConstraintIndex) { }

	protected virtual float Get(PhysicsConstraint constraint) { }

	protected virtual bool Global(PhysicsConstraintData constraint) { }

	protected virtual void Set(PhysicsConstraint constraint, float value) { }

	protected virtual float Setup(PhysicsConstraint constraint) { }

}

