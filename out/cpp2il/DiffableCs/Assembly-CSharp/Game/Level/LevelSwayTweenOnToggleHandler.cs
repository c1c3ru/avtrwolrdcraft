namespace Game.Level;

public class LevelSwayTweenOnToggleHandler : MonoBehaviour
{
	[SerializeField]
	private int _onIndex; //Field offset: 0x20
	[SerializeField]
	private float _moveDistance; //Field offset: 0x24
	[SerializeField]
	private float _duration; //Field offset: 0x28
	private LevelToggleableGameObject _toggleableGameObject; //Field offset: 0x30
	private DragDropItemBase _item; //Field offset: 0x38
	private int _tweenId; //Field offset: 0x40
	private Vector3 _basePosition; //Field offset: 0x44

	public LevelSwayTweenOnToggleHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnInteractionInterrupt(DragDropItemBase item, PointerEventData eventData) { }

	private void OnToggleClick(int index) { }

	private void StartTween() { }

	private void StopTween() { }

}

