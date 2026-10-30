namespace Game.Level;

public class LevelSecretAvatarAnimationWithExampleAvatarSolvedListener : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	[Tooltip("When true, the first avatar to play a solving animation becomes the leader, regardless of _exampleAvatarID.")]
	private bool _anyAvatarCanLead; //Field offset: 0x20
	[SerializeField]
	private int _exampleAvatarID; //Field offset: 0x24
	[SerializeField]
	private String[] _SolvingAnimationNames; //Field offset: 0x28
	[SerializeField]
	private int _numberOfFollowers; //Field offset: 0x30
	[SerializeField]
	private bool _canSolveMoreThanOnce; //Field offset: 0x34
	[SerializeField]
	private UnityEvent _onSecretSolvedEvent; //Field offset: 0x38
	[SerializeField]
	[Tooltip("Fired when the leader's solving animation ends or is interrupted.")]
	private UnityEvent _onLeaderAnimationEndEvent; //Field offset: 0x40
	[SerializeField]
	private bool _leaderEndOnlyWhenSolved; //Field offset: 0x48
	private bool _isSolved; //Field offset: 0x49
	private ILevelAvatar _currentActiveLeader; //Field offset: 0x50
	private List<ILevelAvatar> _cachedFollowers; //Field offset: 0x58

	public LevelSecretAvatarAnimationWithExampleAvatarSolvedListener() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private bool IsAnimationCorrect(ILevelAvatar avatar) { }

	private bool IsLeader(ILevelAvatar avatar) { }

	private void OnAnimationBeganInLevel(ICATarget target, LevelCAConfig config, string fullAnimationName) { }

	private void OnAnimationEndedInLevel(ICATarget target, LevelCAConfig config, string fullAnimationName) { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

