namespace Game.Level;

public class LevelCookieCarpet : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SpriteRenderer _renderer; //Field offset: 0x20
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x28
	[SerializeField]
	private GameObject _giftBlocker; //Field offset: 0x30
	private int _index; //Field offset: 0x38
	private bool _giftTaken; //Field offset: 0x3C

	public LevelCookieCarpet() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void GiveGift() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UpdateSpriteOnLanding() { }

}

