namespace PWC.Level;

public class LevelCeilingSortingArea : MonoBehaviour
{
	private static List<LevelCeilingSortingArea> _levelCeilingSortingAreas; //Field offset: 0x0
	private CShape _cshape; //Field offset: 0x20
	private GameShape _gameShape; //Field offset: 0x28

	private static LevelCeilingSortingArea() { }

	public LevelCeilingSortingArea() { }

	private void Awake() { }

	private float GetMaxX() { }

	private float GetMinX() { }

	public static LevelCeilingSortingArea GetSortingOffsetForX(float x) { }

	private void OnDisable() { }

	private void OnEnable() { }

}

