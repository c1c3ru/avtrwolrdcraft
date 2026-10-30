namespace Game.Level;

[RequireComponent(typeof(PDPrefab))]
public class LevelPlayerVehicle : DragDropItemBase, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay, IMultiplayer_PrepareForDrag
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<Vector2> <>9__127_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <OnSyncPosition>b__127_0(Vector2 v1, Vector2 v2) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass129_0
	{
		public LevelPlayerVehicle <>4__this; //Field offset: 0x10
		public LevelVehicleParkingSpotAreaHandler parkingSpot; //Field offset: 0x18

		public <>c__DisplayClass129_0() { }

		internal void <VerifyIfEnteringParking>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass130_0
	{
		public LevelVehicleParkingSpotAreaHandler parkingSpot; //Field offset: 0x10
		public LevelPlayerVehicle <>4__this; //Field offset: 0x18

		public <>c__DisplayClass130_0() { }

		internal void <VerifyIfLeavingParking>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass139_0
	{
		public Action<TrackEntry> OnComplete; //Field offset: 0x10
		public TrackEntry trackEntry; //Field offset: 0x18

		public <>c__DisplayClass139_0() { }

		internal void <DoorSetState>b__0(TrackEntry x) { }

	}

	[CompilerGenerated]
	private sealed class <VerifyIfEnteringParking>d__129 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelPlayerVehicle <>4__this; //Field offset: 0x20
		private <>c__DisplayClass129_0 <>8__1; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <VerifyIfEnteringParking>d__129(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <VerifyIfLeavingParking>d__130 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public LevelPlayerVehicle <>4__this; //Field offset: 0x20
		private <>c__DisplayClass130_0 <>8__1; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <VerifyIfLeavingParking>d__130(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const string CAR_HONKING_SOUND = "Car_Honking"; //Field offset: 0x0
	private const string ALL_VEHICLE_DATA_PATH = "VehicleApp/AllVehicleData"; //Field offset: 0x0
	private const float MOVEMENT_WINDOW_SECONDS = 0,25; //Field offset: 0x0
	private const float MOVEMENT_THRESHOLD_X = 0,1; //Field offset: 0x0
	private const string CAR_WIPERS_LOOP_SOUND = "Car_Wipers_Loop"; //Field offset: 0x0
	private const string CAR_LIGHTS_OFF_SOUND = "Car_Lights_Off"; //Field offset: 0x0
	private const string CAR_LIGHTS_ON_SOUND = "Car_Lights_On"; //Field offset: 0x0
	private const string CAR_WINDOW_CLOSE_SOUND = "Car_Window_Close"; //Field offset: 0x0
	private const string CAR_WINDOW_OPEN_SOUND = "Car_Window_Open"; //Field offset: 0x0
	private const string CAR_ENGINE_ON_SOUND = "Car_Engine_On"; //Field offset: 0x0
	private const string CAR_RADIO_OFF_SOUND = "Car_Radio_Off"; //Field offset: 0x0
	private const string CAR_RADIO_ON_SOUND = "Car_Radio_On"; //Field offset: 0x0
	private const string CAR_DRIVE_LOOP_SOUND = "Car_Drive_Loop"; //Field offset: 0x0
	private const string CAR_REVERSE_LOOP_SOUND = "Car_Reverse_Loop"; //Field offset: 0x0
	public static readonly List<LevelPlayerVehicle> List; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelPlayerVehicle> OnVehicleBeginDragStaticAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<LevelPlayerVehicle> OnVehicleStoppedStaticAction; //Field offset: 0x10
	private static GeneralVehicleData _generalVehicleData; //Field offset: 0x18
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x110
	[SerializeField]
	private LevelSitArea _driverDropArea; //Field offset: 0x118
	[SerializeField]
	private GameObject _rearlightsLightSource; //Field offset: 0x120
	[SerializeField]
	private LevelLight _rearLights; //Field offset: 0x128
	[SerializeField]
	private GameObject _headlightsLightSource; //Field offset: 0x130
	[SerializeField]
	private GameObject _topSignLightSource; //Field offset: 0x138
	[SerializeField]
	private CShape _itemShape; //Field offset: 0x140
	[SerializeField]
	private float _yOffset; //Field offset: 0x148
	[SerializeField]
	private GameSoundPlayer _vehicleIdleSoundPlayer; //Field offset: 0x150
	[SerializeField]
	private GameSoundPlayer _vehicleEffectsSoundPlayer; //Field offset: 0x158
	[SerializeField]
	private GameSoundPlayer _vehicleMusicSoundPlayer; //Field offset: 0x160
	[SerializeField]
	private GameSoundPlayer _vehicleSirenSoundPlayer; //Field offset: 0x168
	[SerializeField]
	private float _safetyOffset; //Field offset: 0x170
	[SerializeField]
	private LevelDoor _booth; //Field offset: 0x178
	[SerializeField]
	private bool _hasDriversWindow; //Field offset: 0x180
	[SerializeField]
	private bool _canVehiclePark; //Field offset: 0x181
	[SerializeField]
	private bool _isArtFacingRight; //Field offset: 0x182
	[SerializeField]
	private SkeletonAnimation _siren; //Field offset: 0x188
	[SerializeField]
	private List<String> _radioStations; //Field offset: 0x190
	[SerializeField]
	private List<String> _sirensSounds; //Field offset: 0x198
	private bool _canDrag; //Field offset: 0x1A0
	private bool _isMoving; //Field offset: 0x1A1
	private bool _isPlayingDrivingIdleAnimation; //Field offset: 0x1A2
	private bool _isMovmentDirectionForward; //Field offset: 0x1A3
	private int _tweenID; //Field offset: 0x1A4
	private Vector2 _lastPointerPosition; //Field offset: 0x1A8
	private Nullable<Vector2> _lastMovementPosition; //Field offset: 0x1B0
	private float _movementAnchorX; //Field offset: 0x1BC
	private float _movementAnchorTime; //Field offset: 0x1C0
	private bool _isParked; //Field offset: 0x1C4
	private bool _isTweeningIntoParkingSpot; //Field offset: 0x1C5
	private int _currentParkingSpotIndex; //Field offset: 0x1C8
	private float _parkingTime; //Field offset: 0x1CC
	private Coroutine _parkingCoroutine; //Field offset: 0x1D0
	private float _minX; //Field offset: 0x1D8
	private float _maxX; //Field offset: 0x1DC
	private List<Vector2> _levelCrosswalks; //Field offset: 0x1E0
	private List<Int32> _currentCrosswalks; //Field offset: 0x1E8
	private float _yPosition; //Field offset: 0x1F0
	private float _backXPointOfCar; //Field offset: 0x1F4
	private float _frontXPointOfCar; //Field offset: 0x1F8
	private PDPrefab _pdPrefab; //Field offset: 0x200
	private float _defaultMinX; //Field offset: 0x208
	private float _defaultMaxX; //Field offset: 0x20C
	private bool _topSignState; //Field offset: 0x210
	private bool _headlightsState; //Field offset: 0x211
	private bool _frontdoorOpenState; //Field offset: 0x212
	private bool _centralDoorOpenState; //Field offset: 0x213
	private bool _backDoorOpenState; //Field offset: 0x214
	private bool _baggageDoorOpenState; //Field offset: 0x215
	private bool _windowsOpenState; //Field offset: 0x216
	private bool _wipersOnState; //Field offset: 0x217
	private int _currentRadioStationIndex; //Field offset: 0x218
	private int _sirenState; //Field offset: 0x21C
	public UnityEvent onCentralDoorOpenAction; //Field offset: 0x220
	public UnityEvent onVehicleBeginDragAction; //Field offset: 0x228
	public UnityEvent onVehicleEndDragAction; //Field offset: 0x230
	private bool _collidingWithOccupiedCrosswalk; //Field offset: 0x238
	private LevelCharacter _currentDriver; //Field offset: 0x240
	private CurrentVehicleDriveState _currentVehicleDriveState; //Field offset: 0x248
	[CompilerGenerated]
	private string <PrefabGuid>k__BackingField; //Field offset: 0x250
	private IVehiclePersistenceKey _persistenceKeyProvider; //Field offset: 0x258
	private Nullable<VehicleType> _vehicleType; //Field offset: 0x260
	private CarSpriteAnimator _spriteAnimator; //Field offset: 0x268

	public static event Action<LevelPlayerVehicle> OnVehicleBeginDragStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public static event Action<LevelPlayerVehicle> OnVehicleStoppedStaticAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	private bool HasSkeleton
	{
		private get { } //Length: 96
	}

	public bool IsMoving
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool IsMovmentDirectionForward
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool IsParked
	{
		 get { } //Length: 8
	}

	public CShape ItemShape
	{
		 get { } //Length: 8
	}

	public private string PrefabGuid
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public float RoadMaxX
	{
		 get { } //Length: 8
	}

	private static LevelPlayerVehicle() { }

	public LevelPlayerVehicle() { }

	[CompilerGenerated]
	public static void add_OnVehicleBeginDragStaticAction(Action<LevelPlayerVehicle> value) { }

	[CompilerGenerated]
	public static void add_OnVehicleStoppedStaticAction(Action<LevelPlayerVehicle> value) { }

	private TrackEntry AddVehicleAnimation(int trackIndex, string animationName, bool loop, float delay) { }

	protected virtual void Awake() { }

	private void BackDoorSetState(bool newState, bool isAnimate) { }

	private void BaggageDoorSetState(bool newState) { }

	private bool CanDrive() { }

	private void CentralDoorSetState(bool newState, bool isAnimate) { }

	private void CheckForCollisionWithCrossWalk() { }

	private void ClearVehicleAnimation(int trackIndex, float mixDuration) { }

	private void DoorSetState(int doorId, VehicleAnimationTracks track, bool newState, ref bool oldState, bool isAnimate, Action<TrackEntry> OnComplete = null) { }

	private void EnsureOnReadyPostLoad() { }

	public void FaceLeft() { }

	private void FixStartingPositionOnInit() { }

	public void FixStartingPositionOnSpawn() { }

	private void FrontDoorSetState(bool newState, bool isAnimate) { }

	private bool get_HasSkeleton() { }

	public bool get_IsMoving() { }

	public bool get_IsMovmentDirectionForward() { }

	public bool get_IsParked() { }

	public CShape get_ItemShape() { }

	[CompilerGenerated]
	public string get_PrefabGuid() { }

	public float get_RoadMaxX() { }

	private List<ILevelAvatar> GetAllRelevantAvatars() { }

	public ILevelAvatar GetDriver() { }

	private int GetForwardDirection() { }

	private void GetLevelData() { }

	public List<ILevelAvatar> GetPassengers() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public string GetVehicleBulkDataName() { }

	private bool HasVehicleAnimation(string animationName) { }

	public void HeadlightSetState(bool newState) { }

	public void Honk() { }

	private void Init() { }

	private bool IsCollisionWithLevelRoadBlocker(LevelRoadBlockAreaHandler roadBlocker) { }

	public bool IsOnAnyCrosswalk() { }

	public bool IsOnCrosswalk(int crosswalkIndex) { }

	public bool IsVehicleWithinBounds(Vector2 bounds) { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	public virtual void OnBeginDrag(PointerEventData eventData) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	private void OnCentralDoorOpen(TrackEntry trackEntry) { }

	protected virtual void OnDestroy() { }

	public virtual void OnDrag(PointerEventData eventData) { }

	public virtual void OnEndDrag(PointerEventData eventData) { }

	private void OnLevelPostInit() { }

	private void OnPostSaveProgress(Scene scene) { }

	public override void OnSpawnDuringGameplay() { }

	private void OnStopDriving() { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	private void OnWipersLoopEnd(TrackEntry trackEntry) { }

	private void PlaySound(GameSoundPlayer soundPlayer, string soundName, bool isLooping) { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrag.Multiplayer_PrepareForDrag() { }

	public void ReleaseAllCrossWalks() { }

	private void ReleaseParkingSpotIfOwned() { }

	[CompilerGenerated]
	public static void remove_OnVehicleBeginDragStaticAction(Action<LevelPlayerVehicle> value) { }

	[CompilerGenerated]
	public static void remove_OnVehicleStoppedStaticAction(Action<LevelPlayerVehicle> value) { }

	private void ResumeDraggingAfterLeavingParking() { }

	private void SaveBulkData(bool areAvatarsInScene = true, bool isARemoteCall = false) { }

	public void SaveData(bool areAvatarsInScene = false) { }

	public void set_IsMoving(bool value) { }

	public void set_IsMovmentDirectionForward(bool value) { }

	[CompilerGenerated]
	private void set_PrefabGuid(string value) { }

	private void SetMovementAnchor(float x) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetSirenSound() { }

	private TrackEntry SetVehicleAnimation(int trackIndex, string animationName, bool loop) { }

	public void StartEngine() { }

	private void StopMoving() { }

	private void StopSound(GameSoundPlayer soundPlayer) { }

	public void ToggleBackDoorState() { }

	public void ToggleBaggageDoorState() { }

	public void ToggleCentralDoorState() { }

	public void ToggleFrontDoorState() { }

	public void ToggleHeadlightState() { }

	public void ToggleRadioStation() { }

	public void ToggleSirenState() { }

	public void ToggleTopSignState() { }

	public void ToggleWindowsState() { }

	public void ToggleWipersState() { }

	public void TopSignSetState(bool newState) { }

	public bool TryGetPersistenceKey(out string persistenceKey) { }

	public bool TryGetVehicleType(out VehicleType vehicleType) { }

	private void UpdateDriverAnimationIfNeeded() { }

	private void UpdateIsMoving(float x) { }

	[IteratorStateMachine(typeof(<VerifyIfEnteringParking>d__129))]
	private IEnumerator VerifyIfEnteringParking() { }

	[IteratorStateMachine(typeof(<VerifyIfLeavingParking>d__130))]
	private IEnumerator VerifyIfLeavingParking() { }

	private void WindowsSetState(bool newState) { }

	private void WipersSetState(bool newState) { }

}

