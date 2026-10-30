namespace Game.Level;

public class LevelIceCreamItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	private const string BASE_SPRITES_RESOURCES_PATH_PREFIX = "Food_IceCream/"; //Field offset: 0x0
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private LevelRuntimeColoredSpriteHandler _runtimeColoredSpriteHandler; //Field offset: 0x28
	[SerializeField]
	private LevelRuntimeColoredSpriteHandler _runtimeMultiColoredSpriteHandler; //Field offset: 0x30
	private SpriteRenderer _spriteRenderer; //Field offset: 0x38
	private string _spriteName; //Field offset: 0x40

	public LevelIceCreamItemHandler() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public Color GetSpriteColor() { }

	private void GetSpriteName() { }

	private void OnDestroy() { }

	private void OnLevelPositInit() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SetSprite(Sprite sprite) { }

	public void SetSpriteColor(Color color) { }

	public void SetSpriteMultiColor(Color color) { }

}

