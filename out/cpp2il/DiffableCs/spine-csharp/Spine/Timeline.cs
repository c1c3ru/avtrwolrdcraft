namespace Spine;

public abstract class Timeline
{
	private readonly String[] propertyIds; //Field offset: 0x10
	internal readonly Single[] frames; //Field offset: 0x18

	public float Duration
	{
		 get { } //Length: 64
	}

	public override int FrameCount
	{
		 get { } //Length: 44
	}

	public override int FrameEntries
	{
		 get { } //Length: 8
	}

	public Single[] Frames
	{
		 get { } //Length: 8
	}

	public String[] PropertyIds
	{
		 get { } //Length: 8
	}

	public Timeline(int frameCount, String[] propertyIds) { }

	public abstract void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction) { }

	public float get_Duration() { }

	public override int get_FrameCount() { }

	public override int get_FrameEntries() { }

	public Single[] get_Frames() { }

	public String[] get_PropertyIds() { }

	internal static int Search(Single[] frames, float time) { }

	internal static int Search(Single[] frames, float time, int step) { }

}

