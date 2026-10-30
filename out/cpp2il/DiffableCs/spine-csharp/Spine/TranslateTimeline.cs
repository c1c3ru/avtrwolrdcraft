namespace Spine;

public class TranslateTimeline : CurveTimeline2, IBoneTimeline
{
	private readonly int boneIndex; //Field offset: 0x28

	public override int BoneIndex
	{
		 get { } //Length: 8
	}

	public TranslateTimeline(int frameCount, int bezierCount, int boneIndex) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public override int get_BoneIndex() { }

	public void GetCurveValue(out float x, out float y, float time) { }

}

