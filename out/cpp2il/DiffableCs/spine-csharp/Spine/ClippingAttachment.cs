namespace Spine;

public class ClippingAttachment : VertexAttachment
{
	internal SlotData endSlot; //Field offset: 0x40

	public SlotData EndSlot
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ClippingAttachment(string name) { }

	protected ClippingAttachment(ClippingAttachment other) { }

	public virtual Attachment Copy() { }

	public SlotData get_EndSlot() { }

	public void set_EndSlot(SlotData value) { }

}

