namespace Game.Level;

[AddComponentMenu(null)]
public class LevelTrainDriverCab : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IPointerClickHandler
{
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x20
	[SerializeField]
	private LevelTrain _train; //Field offset: 0x28

	public LevelTrainDriverCab() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

