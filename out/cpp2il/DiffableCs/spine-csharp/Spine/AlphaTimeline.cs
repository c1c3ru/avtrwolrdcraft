namespace Spine;

public class AlphaTimeline : CurveTimeline1, ISlotTimeline
{
	private readonly int slotIndex; //Field offset: 0x28

	public override int SlotIndex
	{
		 get { } //Length: 8
	}

	public AlphaTimeline(int frameCount, int bezierCount, int slotIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public override int get_SlotIndex() { }

}

