namespace AnimationCurveExtend;

public class DeltaTimeCurve
{
	private AnimationCurve _curve; //Field offset: 0x10
	[CompilerGenerated]
	private float <timeTotal>k__BackingField; //Field offset: 0x18
	private float _timePassed; //Field offset: 0x1C

	public private float timeTotal
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public DeltaTimeCurve(AnimationCurve curve) { }

	public float CurrentEvaluate() { }

	public float Evaluate(float deltaTime) { }

	[CompilerGenerated]
	public float get_timeTotal() { }

	public bool IsTimeOut() { }

	public void Reset() { }

	[CompilerGenerated]
	private void set_timeTotal(float value) { }

}

