namespace Game.Level;

public class CurrentVehicleCountCondition : GenericConditionBase
{
	public int targetCount; //Field offset: 0x10
	public ComparisonType comparisonType; //Field offset: 0x14
	[Tooltip("Empty = count all types")]
	public List<VehicleType> _vehicleTypesFilter; //Field offset: 0x18

	public CurrentVehicleCountCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

