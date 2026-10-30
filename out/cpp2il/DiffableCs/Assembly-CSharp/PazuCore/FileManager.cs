namespace PazuCore;

public class FileManager : MonoBehaviour
{
	[CompilerGenerated]
	private struct <>c__DisplayClass47_0
	{
		public bool useNamesList; //Field offset: 0x0
		public FileManager <>4__this; //Field offset: 0x8
		public string textureName; //Field offset: 0x10

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass50_0
	{
		public string textureName; //Field offset: 0x10
		public FileManager <>4__this; //Field offset: 0x18
		public Action<Texture2D> assign; //Field offset: 0x20
		public bool success; //Field offset: 0x28

		public <>c__DisplayClass50_0() { }

		internal void <TryLoadSharedTextureAsyncInternal>b__0(Texture2D texture) { }

		internal void <TryLoadSharedTextureAsyncInternal>b__1(Texture2D texture) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass56_0
	{
		public AudioClip audioClip; //Field offset: 0x10

		public <>c__DisplayClass56_0() { }

		internal void <TryLoadSharedAudioClip>b__0(AudioClip lAudioClip, Byte[] lBytes) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass64_0
	{
		public AudioClip audioClip; //Field offset: 0x10

		public <>c__DisplayClass64_0() { }

		internal void <TryLoadAudioClipInternal>b__0(AudioClip lAudioClip, Byte[] lBytes) { }

	}

	[CompilerGenerated]
	private sealed class <SaveSharedTextureAsync>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Byte[] textureBytes; //Field offset: 0x20
		public string textureName; //Field offset: 0x28
		public FileManager <>4__this; //Field offset: 0x30
		private string <path>5__2; //Field offset: 0x38

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
		public <SaveSharedTextureAsync>d__38(int <>1__state) { }

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
	private sealed class <TryLoadAudioClipInternal>d__64 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string fileName; //Field offset: 0x20
		public Action<AudioClip> assign; //Field offset: 0x28
		public FileManager <>4__this; //Field offset: 0x30
		private <>c__DisplayClass64_0 <>8__1; //Field offset: 0x38
		private string <path>5__2; //Field offset: 0x40

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
		public <TryLoadAudioClipInternal>d__64(int <>1__state) { }

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
	private sealed class <TryLoadSharedAudioClip>d__56 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string fileName; //Field offset: 0x20
		public Action<AudioClip> assign; //Field offset: 0x28
		public FileManager <>4__this; //Field offset: 0x30
		private <>c__DisplayClass56_0 <>8__1; //Field offset: 0x38
		private string <path>5__2; //Field offset: 0x40

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
		public <TryLoadSharedAudioClip>d__56(int <>1__state) { }

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
	private sealed class <TryLoadSharedTextureAsyncInternal>d__50 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string textureName; //Field offset: 0x20
		public FileManager <>4__this; //Field offset: 0x28
		public Action<Texture2D> assign; //Field offset: 0x30
		private <>c__DisplayClass50_0 <>8__1; //Field offset: 0x38
		private AsyncTextureRequest <existingRequest>5__2; //Field offset: 0x40
		private AsyncTextureRequest <newRequest>5__3; //Field offset: 0x48

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
		public <TryLoadSharedTextureAsyncInternal>d__50(int <>1__state) { }

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

	internal class AsyncTextureRequest
	{
		public bool isDone; //Field offset: 0x10

		public AsyncTextureRequest() { }

	}

	internal class NameList
	{
		public List<String> list; //Field offset: 0x10

		public NameList() { }

	}

	private const string PLAYERPREFS_KEY = "PazuCore_FilesList"; //Field offset: 0x0
	public static FileManager instance; //Field offset: 0x0
	private NameList _nameList; //Field offset: 0x20
	private string _folderPath; //Field offset: 0x28
	private string _sharedFolderPath; //Field offset: 0x30
	[CompilerGenerated]
	private bool <IsReady>k__BackingField; //Field offset: 0x38
	private readonly Dictionary<String, Texture2D> _cachedTextures; //Field offset: 0x40
	private readonly Dictionary<String, Texture2D> _cachedSharedTextures; //Field offset: 0x48
	private readonly Dictionary<String, String> _cachedTextureNames; //Field offset: 0x50
	private readonly Dictionary<String, String> _cachedSharedTextureNames; //Field offset: 0x58
	private readonly Dictionary<String, Boolean> _cachedFileExistsCheck; //Field offset: 0x60
	private readonly Dictionary<String, AsyncTextureRequest> _sharedTexturesAsyncLoadingInProgress; //Field offset: 0x68

	public private bool IsReady
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public FileManager() { }

	[CompilerGenerated]
	private void <TryLoadTexture>g__Onfailure|47_0(ref <>c__DisplayClass47_0 unnamed_param_0) { }

	public bool AudioClipExists(string fileName) { }

	private void Awake() { }

	private void ClearCachedTextures() { }

	public bool DeleteAudioClip(string fileName, bool logErrorIfNotExist = true) { }

	public bool DeleteSharedAudioClip(string fileName, bool logErrorIfNotExist = true) { }

	public bool DeleteSharedTextFile(string fileName, bool logErrorIfNotExist = true) { }

	public bool DeleteSharedTexture(string textureName, bool logErrorIfNotExist = true) { }

	public bool DeleteTextFile(string fileName, bool logErrorIfNotExist = true, bool isPrivateForAndroid = false) { }

	public bool DeleteTexture(string textureName, bool logErrorIfNotExist = true, bool useNamesList = true, bool isPrivateForAndroid = false) { }

	[CompilerGenerated]
	public bool get_IsReady() { }

	private string GetAudioClipPath(string fileName) { }

	public ReadOnlyCollection<String> GetFilesList() { }

	public string GetFolderPath() { }

	private string GetSharedAudioClipPath(string fileName) { }

	public string GetSharedFolderPath() { }

	public Sprite GetSharedSprite(string textureName) { }

	private string GetSharedTextFilePath(string fileName) { }

	private string GetSharedTexturePathFromName(string textureName) { }

	public Sprite GetSprite(string textureName) { }

	private string GetTextFilePath(string fileName, bool isPrivateForAndroid = false) { }

	private string GetTexturePathFromName(string textureName, bool isPrivateForAndroid = false) { }

	private void LoadFilesList() { }

	private void OnActiveSceneChanged(Scene fromScene, Scene toScene) { }

	private void OnDestroy() { }

	public void OnGameResume() { }

	private void OnLowMemory() { }

	public void RemoveSharedTextureFromMemory(string textureName, bool logErrorIfNotFound = true) { }

	public bool SaveAudioClip(string fileName, Byte[] data) { }

	private void SaveFileNamesToPlayerPrefs() { }

	public bool SaveSharedAudioClip(string fileName, Byte[] data) { }

	public bool SaveSharedTextFile(string fileName, string content) { }

	public void SaveSharedTexture(string textureName, Byte[] textureBytes, bool allowOverwrite = false) { }

	public void SaveSharedTexture(string textureName, Texture2D texture, bool allowOverwrite = false) { }

	[IteratorStateMachine(typeof(<SaveSharedTextureAsync>d__38))]
	public IEnumerator SaveSharedTextureAsync(string textureName, Byte[] textureBytes) { }

	public bool SaveTextFile(string fileName, string content, bool isPrivateForAndroid = false) { }

	public void SaveTexture(string textureName, Texture2D texture, bool allowOverwrite = false, bool useNamesList = true, bool isPrivateForAndroid = false) { }

	public void SaveTexture(string textureName, Byte[] textureBytes, bool allowOverwrite = false, bool useNamesList = true, bool isPrivateForAndroid = false) { }

	[CompilerGenerated]
	private void set_IsReady(bool value) { }

	private string SetPrivatePathIfNeeded(string path) { }

	public bool SharedTextureExists(string textureName) { }

	private void Start() { }

	public void StopAndDiscardAllAsyncOperations() { }

	public bool TextFileExists(string fileName) { }

	public bool TextureExists(string textureName, bool useNamesList = true, bool isPrivateForAndroid = false) { }

	private bool TextureFileExistsInternal(string path, bool isShared) { }

	public void TryLoadAudioClip(string textureName, Action<AudioClip> assign) { }

	[IteratorStateMachine(typeof(<TryLoadAudioClipInternal>d__64))]
	private IEnumerator TryLoadAudioClipInternal(string fileName, Action<AudioClip> assign) { }

	[IteratorStateMachine(typeof(<TryLoadSharedAudioClip>d__56))]
	public IEnumerator TryLoadSharedAudioClip(string fileName, Action<AudioClip> assign) { }

	public bool TryLoadSharedTextFile(string fileName, out string content) { }

	public bool TryLoadSharedTexture(string textureName, out Texture2D texture) { }

	public void TryLoadSharedTextureAsync(string textureName, Action<Texture2D> assign) { }

	[IteratorStateMachine(typeof(<TryLoadSharedTextureAsyncInternal>d__50))]
	private IEnumerator TryLoadSharedTextureAsyncInternal(string textureName, Action<Texture2D> assign) { }

	public bool TryLoadTextFile(string fileName, out string content, bool isPrivateForAndroid = false) { }

	public bool TryLoadTexture(string textureName, out Texture2D texture, bool useNamesList = true, bool isPrivateForAndroid = false) { }

}

