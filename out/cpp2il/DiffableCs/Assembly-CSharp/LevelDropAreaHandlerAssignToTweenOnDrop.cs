//Type is in global namespace

public class LevelDropAreaHandlerAssignToTweenOnDrop : MonoBehaviour
{
	[SerializeField]
	private LevelDropArea _refDropArea; //Field offset: 0x20
	[SerializeField]
	private AFCTweenBase[] _refTween; //Field offset: 0x28

	public LevelDropAreaHandlerAssignToTweenOnDrop() { }

	private void AssignTweenTarget(LevelItem item) { }

	private void Awake() { }

	private void OnDestroy() { }

	private void UnAssignTweenTarget(LevelItem item) { }

}

