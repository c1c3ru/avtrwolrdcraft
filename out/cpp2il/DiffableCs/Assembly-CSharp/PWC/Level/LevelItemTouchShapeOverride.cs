namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelItemTouchShapeOverride : MonoBehaviour
{
	[SerializeField]
	private CShape _cShape; //Field offset: 0x20

	public LevelItemTouchShapeOverride() { }

	public CShape GetCShape() { }

}

