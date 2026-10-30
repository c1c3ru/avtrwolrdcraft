namespace Spine;

public class DrawOrderTimeline : Timeline
{
	private static readonly String[] propertyIds; //Field offset: 0x0
	private readonly Int32[][] drawOrders; //Field offset: 0x20

	public Int32[][] DrawOrders
	{
		 get { } //Length: 8
	}

	private static DrawOrderTimeline() { }

	public DrawOrderTimeline(int frameCount) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public Int32[][] get_DrawOrders() { }

	public void SetFrame(int frame, float time, Int32[] drawOrder) { }

}

