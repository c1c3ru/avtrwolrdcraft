//Type is in global namespace

public class UnitMovementCtrl : IMovementCtrl
{
	private readonly DistanceMovement _unitMovement; //Field offset: 0x10
	private readonly DistanceMovement _bouncingMovement; //Field offset: 0x18
	private readonly float _bouncingDeltaPos; //Field offset: 0x20
	private readonly Func<Single> _getAligningDistance; //Field offset: 0x28
	private readonly Func<PositionState> _getPositionState; //Field offset: 0x30

	public UnitMovementCtrl(AnimationCurve movementCurve, float bouncingDeltaPos, Func<Single> getAligningDistance, Func<PositionState> getPositionState) { }

	public override float GetDistance(float deltaTime) { }

	public override bool IsMovementEnded() { }

	private bool NeedToAlign(float deltaDistance) { }

	public override void SetMovement(float distanceAdded, bool flag) { }

}

