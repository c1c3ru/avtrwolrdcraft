//Type is in global namespace

public class FreeMovementCtrl : IMovementCtrl
{
	private const float _stopVelocityThreshold = 425; //Field offset: 0x0
	private readonly VelocityMovement _releasingMovement; //Field offset: 0x10
	private readonly DistanceMovement _aligningMovement; //Field offset: 0x18
	private bool _isDragging; //Field offset: 0x20
	private float _draggingDistance; //Field offset: 0x24
	private readonly bool _toAlign; //Field offset: 0x28
	private float _overGoingDistance; //Field offset: 0x2C
	private readonly float _overGoingDistanceThreshold; //Field offset: 0x30
	private readonly Func<Single> _getAligningDistance; //Field offset: 0x38
	private readonly Func<PositionState> _getPositionState; //Field offset: 0x40

	public FreeMovementCtrl(AnimationCurve releasingCurve, bool toAlign, float overGoingDistanceThreshold, Func<Single> getAligningDistance, Func<PositionState> getPositionState) { }

	public override float GetDistance(float deltaTime) { }

	private bool IsGoingTooFar(float distance) { }

	public override bool IsMovementEnded() { }

	private bool NeedToAlign(float distance) { }

	public override void SetMovement(float value, bool isDragging) { }

}

