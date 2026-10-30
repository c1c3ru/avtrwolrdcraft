namespace Spine;

public abstract class CurveTimeline1 : CurveTimeline
{
	public const int ENTRIES = 2; //Field offset: 0x0
	internal const int VALUE = 1; //Field offset: 0x0

	public virtual int FrameEntries
	{
		 get { } //Length: 8
	}

	public CurveTimeline1(int frameCount, int bezierCount, string propertyId) { }

	public virtual int get_FrameEntries() { }

	public float GetAbsoluteValue(float time, float alpha, MixBlend blend, float current, float setup) { }

	public float GetAbsoluteValue(float time, float alpha, MixBlend blend, float current, float setup, float value) { }

	public float GetCurveValue(float time) { }

	public float GetRelativeValue(float time, float alpha, MixBlend blend, float current, float setup) { }

	public float GetScaleValue(float time, float alpha, MixBlend blend, MixDirection direction, float current, float setup) { }

	public void SetFrame(int frame, float time, float value) { }

}

