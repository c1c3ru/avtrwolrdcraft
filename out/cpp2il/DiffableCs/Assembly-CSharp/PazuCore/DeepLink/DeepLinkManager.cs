namespace PazuCore.DeepLink;

public class DeepLinkManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public Uri uri; //Field offset: 0x10

		public <>c__DisplayClass20_0() { }

		internal void <OnDeepLinkActivated>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <WaitForKeychainReady>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action aciton; //Field offset: 0x20

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
		public <WaitForKeychainReady>d__19(int <>1__state) { }

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

	internal class Data
	{
		public int gameId; //Field offset: 0x10
		public int pazucoreVersion; //Field offset: 0x14
		public int buildNumber; //Field offset: 0x18
		public AppContentData appContentData; //Field offset: 0x20

		public Data() { }

	}

	[CompilerGenerated]
	private static DeepLinkManager <Instance>k__BackingField; //Field offset: 0x0
	public const string BACKUP_DEEP_LINK_KEY = "PazuCore_Backup_Deep_Link"; //Field offset: 0x0
	public const string BACKUP_LINK_DATE_KEY = "PazuCore_Backup_Link_Date"; //Field offset: 0x0
	[CompilerGenerated]
	private static Func<AppContentData, Boolean> TryUseDeepLinkContentAction; //Field offset: 0x8
	public static Action OnBeforeGameLoadSceneAction; //Field offset: 0x10
	[CompilerGenerated]
	private AppContentData <LastContent>k__BackingField; //Field offset: 0x20
	[SerializeField]
	private SerializableDictionaryBase<String, LevelType> _mapLinkToLevel; //Field offset: 0x28

	public static event Func<AppContentData, Boolean> TryUseDeepLinkContentAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public private static DeepLinkManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private AppContentData LastContent
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public IDictionary<String, LevelType> MapLinkToLevel
	{
		 get { } //Length: 8
	}

	public DeepLinkManager() { }

	[CompilerGenerated]
	public static void add_TryUseDeepLinkContentAction(Func<AppContentData, Boolean> value) { }

	public string AddDataToUrl(string url, AppContentData appContentData) { }

	private void Awake() { }

	[CompilerGenerated]
	public static DeepLinkManager get_Instance() { }

	[CompilerGenerated]
	public AppContentData get_LastContent() { }

	public IDictionary<String, LevelType> get_MapLinkToLevel() { }

	public static bool InvokeDeepLinkContentAction(AppContentData content) { }

	private void OnDeepLinkActivated(string url) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_TryUseDeepLinkContentAction(Func<AppContentData, Boolean> value) { }

	[CompilerGenerated]
	private static void set_Instance(DeepLinkManager value) { }

	[CompilerGenerated]
	private void set_LastContent(AppContentData value) { }

	[IteratorStateMachine(typeof(<WaitForKeychainReady>d__19))]
	private IEnumerator WaitForKeychainReady(Action aciton) { }

}

