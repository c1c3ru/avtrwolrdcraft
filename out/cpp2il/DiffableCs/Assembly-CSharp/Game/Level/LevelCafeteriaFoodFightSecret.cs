namespace Game.Level;

public class LevelCafeteriaFoodFightSecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	protected LevelDropArea[] _toys; //Field offset: 0x20
	[SerializeField]
	private LevelFoodFightDropAreaHandler _foodFightArea; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _hatSpriteRenderer; //Field offset: 0x30
	[SerializeField]
	private Sprite _openHatSprite; //Field offset: 0x38
	[SerializeField]
	private GameObject _button; //Field offset: 0x40
	private bool _isUnlocked; //Field offset: 0x48

	public LevelCafeteriaFoodFightSecret() { }

	private void Awake() { }

	private void CheckIfUnlocked(LevelItem levelItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OpenHat() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UnlockFoodFight() { }

}

