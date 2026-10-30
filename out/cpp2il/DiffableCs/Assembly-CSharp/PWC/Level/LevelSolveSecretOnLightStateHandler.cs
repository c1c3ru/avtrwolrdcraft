namespace PWC.Level;

public class LevelSolveSecretOnLightStateHandler : MonoBehaviour, ICanSolveSecrets
{
	[SerializeField]
	private bool _solveOnLightOn; //Field offset: 0x20
	private LevelLight _levelLight; //Field offset: 0x28
	[CompilerGenerated]
	private Action <OnSolvedSecretAction>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private Action <OnUnsolvedSecretAction>k__BackingField; //Field offset: 0x38

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

	public LevelSolveSecretOnLightStateHandler() { }

	private void Awake() { }

	[CompilerGenerated]
	public override Action get_OnSolvedSecretAction() { }

	[CompilerGenerated]
	public override Action get_OnUnsolvedSecretAction() { }

	private void OnDestroy() { }

	private void OnLampClickHandler(bool isOn) { }

	[CompilerGenerated]
	public override void set_OnSolvedSecretAction(Action value) { }

	[CompilerGenerated]
	public override void set_OnUnsolvedSecretAction(Action value) { }

}

