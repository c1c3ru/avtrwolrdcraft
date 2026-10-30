namespace PWC.Level;

public class LevelBabyDropAreaHandler : MonoBehaviour
{
	[SerializeField]
	private float _angle; //Field offset: 0x20
	[SerializeField]
	private Vector2 _position; //Field offset: 0x24
	private LevelSingleItemDropArea _dropArea; //Field offset: 0x30

	public LevelBabyDropAreaHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void SetRotationAndPosition(LevelItem levelItem) { }

}

