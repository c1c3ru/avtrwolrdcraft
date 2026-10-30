namespace Game.Level;

public class LevelSafePermutationSprite : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IHasPersistentData, IRequirePDSceneObject
{
	public static Action OnSafePermutationClickAction; //Field offset: 0x0
	[SerializeField]
	private int _targetNumber; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _renderer; //Field offset: 0x28
	[SerializeField]
	private Sprite[] _sprites; //Field offset: 0x30
	[SerializeField]
	private string _soundName; //Field offset: 0x38
	private int _number; //Field offset: 0x40

	public LevelSafePermutationSprite() { }

	public int GetNumber() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void Init() { }

	public bool IsTargetNumber() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

