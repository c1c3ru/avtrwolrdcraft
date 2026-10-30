namespace PWC.Level.Maker;

public class LevelMakerDestroyButtenEventHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onClickEvent; //Field offset: 0x20

	public LevelMakerDestroyButtenEventHandler() { }

	private void Awake() { }

	private void OnClickMakerItemDestroyButton(ILevelMakerDeletableByUIItem _) { }

	private void OnDestroy() { }

}

