namespace Spine;

public class DeformTimeline : CurveTimeline, ISlotTimeline
{
	private readonly int slotIndex; //Field offset: 0x28
	private readonly VertexAttachment attachment; //Field offset: 0x30
	internal Single[][] vertices; //Field offset: 0x38

	public VertexAttachment Attachment
	{
		 get { } //Length: 8
	}

	public override int SlotIndex
	{
		 get { } //Length: 8
	}

	public Single[][] Vertices
	{
		 get { } //Length: 8
	}

	public DeformTimeline(int frameCount, int bezierCount, int slotIndex, VertexAttachment attachment) { }

	public virtual void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction) { }

	public VertexAttachment get_Attachment() { }

	public override int get_SlotIndex() { }

	public Single[][] get_Vertices() { }

	private float GetCurvePercent(float time, int frame) { }

	public void setBezier(int bezier, int frame, int value, float time1, float value1, float cx1, float cy1, float cx2, float cy2, float time2, float value2) { }

	public void SetFrame(int frame, float time, Single[] vertices) { }

}

