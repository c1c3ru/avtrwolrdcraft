namespace PazuCore;

public class AndroidFileManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Converter<Byte, SByte> <>9__24_1; //Field offset: 0x8
		public static Converter<Byte, SByte> <>9__27_0; //Field offset: 0x10
		public static Converter<Byte, SByte> <>9__28_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal sbyte <SaveFileText>b__27_0(byte b) { }

		internal sbyte <SaveTextureBytes>b__28_0(byte b) { }

		internal sbyte <SaveTextureBytesAsync>b__24_1(byte b) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public AndroidTextureLoader androidTextureLoader; //Field offset: 0x10

		public <>c__DisplayClass22_0() { }

		internal bool <GetTexture2DAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public AndroidFileSaver androidFileSaver; //Field offset: 0x10

		public <>c__DisplayClass24_0() { }

		internal bool <SaveTextureBytesAsync>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <GetTexture2DAsync>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AndroidFileManager <>4__this; //Field offset: 0x20
		public string textureName; //Field offset: 0x28
		public Action<Texture2D> onGetTextureAction; //Field offset: 0x30
		private <>c__DisplayClass22_0 <>8__1; //Field offset: 0x38
		private string <uri>5__2; //Field offset: 0x40
		private UnityWebRequest <webRequest>5__3; //Field offset: 0x48

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
		public <GetTexture2DAsync>d__22(int <>1__state) { }

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
	private sealed class <SaveTextureBytesAsync>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AndroidFileManager <>4__this; //Field offset: 0x20
		public string textureName; //Field offset: 0x28
		public Byte[] fileBytes; //Field offset: 0x30
		private <>c__DisplayClass24_0 <>8__1; //Field offset: 0x38

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
		public <SaveTextureBytesAsync>d__24(int <>1__state) { }

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

	private class AndroidFileSaver
	{
		public AndroidJavaObject saver; //Field offset: 0x10
		public bool isSucceeded; //Field offset: 0x18
		public bool isSavingFinished; //Field offset: 0x19

		public AndroidFileSaver() { }

	}

	private class AndroidTextureLoader
	{
		public AndroidJavaObject loader; //Field offset: 0x10
		public Texture2D texture; //Field offset: 0x18
		public Action<Texture2D> action; //Field offset: 0x20
		public bool isLoaded; //Field offset: 0x28

		public AndroidTextureLoader() { }

	}

	[CompilerGenerated]
	private static AndroidFileManager <Instance>k__BackingField; //Field offset: 0x0
	private const string SAVE_PACAKAGE = "PazuCore_AndroidFile_SavePackage"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnChangedSavingFilesAppsPackageAction; //Field offset: 0x8
	private string _savingFilesAppsPackage; //Field offset: 0x20
	private string _folderPath; //Field offset: 0x28
	[CompilerGenerated]
	private string <PrivateFolderPath>k__BackingField; //Field offset: 0x30
	private Dictionary<String, AndroidTextureLoader> _loadingTexturesQueue; //Field offset: 0x38
	private Dictionary<String, AndroidFileSaver> _savingFilesQueue; //Field offset: 0x40

	public static event Action OnChangedSavingFilesAppsPackageAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public private static AndroidFileManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private string PrivateFolderPath
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public AndroidFileManager() { }

	[CompilerGenerated]
	private bool <OnGameResume>b__19_0(string package) { }

	[CompilerGenerated]
	public static void add_OnChangedSavingFilesAppsPackageAction(Action value) { }

	private void Awake() { }

	private string CreateTextFilePathFromName(string fileName) { }

	private string CreateTexturePathFromName(string textureName) { }

	public bool DeleteFile(string fileName, bool logErrorIfNotExist = true) { }

	private bool DeleteFileFromExternalApp(string fileName) { }

	private bool FileExistsInExternalApp(string fileName) { }

	[CompilerGenerated]
	public static AndroidFileManager get_Instance() { }

	[CompilerGenerated]
	public string get_PrivateFolderPath() { }

	private string GetAndroidFilesDir() { }

	private string GetSavingFilesAppPackageIfExists() { }

	public string GetText(string fileName) { }

	private string GetTextFromExternalApp(string fileName) { }

	public Texture2D GetTexture2D(string textureName) { }

	[IteratorStateMachine(typeof(<GetTexture2DAsync>d__22))]
	public IEnumerator GetTexture2DAsync(string textureName, Action<Texture2D> onGetTextureAction) { }

	private Byte[] GetTextureBytesFromExternalApp(string fileName) { }

	public void OnAsyncFileSaved(string fileName) { }

	public void OnAsyncTextureLoaded(string textureName) { }

	public void OnGameResume() { }

	[CompilerGenerated]
	public static void remove_OnChangedSavingFilesAppsPackageAction(Action value) { }

	private void SaveFileBytesToExternalApp(string fileName, SByte[] fileBytes) { }

	public void SaveFileText(string fileName, string text) { }

	public void SaveTextureBytes(string textureName, Byte[] fileBytes) { }

	[IteratorStateMachine(typeof(<SaveTextureBytesAsync>d__24))]
	public IEnumerator SaveTextureBytesAsync(string textureName, Byte[] fileBytes) { }

	[CompilerGenerated]
	private static void set_Instance(AndroidFileManager value) { }

	[CompilerGenerated]
	private void set_PrivateFolderPath(string value) { }

	public bool TextFileExists(string fileName) { }

	public bool TextureExists(string textureName) { }

}

