namespace Game.Level;

public class LevelActivateItemByIndexFromGlobalData : MonoBehaviour
{
	[SerializeField]
	private GameObject[] _objects; //Field offset: 0x20
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x28
	[SerializeField]
	private string _dataName; //Field offset: 0x30

	public LevelActivateItemByIndexFromGlobalData() { }

	private void ActivateItemByIndexFromGlobalData() { }

	private void Awake() { }

	private void OnDestroy() { }

}

