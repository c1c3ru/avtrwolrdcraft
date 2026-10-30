namespace Game.Level.WaterSlide;

public class LevelPhotoCollectorFromSlideCamera : MonoBehaviour
{
	[SerializeField]
	private List<SecretFullId> _ItemsToAddToSlide; //Field offset: 0x20
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x28
	[SerializeField]
	private LevelSpawn _prefab; //Field offset: 0x30
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x38
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x40
	private readonly List<String> _allTextureCollection; //Field offset: 0x48
	private int _currentTextureIndex; //Field offset: 0x50

	public LevelPhotoCollectorFromSlideCamera() { }

	private void Awake() { }

	private void InitLoadPhotosIfNeeded() { }

	public void LeftPhoto() { }

	private void LoadTextureToScreen(string textureName) { }

	private void OnDestroy() { }

	private void OnPostInit() { }

	public void PrintPhoto() { }

	public void RightPhoto() { }

}

