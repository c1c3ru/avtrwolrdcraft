namespace PWC.Level;

public class LevelSolveSecretWithAnimationOnDropAreaHandler : MonoBehaviour, ICanSolveSecrets, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private string _solvingAnimationName; //Field offset: 0x20
	[CompilerGenerated]
	private Action <OnSolvedSecretAction>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private Action <OnUnsolvedSecretAction>k__BackingField; //Field offset: 0x30
	private LevelDropArea _dropArea; //Field offset: 0x38
	private int _solvingAvatarID; //Field offset: 0x40

	public string AnimationName
	{
		 get { } //Length: 8
	}

	private bool IsSolved
	{
		private get { } //Length: 16
	}

	public override Action OnSolvedSecretAction
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override Action OnUnsolvedSecretAction
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelSolveSecretWithAnimationOnDropAreaHandler() { }

	private void Awake() { }

	public string get_AnimationName() { }

	private bool get_IsSolved() { }

	[CompilerGenerated]
	public override Action get_OnSolvedSecretAction() { }

	[CompilerGenerated]
	public override Action get_OnUnsolvedSecretAction() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnAnimationBeginHandler(LevelCAHandlerBase _, ICATarget target, LevelCAConfig config) { }

	private void OnAnimationEndHandler(LevelCAHandlerBase _, ICATarget target, LevelCAConfig config) { }

	private void OnDestroy() { }

	private void OnItemEndDropHandler(LevelDropArea dropArea, LevelItem levelItem) { }

	private void OnItemPickUpHandler(LevelDropArea dropArea, LevelItem levelItem) { }

	[CompilerGenerated]
	public override void set_OnSolvedSecretAction(Action value) { }

	[CompilerGenerated]
	public override void set_OnUnsolvedSecretAction(Action value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Solve(int avatarID) { }

	private void UnSolve() { }

}

