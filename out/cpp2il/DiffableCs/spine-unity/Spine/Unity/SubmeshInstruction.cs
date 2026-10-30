namespace Spine.Unity;

public struct SubmeshInstruction
{
	public Skeleton skeleton; //Field offset: 0x0
	public int startSlot; //Field offset: 0x8
	public int endSlot; //Field offset: 0xC
	public Material material; //Field offset: 0x10
	public bool forceSeparate; //Field offset: 0x18
	public int preActiveClippingSlotSource; //Field offset: 0x1C
	public int rawTriangleCount; //Field offset: 0x20
	public int rawVertexCount; //Field offset: 0x24
	public int rawFirstVertexIndex; //Field offset: 0x28
	public bool hasClipping; //Field offset: 0x2C
	public bool hasPMAAdditiveSlot; //Field offset: 0x2D

	public int SlotCount
	{
		 get { } //Length: 12
	}

	public int get_SlotCount() { }

	public virtual string ToString() { }

}

