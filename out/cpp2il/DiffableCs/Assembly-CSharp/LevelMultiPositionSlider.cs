//Type is in global namespace

public class LevelMultiPositionSlider : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelMultiPositionSlider <>4__this; //Field offset: 0x10
		public int amountMoved; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <MoveLoop>b__0() { }

	}

	[SerializeField]
	private GameObject _movingObject; //Field offset: 0x20
	[SerializeField]
	private Vector3[] _pointsToMove; //Field offset: 0x28
	[SerializeField]
	private float _time; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onMovementEnd; //Field offset: 0x38
	private bool _isMoving; //Field offset: 0x40
	[HideInInspector]
	public int CurrentPointIndex; //Field offset: 0x44

	public LevelMultiPositionSlider() { }

	[CompilerGenerated]
	private void <Move>b__6_0() { }

	public int GetMaxMoves() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void Move() { }

	private void MoveLoop(int amountMoved) { }

	public void MoveUntilFinishedLoop() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

