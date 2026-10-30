namespace PazuCore;

public class AndroidKeycainManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Start>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AndroidKeycainManager <>4__this; //Field offset: 0x20
		private AndroidJavaObject <keychainApiInstance>5__2; //Field offset: 0x28
		private String[] <>7__wrap2; //Field offset: 0x30
		private int <>7__wrap3; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__14(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private static AndroidKeycainManager <Instance>k__BackingField; //Field offset: 0x0
	private const string HAVE_DATA = "v2_PazuCore_AndroidKeychain_HaveData"; //Field offset: 0x0
	private AndroidJavaObject _keychainApiInstance; //Field offset: 0x20
	private bool _getDataResult; //Field offset: 0x28
	[CompilerGenerated]
	private bool <IsReady>k__BackingField; //Field offset: 0x29
	private string temporaryGetPackage; //Field offset: 0x30
	private bool _haveData; //Field offset: 0x38

	public private static AndroidKeycainManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private bool IsReady
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public AndroidKeycainManager() { }

	[CompilerGenerated]
	private bool <Start>b__14_0() { }

	private void Awake() { }

	public void CanGetDataFromExternalApp(string packageName) { }

	public bool DeleteKey(string key) { }

	[CompilerGenerated]
	public static AndroidKeycainManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsReady() { }

	private AndroidJavaObject GetKeychainApiInstance() { }

	public string GetString(string key) { }

	public string GetStringFromExternalApp(string key, string fromPackageName) { }

	private void OnDestroy() { }

	public void OnGetAllData(string success) { }

	[CompilerGenerated]
	private static void set_Instance(AndroidKeycainManager value) { }

	[CompilerGenerated]
	private void set_IsReady(bool value) { }

	public bool SetString(string key, string value) { }

	[IteratorStateMachine(typeof(<Start>d__14))]
	private IEnumerator Start() { }

}

