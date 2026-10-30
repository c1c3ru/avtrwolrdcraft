namespace PWC.AWCloud;

public class AWEnsureCloudUser : MonoBehaviour
{
	[CompilerGenerated]
	private static AWEnsureCloudUser <Instance>k__BackingField; //Field offset: 0x0
	private bool _didCallRestorePurchases; //Field offset: 0x20
	private Action _action; //Field offset: 0x28
	private bool _isInProgress; //Field offset: 0x30

	public private static AWEnsureCloudUser Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public AWEnsureCloudUser() { }

	private void Awake() { }

	public static void EnsureCloudUserAndPerformAction(Action action) { }

	private void EnsureCloudUserAndPerformAction_Internal(Action action) { }

	[CompilerGenerated]
	public static AWEnsureCloudUser get_Instance() { }

	private void OnDestroy() { }

	private void OnIAPEnded(IAPResult result) { }

	[CompilerGenerated]
	private static void set_Instance(AWEnsureCloudUser value) { }

}

