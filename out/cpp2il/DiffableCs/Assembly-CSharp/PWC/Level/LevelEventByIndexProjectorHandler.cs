namespace PWC.Level;

public class LevelEventByIndexProjectorHandler : MonoBehaviour
{
	private class EventByIndex
	{
		public int Index; //Field offset: 0x10
		public UnityEvent OnPictureByIndexSet; //Field offset: 0x18

		public EventByIndex() { }

	}

	[SerializeField]
	private LevelProjector _projector; //Field offset: 0x20
	[SerializeField]
	private List<EventByIndex> _eventsByIndex; //Field offset: 0x28

	public LevelEventByIndexProjectorHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void TriggerAtIndex(int index) { }

}

