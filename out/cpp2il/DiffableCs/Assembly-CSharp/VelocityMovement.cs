//Type is in global namespace

internal class VelocityMovement
{
	private readonly DeltaTimeCurve _velocityFactorCurve; //Field offset: 0x10
	private float _baseVelocity; //Field offset: 0x18
	[CompilerGenerated]
	private float <lastVelocity>k__BackingField; //Field offset: 0x1C

	public private float lastVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public VelocityMovement(AnimationCurve factorCurve) { }

	public void EndMovement() { }

	[CompilerGenerated]
	public float get_lastVelocity() { }

	public float GetDistance(float deltaTime) { }

	public bool IsMovementEnded() { }

	[CompilerGenerated]
	private void set_lastVelocity(float value) { }

	public void SetMovement(float baseVelocity) { }

}

