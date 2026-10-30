namespace Game.Level;

public class LevelFairyTreeDoor : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onDoorOpen; //Field offset: 0x28
	private int _litMushroomsCounter; //Field offset: 0x30
	private bool _isAnimatingShake; //Field offset: 0x34

	public LevelFairyTreeDoor() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__8_0() { }

	private void AnimateIfNeeded(bool isSnap = false) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnFairyTreeMushroomClick(bool isOn) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

