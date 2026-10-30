namespace PWC.Level;

public class LevelDropAreaDragActionLabelTargetHandler : MonoBehaviour, ILevelDragActionLabelTarget, ICanSolveSecrets
{
	[SerializeField]
	private string _label; //Field offset: 0x20
	public Action onRightTargetEnter; //Field offset: 0x28
	private LevelConsumerAreaBase _consumer; //Field offset: 0x30
	[CompilerGenerated]
	private Action <OnSolvedSecretAction>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private Action <OnUnsolvedSecretAction>k__BackingField; //Field offset: 0x40

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

	public LevelDropAreaDragActionLabelTargetHandler() { }

	private void Awake() { }

	[CompilerGenerated]
	public override Action get_OnSolvedSecretAction() { }

	[CompilerGenerated]
	public override Action get_OnUnsolvedSecretAction() { }

	public override void OnEnter(string label) { }

	public override void OnExit(string label) { }

	[CompilerGenerated]
	public override void set_OnSolvedSecretAction(Action value) { }

	[CompilerGenerated]
	public override void set_OnUnsolvedSecretAction(Action value) { }

}

