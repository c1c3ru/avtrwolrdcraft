namespace Game.Level;

public class LevelVehicleParkingSpotAreaHandler : LevelAreaBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private bool _isOccupied; //Field offset: 0x38
	[SerializeField]
	private Transform _parkingSpotPosition; //Field offset: 0x40
	[SerializeField]
	private bool _allowsBothParkingDirections; //Field offset: 0x48
	[SerializeField]
	[Tooltip("While parked here, the vehicle's root SortingGroup uses the layer/order below (e.g. to render behind garage art).")]
	private bool _overrideParkedVehicleSorting; //Field offset: 0x49
	[SerializeField]
	private string _parkedVehicleSortingLayer; //Field offset: 0x50
	[SerializeField]
	private int _parkedVehicleSortingOrder; //Field offset: 0x58
	private LevelPlayerVehicle _playerVehicle; //Field offset: 0x60
	private SortingGroup _overriddenVehicleSortingGroup; //Field offset: 0x68
	private int _originalVehicleSortingLayerID; //Field offset: 0x70
	private int _originalVehicleSortingOrder; //Field offset: 0x74
	[CompilerGenerated]
	private Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> OnPreParkingAction; //Field offset: 0x78
	[CompilerGenerated]
	private Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> OnPostParkingAction; //Field offset: 0x80
	[CompilerGenerated]
	private Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> OnPreLeavingAction; //Field offset: 0x88
	[CompilerGenerated]
	private Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> OnPostLeavingAction; //Field offset: 0x90
	[CompilerGenerated]
	private Action<LevelVehicleParkingSpotAreaHandler> OnPlayerVehicleClearedAction; //Field offset: 0x98

	public event Action<LevelVehicleParkingSpotAreaHandler> OnPlayerVehicleClearedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> OnPostLeavingAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> OnPostParkingAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> OnPreLeavingAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> OnPreParkingAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public bool AllowsBothParkingDirections
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool IsOccupied
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public Transform ParkingSpotPosition
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelVehicleParkingSpotAreaHandler() { }

	[CompilerGenerated]
	public void add_OnPlayerVehicleClearedAction(Action<LevelVehicleParkingSpotAreaHandler> value) { }

	[CompilerGenerated]
	public void add_OnPostLeavingAction(Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> value) { }

	[CompilerGenerated]
	public void add_OnPostParkingAction(Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> value) { }

	[CompilerGenerated]
	public void add_OnPreLeavingAction(Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> value) { }

	[CompilerGenerated]
	public void add_OnPreParkingAction(Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> value) { }

	private void ApplyVehicleSorting(LevelPlayerVehicle playerVehicle) { }

	protected virtual void Awake() { }

	public override bool CanVehicleEnterParkingSpot() { }

	public override bool CanVehicleLeaveParkingSpot() { }

	public override void ClearPlayerVehicle() { }

	public bool get_AllowsBothParkingDirections() { }

	public bool get_IsOccupied() { }

	public Transform get_ParkingSpotPosition() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public LevelPlayerVehicle GetPlayerVehicle() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	public void PostLeaving(LevelPlayerVehicle playerVehicle) { }

	public void PostParking(LevelPlayerVehicle playerVehicle) { }

	public void PreLeaving(LevelPlayerVehicle playerVehicle) { }

	public void PreParking(LevelPlayerVehicle playerVehicle) { }

	[CompilerGenerated]
	public void remove_OnPlayerVehicleClearedAction(Action<LevelVehicleParkingSpotAreaHandler> value) { }

	[CompilerGenerated]
	public void remove_OnPostLeavingAction(Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> value) { }

	[CompilerGenerated]
	public void remove_OnPostParkingAction(Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> value) { }

	[CompilerGenerated]
	public void remove_OnPreLeavingAction(Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> value) { }

	[CompilerGenerated]
	public void remove_OnPreParkingAction(Action<LevelVehicleParkingSpotAreaHandler, LevelPlayerVehicle> value) { }

	public void RestoreParkedPlayerVehicle(LevelPlayerVehicle playerVehicle) { }

	private void RestoreVehicleSorting() { }

	public void set_AllowsBothParkingDirections(bool value) { }

	public void set_IsOccupied(bool value) { }

	public void set_ParkingSpotPosition(Transform value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private static void SetVehicleSortingElementsDirty(SortingGroup sortingGroup) { }

}

