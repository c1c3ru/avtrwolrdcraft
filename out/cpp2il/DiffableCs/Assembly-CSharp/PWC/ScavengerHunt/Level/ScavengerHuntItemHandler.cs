namespace PWC.ScavengerHunt.Level;

public class ScavengerHuntItemHandler : MonoBehaviour, ILevelSpawnDuringGameplay, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private bool _isItemToSearchFor; //Field offset: 0x20
	[SerializeField]
	private ScavengerHuntType _scavengerHuntType; //Field offset: 0x24
	private ScavengerHuntTypeHandler _handler; //Field offset: 0x28
	private bool _didInit; //Field offset: 0x30
	private string _gameGuid; //Field offset: 0x38
	private LevelItem _levelItem; //Field offset: 0x40
	[CompilerGenerated]
	private int <SpawnerID>k__BackingField; //Field offset: 0x48

	public bool IsItemToSearchFor
	{
		 get { } //Length: 8
	}

	public ScavengerHuntType MyScavengerHuntType
	{
		 get { } //Length: 8
	}

	public int SpawnerID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public ScavengerHuntItemHandler() { }

	private void Awake() { }

	private void DestroyThisItem(bool withVanishEffect) { }

	public bool get_IsItemToSearchFor() { }

	public ScavengerHuntType get_MyScavengerHuntType() { }

	[CompilerGenerated]
	public int get_SpawnerID() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitIfNeeded() { }

	private void OnDestroy() { }

	private void OnGameCompleted() { }

	private void OnItemBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnLevelPrePostInit() { }

	private void OnTimeUp() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	[CompilerGenerated]
	public void set_SpawnerID(int value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetTypeHandler(ScavengerHuntTypeHandler handler) { }

}

