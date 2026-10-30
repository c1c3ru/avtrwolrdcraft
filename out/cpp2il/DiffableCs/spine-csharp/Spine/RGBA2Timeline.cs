namespace Spine;

public class RGBA2Timeline : CurveTimeline, ISlotTimeline
{
	public const int ENTRIES = 8; //Field offset: 0x0
	protected const int R = 1; //Field offset: 0x0
	protected const int G = 2; //Field offset: 0x0
	protected const int B = 3; //Field offset: 0x0
	protected const int A = 4; //Field offset: 0x0
	protected const int R2 = 5; //Field offset: 0x0
	protected const int G2 = 6; //Field offset: 0x0
	protected const int B2 = 7; //Field offset: 0x0
	private readonly int slotIndex; //Field offset: 0x28

	public virtual int FrameEntries
	{
		 get { } //Length: 8
	}

	public override int SlotIndex
	{
		 get { } //Length: 8
	}

	public RGBA2Timeline(int frameCount, int bezierCount, int slotIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public virtual int get_FrameEntries() { }

	public override int get_SlotIndex() { }

	public void SetFrame(int frame, float time, float r, float g, float b, float a, float r2, float g2, float b2) { }

}

