namespace Game.Level;

public class LevelHanoiTowerItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public int tempId; //Field offset: 0x10
		public LevelHanoiTowerItemHandler <>4__this; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <EnsureOnReadyPostLoad>b__0(LevelItem x) { }

		internal void <EnsureOnReadyPostLoad>b__1(LevelItem x) { }

	}

	[SerializeField]
	private LevelDropArea[] _dropAreas; //Field offset: 0x20
	[SerializeField]
	private Int32[] _solvingCondition; //Field offset: 0x28
	[SerializeField]
	private int _indexPositionInNameOfItem; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onGiveGift; //Field offset: 0x38
	private Int32[] _ringsInPlaces; //Field offset: 0x40
	private bool _isGiftTaken; //Field offset: 0x48
	private Action<LevelItem>[] _endDropFunctions; //Field offset: 0x50
	private Action<LevelItem>[] _pickUpFunctions; //Field offset: 0x58

	public LevelHanoiTowerItemHandler() { }

	private void Awake() { }

	private bool CheckIsSolved() { }

	private void DropArea_OnItemEndDropAction(int dropAreaId, int ringId) { }

	private void DropArea_OnItemPickUpAction(int dropAreaId) { }

	private void EnableDropArea(int index) { }

	private void EnsureOnReadyPostLoad() { }

	private int GetIndexOfRing(string nameOfRing) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void GiveGift() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetRingsItemState(int index) { }

}

