namespace PazuCore.PazuCoreAddressables.AFC.RD;

public abstract class AFCRDHandlerBase : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<AFCRDHandlerBase> OnRDHandlerCreatedAction; //Field offset: 0x0
	[SerializeField]
	private string _id; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onExecuteStart; //Field offset: 0x28
	[SerializeField]
	protected UnityEvent _onExecuteSuccess; //Field offset: 0x30
	[SerializeField]
	protected UnityEvent _onExecuteFailure; //Field offset: 0x38

	public static event Action<AFCRDHandlerBase> OnRDHandlerCreatedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public string ID
	{
		 get { } //Length: 8
	}

	protected AFCRDHandlerBase() { }

	[CompilerGenerated]
	public static void add_OnRDHandlerCreatedAction(Action<AFCRDHandlerBase> value) { }

	protected override void Awake() { }

	public void Execute() { }

	protected abstract void ExecuteImplement() { }

	public string get_ID() { }

	[CompilerGenerated]
	public static void remove_OnRDHandlerCreatedAction(Action<AFCRDHandlerBase> value) { }

}

