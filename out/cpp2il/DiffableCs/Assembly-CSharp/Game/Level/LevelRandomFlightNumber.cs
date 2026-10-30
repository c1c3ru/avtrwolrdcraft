namespace Game.Level;

public class LevelRandomFlightNumber : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	protected TextMesh _textMesh; //Field offset: 0x20
	private string _flightNumber; //Field offset: 0x28
	private CShape _cShape; //Field offset: 0x30

	public LevelRandomFlightNumber() { }

	private void Awake() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void PerformClick() { }

}

