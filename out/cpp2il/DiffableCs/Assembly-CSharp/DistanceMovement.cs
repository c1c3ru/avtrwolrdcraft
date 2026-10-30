//Type is in global namespace

internal class DistanceMovement
{
	private readonly DeltaTimeCurve _distanceFactorCurve; //Field offset: 0x10
	private float _distanceTotal; //Field offset: 0x18
	private float _lastDistance; //Field offset: 0x1C

	public float distanceRemaining
	{
		 get { } //Length: 12
	}

	public DistanceMovement(AnimationCurve factorCurve) { }

	public void EndMovement() { }

	public float get_distanceRemaining() { }

	public float GetDistance(float deltaTime) { }

	public bool IsMovementEnded() { }

	public void SetMovement(float totalDistance) { }

}

