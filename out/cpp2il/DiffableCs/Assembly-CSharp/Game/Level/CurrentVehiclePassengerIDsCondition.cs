namespace Game.Level;

public class CurrentVehiclePassengerIDsCondition : GenericConditionBase
{
	public List<Int32> avatarIDs; //Field offset: 0x10
	public bool _requireSameVehicle; //Field offset: 0x18

	public CurrentVehiclePassengerIDsCondition() { }

	[CompilerGenerated]
	private bool <IsMet>b__2_0(LevelPlayerVehicle vehicle) { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

