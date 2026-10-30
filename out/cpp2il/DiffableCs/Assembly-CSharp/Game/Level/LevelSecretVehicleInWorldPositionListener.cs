namespace Game.Level;

public class LevelSecretVehicleInWorldPositionListener : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public VehicleType vehicleType; //Field offset: 0x10

		public <>c__DisplayClass20_0() { }

		internal bool <AreConditionsMet>b__0(LevelPlayerVehicle vehicle) { }

	}

	[SerializeField]
	[Tooltip("All types must be in range simultaneously. Empty = any vehicle")]
	private List<VehicleType> _vehicleTypes; //Field offset: 0x20
	[SerializeField]
	private Vector2 _xRangeInScene; //Field offset: 0x28
	[SerializeField]
	[Tooltip("Ignores _xRangeInScene - in range when within _roadEdgeTolerance of the vehicle's road max x")]
	private bool _useRoadRightEdge; //Field offset: 0x30
	[SerializeField]
	private float _roadEdgeTolerance; //Field offset: 0x34
	[SerializeField]
	[Tooltip("Only evaluates when CheckConditions is called")]
	private bool _checkOnlyWhenCalled; //Field offset: 0x38
	[SerializeField]
	[Tooltip("Invokes the met / not met event on level load even if the state didn't change")]
	private bool _invokeStateOnInit; //Field offset: 0x39
	[SerializeField]
	private bool _excludeParkedVehicles; //Field offset: 0x3A
	[SerializeField]
	[Tooltip("Optional - evaluated with the vehicles in range (and their passengers as avatars)")]
	private ConditionResolver _conditionResolver; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onConditionMetEvent; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onConditionNotMetEvent; //Field offset: 0x50
	private readonly List<LevelPlayerVehicle> _matchedVehicles; //Field offset: 0x58
	private bool _isConditionMet; //Field offset: 0x60

	public LevelSecretVehicleInWorldPositionListener() { }

	private bool AreConditionsMet() { }

	private bool AreResolverConditionsMet() { }

	private void Awake() { }

	public void CheckConditions() { }

	private bool IsInRange(LevelPlayerVehicle vehicle) { }

	private void OnDestroy() { }

	private void OnItemEndLand(LevelItem levelItem, LevelDropArea dropArea) { }

	private void OnPermanentPostInit() { }

	private void OnVehicleBeginDrag(LevelPlayerVehicle vehicle) { }

	private void OnVehicleStopped(LevelPlayerVehicle vehicle) { }

	private void SetConditionState(bool isMet) { }

}

