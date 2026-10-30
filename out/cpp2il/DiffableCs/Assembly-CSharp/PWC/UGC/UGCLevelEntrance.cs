namespace PWC.UGC;

public class UGCLevelEntrance : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject, IWorldResettable
{
	internal enum LevelDefaultDataType
	{
		None = 0,
		Defalut = 1,
		Empty = 2,
	}

	internal class UGCLevelEntrancePD
	{
		public LevelType levelType; //Field offset: 0x10
		public LevelDefaultDataType levelDefaultDataType; //Field offset: 0x14
		public bool preventDeletion; //Field offset: 0x18
		public bool isUnique; //Field offset: 0x19

		public UGCLevelEntrancePD() { }

	}

	[SerializeField]
	private LevelType _levelType; //Field offset: 0x20
	[SerializeField]
	private LevelDefaultDataType _levelDefaultDataType; //Field offset: 0x24
	[SerializeField]
	private bool _preventDeletion; //Field offset: 0x28
	[SerializeField]
	private bool _isUnique; //Field offset: 0x29
	private UGCItemBase _ugcItem; //Field offset: 0x30
	private bool _syncedPreset; //Field offset: 0x38

	public UGCLevelEntrance() { }

	private void Awake() { }

	public void CanBeDeleted(ref bool canBeDeleted) { }

	public bool GetIsUnique() { }

	public TextAsset GetLevelDefaultDataAsset() { }

	public LevelType GetLevelType() { }

	public bool GetShouldPreventDeletion() { }

	private void OnDestroy() { }

	private void OnPreDestroyUGCEntity(UGCItemBase item) { }

	private void PerformClick() { }

	private override Dictionary<String, Object> PWC.PersistentData.IHasPersistentData.GetPersistentData() { }

	private override void PWC.PersistentData.IHasPersistentData.SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private override void PWC.World.Buildings.IWorldResettable.ResetWorldEntity() { }

	public void SetIsUnique(bool isUnique) { }

	public void SetLevelType(LevelType levelType) { }

	public void SetShouldPreventDeletion(bool preventDeletion) { }

	private bool ShouldAllowResetLevel() { }

	public bool ShouldPreventDeletion() { }

	private void Start() { }

	private bool TryGetSceneId(out string sceneId) { }

	private override void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

}

