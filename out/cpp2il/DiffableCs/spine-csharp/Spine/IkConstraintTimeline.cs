namespace Spine;

public class IkConstraintTimeline : CurveTimeline
{
	public const int ENTRIES = 6; //Field offset: 0x0
	private const int MIX = 1; //Field offset: 0x0
	private const int SOFTNESS = 2; //Field offset: 0x0
	private const int BEND_DIRECTION = 3; //Field offset: 0x0
	private const int COMPRESS = 4; //Field offset: 0x0
	private const int STRETCH = 5; //Field offset: 0x0
	private readonly int constraintIndex; //Field offset: 0x28

	public virtual int FrameEntries
	{
		 get { } //Length: 8
	}

	public int IkConstraintIndex
	{
		 get { } //Length: 8
	}

	public IkConstraintTimeline(int frameCount, int bezierCount, int ikConstraintIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public virtual int get_FrameEntries() { }

	public int get_IkConstraintIndex() { }

	public void SetFrame(int frame, float time, float mix, float softness, int bendDirection, bool compress, bool stretch) { }

}

