namespace Game.Level;

public class LevelXrayDisplay : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _XrayDropArea; //Field offset: 0x28
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x30
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x38
	private bool _isOn; //Field offset: 0x40

	public LevelXrayDisplay() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnXrayPhotoEndDrop(LevelItem levelItem) { }

	private void OnXrayPhotoPickUp(LevelItem levelItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

