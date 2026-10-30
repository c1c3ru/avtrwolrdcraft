namespace Game.Level;

public class LevelCheckIfThereAreAvatarsInScene : MonoBehaviour
{
	[SerializeField]
	[Tooltip("If empty, all avatar types are checked.")]
	private List<SpineType> _avatarTypesToCheck; //Field offset: 0x20
	[SerializeField]
	private UnityEvent OnNoAvatarsInSceneChangedAction; //Field offset: 0x28

	public LevelCheckIfThereAreAvatarsInScene() { }

	public bool AreAvatarsInScene() { }

	private void Awake() { }

	private void CheckAvatars() { }

	private bool IsActiveInScene(ILevelAvatar avatar) { }

	private bool MatchesFilter(ILevelAvatar avatar) { }

	private void OnDestroy() { }

}

