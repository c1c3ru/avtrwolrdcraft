namespace Game.Level.WaterSlide;

public class LevelAllItemsFaceTheSameDirectionSecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	private enum Direction
	{
		Right = 0,
		Left = 1,
		Both = 2,
	}

	[SerializeField]
	private LevelFlipOnClick[] _itemsList; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onSolvedAction; //Field offset: 0x28
	[SerializeField]
	private Direction _direction; //Field offset: 0x30
	private bool _isSolved; //Field offset: 0x34

	public LevelAllItemsFaceTheSameDirectionSecret() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InvokeEventIfSolved() { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

