namespace Game.Level;

public class CurrentVehicleIDCondition : GenericConditionBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public int vehicleID; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal bool <IsMet>b__1(LevelPlayerVehicle vehicle) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public LevelPlayerVehicle vehicle; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <HasAnyID>b__0(int vehicleID) { }

	}

	public List<Int32> _vehicleIDs; //Field offset: 0x10
	public bool _requireAllIDs; //Field offset: 0x18

	public CurrentVehicleIDCondition() { }

	[CompilerGenerated]
	private bool <IsMet>b__2_0(LevelPlayerVehicle vehicle) { }

	private static bool HasAnyID(LevelPlayerVehicle vehicle, List<Int32> vehicleIDs) { }

	private static bool HasID(LevelPlayerVehicle vehicle, int vehicleID) { }

	public virtual bool IsMet(GenericConditionData genericConditionData) { }

	private static bool TryGetSceneGuid(LevelPlayerVehicle vehicle, out string sceneGuid) { }

}

