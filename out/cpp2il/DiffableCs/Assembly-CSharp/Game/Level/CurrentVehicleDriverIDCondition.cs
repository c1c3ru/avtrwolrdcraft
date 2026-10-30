namespace Game.Level;

public class CurrentVehicleDriverIDCondition : GenericConditionBase
{
	[Tooltip("-1 = any driver")]
	public int _driverAvatarID; //Field offset: 0x10

	public CurrentVehicleDriverIDCondition() { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

