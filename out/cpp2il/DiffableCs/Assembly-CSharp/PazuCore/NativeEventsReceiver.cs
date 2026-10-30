namespace PazuCore;

public class NativeEventsReceiver : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Boolean> <>9__18_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnAppstoreClosed>b__18_0(bool success) { }

	}

	internal enum NetworkStatus
	{
		None = 0,
		NotReachable = 1,
		ReachableViaWWAN = 2,
		ReachableViaWiFi = 3,
	}

	public static Action<String> OnPurchaseSucceededAction; //Field offset: 0x0
	public static Action<String, String> OnPurchaseFailedAction; //Field offset: 0x8
	public static Action<String> OnPurchaseCanceledAction; //Field offset: 0x10
	public static Action OnRestoreSucceededAction; //Field offset: 0x18
	public static Action<String> OnRestoreFailedAction; //Field offset: 0x20
	public static Action<NetworkStatus> OnReachabilityChangedAction; //Field offset: 0x28
	[CompilerGenerated]
	private static NativeEventsReceiver <Instance>k__BackingField; //Field offset: 0x30

	public private static NativeEventsReceiver Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public NativeEventsReceiver() { }

	private void Awake() { }

	[CompilerGenerated]
	public static NativeEventsReceiver get_Instance() { }

	public void OnAppstoreClosed(string message) { }

	public void OnOpenAppstoreFallback(string gameID) { }

	public void OnPurchaseCanceled(string productId) { }

	public void OnPurchaseFailed(string message) { }

	public void OnPurchaseSucceeded(string productId) { }

	public void OnReachabilityChanged(string message) { }

	public void OnRestoreFailed(string message) { }

	public void OnRestoreSucceeded(string message) { }

	[CompilerGenerated]
	private static void set_Instance(NativeEventsReceiver value) { }

}

