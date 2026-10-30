namespace Game.Level;

public class LevelEggCabinet : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, IPointerClickHandler, IEventSystemHandler
{
	internal enum EggStateType
	{
		None = 0,
		Closed = 1,
		Half = 2,
		Empty = 3,
		Open = 4,
	}

	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private GameObject _dropAreaObject; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onEggCabinetOpenedEvent; //Field offset: 0x30
	private string SPRITE_PATH_PREFIX; //Field offset: 0x38
	private bool _isAnimatingShake; //Field offset: 0x40
	private EggStateType _stateType; //Field offset: 0x44
	private SpriteRenderer _spriteRenderer; //Field offset: 0x48

	public LevelEggCabinet() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__9_0() { }

	private void Awake() { }

	private void EnableDropAreaIfOpen() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void PlaySound() { }

	private void SetNewSpriteFromResources() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UpdatedStateTypeIfNeeded() { }

}

