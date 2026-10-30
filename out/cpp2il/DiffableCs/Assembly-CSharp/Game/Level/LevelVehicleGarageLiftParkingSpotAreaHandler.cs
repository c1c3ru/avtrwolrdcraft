namespace Game.Level;

public class LevelVehicleGarageLiftParkingSpotAreaHandler : LevelVehicleParkingSpotAreaHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass70_0
	{
		public bool isRaised; //Field offset: 0x10

		public <>c__DisplayClass70_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass70_1
	{
		public RaisedMovedTransform movedTransform; //Field offset: 0x10
		public <>c__DisplayClass70_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass70_1() { }

		internal void <SetMovedTransformsRaised>b__0() { }

	}

	private class RaisedMovedTransform
	{
		public Transform target; //Field offset: 0x10
		[Tooltip("Where the target moves while the lift is above the bottom level.")]
		public Transform raisedPoint; //Field offset: 0x18
		[Tooltip("Target's SortingGroup order while at the raised point.")]
		public int raisedSortingOrder; //Field offset: 0x20
		public Vector3 bottomPosition; //Field offset: 0x24
		public SortingGroup sortingGroup; //Field offset: 0x30
		public int bottomSortingOrder; //Field offset: 0x38
		public int tweenID; //Field offset: 0x3C

		public RaisedMovedTransform() { }

		public void SetSortingOrder(bool isRaised) { }

	}

	private class UnderLiftArea
	{
		[Tooltip("LevelDropArea / LevelSitArea under the lift. Filter what it accepts with LevelConsumerArea*ConditionHandler components.")]
		public LevelConsumerAreaBase area; //Field offset: 0x10
		[Tooltip("Lift levels (1 = middle, 2 = top) on which this area accepts items while a vehicle is parked.")]
		public Int32[] availableLevels; //Field offset: 0x18
		public bool availableWithoutVehicle; //Field offset: 0x20
		public LevelVehicleGarageLiftParkingSpotAreaHandler owner; //Field offset: 0x28

		public UnderLiftArea() { }

		public bool IsAvailableAtLevel(int level) { }

		public bool IsOccupied(LevelItem ignoredItem = null) { }

		public void OnCanConsumeItem(LevelItem levelItem, ref bool canConsume) { }

		public void OnItemEndDrop(LevelItem _) { }

		public void OnItemPickUp(LevelItem levelItem) { }

	}

	private const string LIFT_LEVEL_KEY = "LevelVehicleGarageLiftParkingSpotAreaHandler_liftLevel"; //Field offset: 0x0
	[SerializeField]
	[Tooltip("Local Y offset of ParkingSpotPosition per raised level (index 0 = level 1). Bottom level is the authored position.")]
	private Single[] _raisedLevelOffsets; //Field offset: 0xA0
	[SerializeField]
	private float _liftTweenDuration; //Field offset: 0xA8
	[SerializeField]
	private LeanTweenType _liftTweenEase; //Field offset: 0xAC
	[SerializeField]
	private UnderLiftArea[] _underLiftAreas; //Field offset: 0xB0
	[SerializeField]
	[Tooltip("Moved up/down by the same offset as ParkingSpotPosition (e.g. lift chains).")]
	private Transform[] _liftedTransforms; //Field offset: 0xB8
	[SerializeField]
	[Tooltip("Moved to their raised point once the lift leaves the bottom level, and back as it starts lowering to it (e.g. creepers).")]
	private RaisedMovedTransform[] _raisedMovedTransforms; //Field offset: 0xC0
	[SerializeField]
	[Tooltip("When lowering to the bottom level, the lift waits for this move to finish.")]
	private float _raisedMovedTransformsTweenDuration; //Field offset: 0xC8
	[SerializeField]
	[Tooltip("Off sprite = can move, On sprite = moving that way, Disabled sprite = can't move. Press duration should match the lift tween.")]
	private LevelButton _raiseButton; //Field offset: 0xD0
	[SerializeField]
	private LevelButton _lowerButton; //Field offset: 0xD8
	[SerializeField]
	private string _liftMoveUpSoundName; //Field offset: 0xE0
	[SerializeField]
	private string _liftMoveDownSoundName; //Field offset: 0xE8
	[SerializeField]
	private UnityEvent _onLiftMoveStartEvent; //Field offset: 0xF0
	[SerializeField]
	private UnityEvent _onLiftMoveEndEvent; //Field offset: 0xF8
	public UnityEvent onReachTopLevelEvent; //Field offset: 0x100
	public UnityEvent onReachBottomLevelEvent; //Field offset: 0x108
	private float _bottomLocalY; //Field offset: 0x110
	private Single[] _liftedTransformsBottomLocalY; //Field offset: 0x118
	private int _currentLevel; //Field offset: 0x120
	private int _tweenID; //Field offset: 0x124
	private bool _isLiftMoving; //Field offset: 0x128
	private bool _isVehicleSettled; //Field offset: 0x129
	private int _moveDirection; //Field offset: 0x12C
	private bool _areMovedTransformsRaised; //Field offset: 0x130
	private readonly List<CShape> _disabledVehicleShapes; //Field offset: 0x138
	[CompilerGenerated]
	private Action<Int32> OnLiftMoveStartAction; //Field offset: 0x140
	[CompilerGenerated]
	private Action<Int32> OnLiftMoveEndAction; //Field offset: 0x148

	public event Action<Int32> OnLiftMoveEndAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public event Action<Int32> OnLiftMoveStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public int CurrentLevel
	{
		 get { } //Length: 8
	}

	public bool IsLiftMoving
	{
		 get { } //Length: 8
	}

	public int MaxLevel
	{
		 get { } //Length: 28
	}

	public LevelVehicleGarageLiftParkingSpotAreaHandler() { }

	[CompilerGenerated]
	private void <TryMoveToLevel>b__58_0(float _) { }

	[CompilerGenerated]
	public void add_OnLiftMoveEndAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void add_OnLiftMoveStartAction(Action<Int32> value) { }

	protected virtual void Awake() { }

	private bool CanMoveToLevel(int level, LevelItem ignoredItem = null) { }

	public virtual bool CanVehicleEnterParkingSpot() { }

	public virtual bool CanVehicleLeaveParkingSpot() { }

	public virtual void ClearPlayerVehicle() { }

	private void DisableVehicleShape(CShape cShape) { }

	private bool DoOccupiedUnderLiftAreasAllowLevel(int level, LevelItem ignoredItem = null) { }

	public int get_CurrentLevel() { }

	public bool get_IsLiftMoving() { }

	public int get_MaxLevel() { }

	private float GetLocalYForLevel(int level) { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	private bool HasPassengers(LevelItem ignoredItem = null) { }

	public bool IsAnyUnderLiftAreaOccupied() { }

	private bool IsPassenger(LevelItem levelItem) { }

	private bool IsUnderLiftAreaAvailable(UnderLiftArea underLiftArea) { }

	[ContextMenu("Lower")]
	public void Lower() { }

	private void OnBeforeDestroyLevelItem(LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

	private void OnItemBeginDrag(LevelItem levelItem) { }

	private void OnItemEndLand(LevelItem levelItem, LevelDropArea _) { }

	private void OnLevelPermanentPostInit() { }

	private void OnLiftMoveComplete() { }

	private void OnPostParking(LevelVehicleParkingSpotAreaHandler _, LevelPlayerVehicle __) { }

	private void OnPreLeaving(LevelVehicleParkingSpotAreaHandler _, LevelPlayerVehicle __) { }

	private void PlayLiftMoveSound(float delay) { }

	[ContextMenu("Raise")]
	public void Raise() { }

	private void RefreshButton(LevelButton button, int targetLevel, bool isMovingThisWay, LevelItem ignoredItem) { }

	private void RefreshButtons(LevelItem ignoredItem = null) { }

	private void RefreshVehicleShapes() { }

	[CompilerGenerated]
	public void remove_OnLiftMoveEndAction(Action<Int32> value) { }

	[CompilerGenerated]
	public void remove_OnLiftMoveStartAction(Action<Int32> value) { }

	private void RestoreVehicleShapes() { }

	private void SetLevelInstant(int level) { }

	private bool SetMovedTransformsRaised(bool isRaised, bool isInstant) { }

	private void SetParkingSpotLocalY(float localY) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncLiftedTransforms() { }

	private void SyncVehicleToParkingSpot() { }

	private void TryMoveToLevel(int level) { }

}

