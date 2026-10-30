namespace PWC.Level;

public class LevelEventByIndexToggleableSpriteHandler : MonoBehaviour
{
	private class EventByIndex
	{
		public int Index; //Field offset: 0x10
		public UnityEvent OnSpriteByIndexSet; //Field offset: 0x18

		public EventByIndex() { }

	}

	[SerializeField]
	private LevelToggleableSprite _toggleableSprite; //Field offset: 0x20
	[SerializeField]
	private List<EventByIndex> _eventsByIndex; //Field offset: 0x28
	[SerializeField]
	private bool _triggerOnClick; //Field offset: 0x30
	[SerializeField]
	private bool _triggerOnSpriteSet; //Field offset: 0x31

	public LevelEventByIndexToggleableSpriteHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void TriggerAtIndex(int index) { }

}

