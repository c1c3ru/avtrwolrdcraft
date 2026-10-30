namespace PWC;

public class GameCameraScrollArea : MonoBehaviour
{
	[SerializeField]
	private GameCameraBezierGroup[] _bezierGroups; //Field offset: 0x20
	private GameCameraBezierGroupData[] _groups; //Field offset: 0x28

	public GameCameraScrollArea() { }

	private void Awake() { }

	private void CreateGroupDataList() { }

	public float EvaluateYPosition(float xPosition) { }

}

