namespace Game.Level;

public class LevelFoodFightDropAreaHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private PDPrefabReference _goo; //Field offset: 0x20
	[SerializeField]
	private LevelCharactersOnlyDropArea _dropArea; //Field offset: 0x28
	private bool _isActive; //Field offset: 0x30

	public LevelFoodFightDropAreaHandler() { }

	private void Awake() { }

	private void DropGoo(LevelItem levelItem) { }

	public void EnableFight() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitGoo(LevelItem levelItem) { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SpawnAndThrowGoo(LevelItem levelItem) { }

}

