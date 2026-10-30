namespace Game.Level;

public class CurrentClosestVehicleToPositionCondition : GenericConditionBase
{
	[Tooltip("Optional - overrides _position when set (scene resolvers only, not ConditionResolverAsset)")]
	public Transform _targetTransform; //Field offset: 0x10
	public Vector2 _position; //Field offset: 0x18
	public bool _checkXAxisOnly; //Field offset: 0x20
	[Tooltip("0 or less = no distance limit")]
	public float _maxDistance; //Field offset: 0x24
	[Tooltip("Empty = any type")]
	public List<VehicleType> _expectedVehicleTypes; //Field offset: 0x28
	[Tooltip("Empty = no passenger requirement")]
	public List<Int32> _requiredPassengerIDs; //Field offset: 0x30

	public CurrentClosestVehicleToPositionCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

