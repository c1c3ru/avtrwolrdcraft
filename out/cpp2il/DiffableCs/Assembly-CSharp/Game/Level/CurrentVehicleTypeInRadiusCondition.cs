namespace Game.Level;

public class CurrentVehicleTypeInRadiusCondition : GenericConditionBase
{
	[Tooltip("Optional - overrides _position when set (scene resolvers only, not ConditionResolverAsset)")]
	public Transform _targetTransform; //Field offset: 0x10
	public Vector2 _position; //Field offset: 0x18
	public float _radius; //Field offset: 0x20
	public bool _checkXAxisOnly; //Field offset: 0x24
	[Tooltip("Empty = any type")]
	public List<VehicleType> _vehicleTypes; //Field offset: 0x28

	public CurrentVehicleTypeInRadiusCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

