namespace Spine;

public class InheritTimeline : Timeline, IBoneTimeline
{
	public const int ENTRIES = 2; //Field offset: 0x0
	public const int INHERIT = 1; //Field offset: 0x0
	private readonly int boneIndex; //Field offset: 0x20

	public override int BoneIndex
	{
		 get { } //Length: 8
	}

	public virtual int FrameEntries
	{
		 get { } //Length: 8
	}

	public InheritTimeline(int frameCount, int boneIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public override int get_BoneIndex() { }

	public virtual int get_FrameEntries() { }

	public void SetFrame(int frame, float time, Inherit inherit) { }

}

