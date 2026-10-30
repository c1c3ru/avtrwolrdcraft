namespace Game.Level;

public class LevelZiplineSeatMoveArea : MonoBehaviour
{
	[SerializeField]
	private LevelZiplineSeatBezierGroup[] _bezierGroups; //Field offset: 0x20
	private LevelZiplineSeatBezierGroupData[] _groups; //Field offset: 0x28

	public LevelZiplineSeatMoveArea() { }

	private void Awake() { }

	private void CreateGroupDataList() { }

	public float EvaluateYPosition(float xPosition) { }

}

