namespace Spine;

public class AttachmentTimeline : Timeline, ISlotTimeline
{
	private readonly int slotIndex; //Field offset: 0x20
	private readonly String[] attachmentNames; //Field offset: 0x28

	public String[] AttachmentNames
	{
		 get { } //Length: 8
	}

	public override int SlotIndex
	{
		 get { } //Length: 8
	}

	public AttachmentTimeline(int frameCount, int slotIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public String[] get_AttachmentNames() { }

	public override int get_SlotIndex() { }

	private void SetAttachment(Skeleton skeleton, Slot slot, string attachmentName) { }

	public void SetFrame(int frame, float time, string attachmentName) { }

}

