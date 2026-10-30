namespace Spine;

public class PhysicsConstraintResetTimeline : Timeline
{
	private static readonly String[] propertyIds; //Field offset: 0x0
	private readonly int constraintIndex; //Field offset: 0x20

	public virtual int FrameCount
	{
		 get { } //Length: 28
	}

	public int PhysicsConstraintIndex
	{
		 get { } //Length: 8
	}

	private static PhysicsConstraintResetTimeline() { }

	public PhysicsConstraintResetTimeline(int frameCount, int physicsConstraintIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public virtual int get_FrameCount() { }

	public int get_PhysicsConstraintIndex() { }

	public void SetFrame(int frame, float time) { }

}

