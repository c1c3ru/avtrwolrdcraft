namespace Spine;

public class Animation
{
	internal string name; //Field offset: 0x10
	internal ExposedList<Timeline> timelines; //Field offset: 0x18
	internal HashSet<String> timelineIds; //Field offset: 0x20
	internal float duration; //Field offset: 0x28

	public float Duration
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string Name
	{
		 get { } //Length: 8
	}

	public ExposedList<Timeline> Timelines
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public Animation(string name, ExposedList<Timeline> timelines, float duration) { }

	public void Apply(Skeleton skeleton, float lastTime, float time, bool loop, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction) { }

	public float get_Duration() { }

	public string get_Name() { }

	public ExposedList<Timeline> get_Timelines() { }

	public bool HasTimeline(String[] propertyIds) { }

	public void set_Duration(float value) { }

	public void set_Timelines(ExposedList<Timeline> value) { }

	public void SetTimelines(ExposedList<Timeline> timelines) { }

	public virtual string ToString() { }

}

