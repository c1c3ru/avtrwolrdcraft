namespace Spine;

public abstract class CurveTimeline2 : CurveTimeline
{
	public const int ENTRIES = 3; //Field offset: 0x0
	internal const int VALUE1 = 1; //Field offset: 0x0
	internal const int VALUE2 = 2; //Field offset: 0x0

	public virtual int FrameEntries
	{
		 get { } //Length: 8
	}

	public CurveTimeline2(int frameCount, int bezierCount, string propertyId1, string propertyId2) { }

	public virtual int get_FrameEntries() { }

	public void SetFrame(int frame, float time, float value1, float value2) { }

}

