namespace Spine;

public class EventTimeline : Timeline
{
	private static readonly String[] propertyIds; //Field offset: 0x0
	private readonly Event[] events; //Field offset: 0x20

	public Event[] Events
	{
		 get { } //Length: 8
	}

	private static EventTimeline() { }

	public EventTimeline(int frameCount) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public Event[] get_Events() { }

	public void SetFrame(int frame, Event e) { }

}

