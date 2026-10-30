namespace PWC.Level.Maker;

public class LevelMakerItemMakerModeChangeHandler : MonoBehaviour
{
	[SerializeField]
	protected GameObject[] _inMakerModeObjects; //Field offset: 0x20
	[SerializeField]
	protected GameObject[] _notInMakerModeObjects; //Field offset: 0x28
	[SerializeField]
	protected Behaviour[] _inMakerModeBehaviours; //Field offset: 0x30
	[SerializeField]
	protected Behaviour[] _notInMakerModeBehaviours; //Field offset: 0x38
	private LevelMakerItem _levelMakerItem; //Field offset: 0x40

	public LevelMakerItemMakerModeChangeHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnEnterMakerMode() { }

	private void OnExitMakerMode() { }

	private void OnModeChange(bool inMakerMode) { }

}

