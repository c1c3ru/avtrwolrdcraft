namespace PWC.Level;

public class LevelSolveSecretWithSkinOnDropAreaHandler : MonoBehaviour, ICanSolveSecrets, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public string skinName; //Field offset: 0x10

		public <>c__DisplayClass17_0() { }

		internal bool <IsCharacterWearingSkin>b__0(KeyValuePair<Int32, String> kvp) { }

	}

	[SerializeField]
	private String[] _solvingSkinNames; //Field offset: 0x20
	[CompilerGenerated]
	private Action <OnSolvedSecretAction>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private Action <OnUnsolvedSecretAction>k__BackingField; //Field offset: 0x30
	private LevelDropArea _dropArea; //Field offset: 0x38
	private int _solvingCharacterID; //Field offset: 0x40

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

	public LevelSolveSecretWithSkinOnDropAreaHandler() { }

	private void Awake() { }

	private bool get_IsSolved() { }

	[CompilerGenerated]
	public override Action get_OnSolvedSecretAction() { }

	[CompilerGenerated]
	public override Action get_OnUnsolvedSecretAction() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private bool IsCharacterWearingSkin(LevelCharacter character) { }

	private void OnDestroy() { }

	private void OnItemEndDropHandler(LevelItem item) { }

	private void OnItemPickUpHandler(LevelItem item) { }

	private void OnPostInitHandler() { }

	[CompilerGenerated]
	public override void set_OnSolvedSecretAction(Action value) { }

	[CompilerGenerated]
	public override void set_OnUnsolvedSecretAction(Action value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

