namespace Game.Level;

public class LevelEggHatcheryItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public LevelEggHatcheryItemHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass17_0() { }

		internal void <TurnOnHatcheryIfNeeded>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public LevelEggHatcheryItemHandler <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass18_0() { }

		internal void <FinishEarly>b__0() { }

	}

	[SerializeField]
	private LevelLight _incubator; //Field offset: 0x20
	[SerializeField]
	private LevelLight _hatcheryLamp; //Field offset: 0x28
	[SerializeField]
	private LevelDropArea _eggDropArea; //Field offset: 0x30
	[SerializeField]
	private int _timeToHatch; //Field offset: 0x38
	private DateTime _endingTime; //Field offset: 0x40
	private bool _hasPersistentData; //Field offset: 0x48
	private LevelPetEggItemHandler _currentEgg; //Field offset: 0x50
	private bool _didOnReadyPostLoad; //Field offset: 0x58

	public LevelEggHatcheryItemHandler() { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	private void FinishEarly(LevelItem levelItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnEggTimerDone(LevelItem levelItem) { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	public override void OnSpawnDuringGameplay() { }

	private void OnTimePassed(TimeOfDay day) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void TurnOnHatcheryIfNeeded(LevelItem levelItem, bool fromDrop) { }

}

