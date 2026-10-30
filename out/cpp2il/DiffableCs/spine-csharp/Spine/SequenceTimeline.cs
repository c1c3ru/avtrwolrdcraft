namespace Spine;

public class SequenceTimeline : Timeline, ISlotTimeline
{
	public const int ENTRIES = 3; //Field offset: 0x0
	private const int MODE = 1; //Field offset: 0x0
	private const int DELAY = 2; //Field offset: 0x0
	private readonly int slotIndex; //Field offset: 0x20
	private readonly IHasTextureRegion attachment; //Field offset: 0x28

	public Attachment Attachment
	{
		 get { } //Length: 120
	}

	public virtual int FrameEntries
	{
		 get { } //Length: 8
	}

	public override int SlotIndex
	{
		 get { } //Length: 8
	}

	public SequenceTimeline(int frameCount, int slotIndex, Attachment attachment) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public Attachment get_Attachment() { }

	public virtual int get_FrameEntries() { }

	public override int get_SlotIndex() { }

	public void SetFrame(int frame, float time, SequenceMode mode, int index, float delay) { }

}

