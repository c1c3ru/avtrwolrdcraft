namespace Game.Level;

public class LevelSequenceListener : MonoBehaviour
{
	private class IntArrayWrapper
	{
		public Int32[] Values; //Field offset: 0x10

		public IntArrayWrapper() { }

	}

	public List<UnityEvent> _events; //Field offset: 0x20
	[SerializeField]
	private List<IntArrayWrapper> Sequences; //Field offset: 0x28
	private bool _wasInit; //Field offset: 0x30
	private Int32[] _indexes; //Field offset: 0x38
	private Int32[] _solvedSequences; //Field offset: 0x40

	public LevelSequenceListener() { }

	private void Awake() { }

	public void GetInput(int inputIndex) { }

	public Dictionary<String, Object> GetPersistentData() { }

	public void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

