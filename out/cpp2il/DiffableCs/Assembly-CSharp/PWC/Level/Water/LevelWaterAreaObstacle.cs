namespace PWC.Level.Water;

public class LevelWaterAreaObstacle : MonoBehaviour
{
	public static readonly List<LevelWaterAreaObstacle> All; //Field offset: 0x0
	[SerializeField]
	private CShape _cShape; //Field offset: 0x20

	private static LevelWaterAreaObstacle() { }

	public LevelWaterAreaObstacle() { }

	private void Awake() { }

	public CShape GetCShape() { }

	private void OnDestroy() { }

}

