namespace Game.Level;

public class CurrentVehicleTypeCondition : GenericConditionBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public VehicleType vehicleType; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal bool <IsMet>b__1(LevelPlayerVehicle vehicle) { }

	}

	public List<VehicleType> _vehicleTypes; //Field offset: 0x10
	public bool _requireAllTypes; //Field offset: 0x18

	public CurrentVehicleTypeCondition() { }

	[CompilerGenerated]
	private bool <IsMet>b__2_0(LevelPlayerVehicle vehicle) { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

}

