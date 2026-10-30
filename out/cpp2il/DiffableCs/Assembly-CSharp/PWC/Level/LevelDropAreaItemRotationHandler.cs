namespace PWC.Level;

[RequireComponent(typeof(LevelDropArea))]
public class LevelDropAreaItemRotationHandler : MonoBehaviour
{
	[SerializeField]
	private float _angle; //Field offset: 0x20
	[SerializeField]
	private float _rotateDuration; //Field offset: 0x24
	private LevelDropArea _dropArea; //Field offset: 0x28

	public LevelDropAreaItemRotationHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemBeginDrop(LevelItem levelItem) { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void SetRotation(LevelItem levelItem) { }

}

