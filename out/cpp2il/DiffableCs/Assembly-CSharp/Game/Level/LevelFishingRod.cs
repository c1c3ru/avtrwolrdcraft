namespace Game.Level;

public class LevelFishingRod : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	internal enum StateType
	{
		Idle = 0,
		StartingFishing = 1,
		IdleFishing = 2,
		EndingFishing = 3,
		IdleFishingWithoutBait = 4,
	}

	[SerializeField]
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0x60
	[SerializeField]
	protected LevelFishingRodBaitArea _baitArea; //Field offset: 0x68
	[SerializeField]
	protected Transform _targetSpawnPoint; //Field offset: 0x70
	[SerializeField]
	protected LevelWaterArea _waterArea; //Field offset: 0x78
	[SerializeField]
	private float _waterYPosition; //Field offset: 0x80
	[SerializeField]
	protected GameSoundPlayer _gameSoundPlayer; //Field offset: 0x88
	private StateType _currentState; //Field offset: 0x90

	public StateType CurrentState
	{
		 get { } //Length: 8
	}

	public LevelWaterArea MyWaterArea
	{
		 get { } //Length: 8
	}

	public float WaterYPosition
	{
		 get { } //Length: 8
	}

	public LevelFishingRod() { }

	[CompilerGenerated]
	private void <EndFishing>b__25_0(TrackEntry _) { }

	[CompilerGenerated]
	private void <Fishing>b__24_2(TrackEntry x) { }

	[CompilerGenerated]
	private void <Fishing>b__24_3(TrackEntry x) { }

	[CompilerGenerated]
	private void <Fishing>g__PlayCaughtSignals|24_0() { }

	[CompilerGenerated]
	private void <Fishing>g__PlayIdleInWater|24_1() { }

	[CompilerGenerated]
	private void <StartFishing>b__21_0(TrackEntry x) { }

	[CompilerGenerated]
	private void <TryFishTarget>b__23_0() { }

	[CompilerGenerated]
	private void <TryFishTarget>b__23_1(TrackEntry x_) { }

	protected virtual void Awake() { }

	private void EndFishing() { }

	private void Fishing() { }

	public StateType get_CurrentState() { }

	public LevelWaterArea get_MyWaterArea() { }

	public float get_WaterYPosition() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitWater() { }

	private void OnBaitEndDrop(LevelItem levelItem) { }

	private void OnBaitPickUp(LevelItem levelItem) { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void PrepareBaitForFishingIfExists() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void StartFishing() { }

	private bool TryCreateTarget() { }

	private void TryFishTarget() { }

}

