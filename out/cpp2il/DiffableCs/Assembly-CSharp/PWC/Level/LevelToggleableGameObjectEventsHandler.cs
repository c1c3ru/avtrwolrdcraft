namespace PWC.Level;

public class LevelToggleableGameObjectEventsHandler : MonoBehaviour
{
	internal struct IndexEvent
	{
		public int Index; //Field offset: 0x0
		public UnityEvent OnIndexChanged; //Field offset: 0x8

	}

	[SerializeField]
	private LevelToggleableGameObject _toggleableGameObject; //Field offset: 0x20
	[SerializeField]
	private List<IndexEvent> _indexEvents; //Field offset: 0x28
	[SerializeField]
	private bool _checkOnLoad; //Field offset: 0x30

	public LevelToggleableGameObjectEventsHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnIndexChanged(int index) { }

}

