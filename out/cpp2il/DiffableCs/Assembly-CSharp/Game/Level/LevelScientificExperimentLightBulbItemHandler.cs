namespace Game.Level;

public class LevelScientificExperimentLightBulbItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _light; //Field offset: 0x28

	public LevelScientificExperimentLightBulbItemHandler() { }

	private void Awake() { }

	private void OnBeginDrag(DragDropItemBase _, PointerEventData __) { }

	private void OnDestroy() { }

	public void TurnOff() { }

	public void TurnOn(Color color) { }

}

