namespace Game.Level;

public class LevelClassroomBoard : MonoBehaviour
{
	[SerializeField]
	private LevelPaintableArea _paintableArea; //Field offset: 0x20
	[SerializeField]
	private Texture2D[] _textures; //Field offset: 0x28

	public LevelClassroomBoard() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

}

