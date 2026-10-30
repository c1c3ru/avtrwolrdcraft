namespace Game.Level;

public class LevelCafetariaWallSecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected LevelChangeColorOnClick[] _items; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _gift; //Field offset: 0x28
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onSpawnAction; //Field offset: 0x38
	private bool _isGiftSpawned; //Field offset: 0x40

	public LevelCafetariaWallSecret() { }

	private void Awake() { }

	private void CheckOnRightColor(Color _) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SpawnGift() { }

}

