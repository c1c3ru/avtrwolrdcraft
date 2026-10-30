namespace PWC.Level;

public class LevelSolveSecretWithLabelOnDropAreaHandler : MonoBehaviour, ICanSolveSecrets
{
	[SerializeField]
	private string _solvingLabel; //Field offset: 0x20
	[CompilerGenerated]
	private Action <OnSolvedSecretAction>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private Action <OnUnsolvedSecretAction>k__BackingField; //Field offset: 0x30
	private LevelDropArea _dropArea; //Field offset: 0x38
	private bool _isSolved; //Field offset: 0x40

	public string Label
	{
		 get { } //Length: 8
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

	public LevelSolveSecretWithLabelOnDropAreaHandler() { }

	[CompilerGenerated]
	private bool <CheckIfAreaIsSolved>b__18_0(LevelItem item) { }

	private void Awake() { }

	private bool CheckIfAreaIsSolved() { }

	public string get_Label() { }

	[CompilerGenerated]
	public override Action get_OnSolvedSecretAction() { }

	[CompilerGenerated]
	public override Action get_OnUnsolvedSecretAction() { }

	private void OnDestroy() { }

	private void OnItemEndDropHandler(LevelItem item) { }

	private void OnItemPickUpHandler(LevelItem item) { }

	private void OnPostInitHandler() { }

	[CompilerGenerated]
	public override void set_OnSolvedSecretAction(Action value) { }

	[CompilerGenerated]
	public override void set_OnUnsolvedSecretAction(Action value) { }

}

