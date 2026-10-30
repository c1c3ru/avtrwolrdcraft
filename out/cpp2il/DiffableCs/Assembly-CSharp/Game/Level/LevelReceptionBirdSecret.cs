namespace Game.Level;

public class LevelReceptionBirdSecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelSimpleSpawner _spawner; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x28
	private bool _disposed; //Field offset: 0x30

	public LevelReceptionBirdSecret() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnBirdPickUp(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

