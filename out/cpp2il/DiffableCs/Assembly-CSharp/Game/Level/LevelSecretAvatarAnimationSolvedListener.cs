namespace Game.Level;

public class LevelSecretAvatarAnimationSolvedListener : ConditionResolverComponent, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private String[] _SolvingData; //Field offset: 0x28
	[SerializeField]
	private bool _canSolveMoreThanOnce; //Field offset: 0x30
	[SerializeField]
	private bool _speciefcAvatarOnly; //Field offset: 0x31
	[ConditionalField("_speciefcAvatarOnly", True, True, (array) null)]
	[SerializeField]
	private int _avatarID; //Field offset: 0x34
	[SerializeField]
	public UnityEvent onSecretSolvedEvent; //Field offset: 0x38
	[SerializeField]
	public UnityEvent onSecretUnsolvedEvent; //Field offset: 0x40
	private Dictionary<Int32, List`1<String>> _avatars; //Field offset: 0x48
	private bool _isSolved; //Field offset: 0x50

	public LevelSecretAvatarAnimationSolvedListener() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnSecretSolved(ICATarget target, LevelCAConfig config, string fullAnimationName) { }

	private void OnSecretUnsolved(ICATarget target, LevelCAConfig config, string fullAnimationName) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

