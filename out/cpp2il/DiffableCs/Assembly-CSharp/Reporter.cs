//Type is in global namespace

public class Reporter : MonoBehaviour
{
	internal enum _LogType
	{
		Assert = 1,
		Error = 0,
		Exception = 4,
		Log = 3,
		Warning = 2,
	}

	[CompilerGenerated]
	private sealed class <readInfo>d__188 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Reporter <>4__this; //Field offset: 0x20
		private UnityWebRequest <www>5__2; //Field offset: 0x28

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
		public <readInfo>d__188(int <>1__state) { }

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

	private enum DetailView
	{
		None = 0,
		StackTrace = 1,
		Graph = 2,
	}

	internal class Log
	{
		public int count; //Field offset: 0x10
		public _LogType logType; //Field offset: 0x14
		public string condition; //Field offset: 0x18
		public string stacktrace; //Field offset: 0x20
		public int sampleId; //Field offset: 0x28

		public Log() { }

		public Log CreateCopy() { }

		public float GetMemoryUsage() { }

	}

	private enum ReportView
	{
		None = 0,
		Logs = 1,
		Info = 2,
		Snapshot = 3,
	}

	internal class Sample
	{
		public float time; //Field offset: 0x10
		public byte loadedScene; //Field offset: 0x14
		public float memory; //Field offset: 0x18
		public float fps; //Field offset: 0x1C
		public string fpsText; //Field offset: 0x20

		public Sample() { }

		public string GetSceneName() { }

		public static float MemSize() { }

	}

	private const float updateInterval = 0,25; //Field offset: 0x0
	private static bool created; //Field offset: 0x0
	private const int requiredFrames = 10; //Field offset: 0x0
	private static String[] scenes; //Field offset: 0x8
	private List<Sample> samples; //Field offset: 0x20
	private List<Log> logs; //Field offset: 0x28
	private List<Log> collapsedLogs; //Field offset: 0x30
	private List<Log> currentLog; //Field offset: 0x38
	private MultiKeyDictionary<String, String, Log> logsDic; //Field offset: 0x40
	private Dictionary<String, String> cachedString; //Field offset: 0x48
	[HideInInspector]
	public bool show; //Field offset: 0x50
	private bool collapse; //Field offset: 0x51
	private bool clearOnNewSceneLoaded; //Field offset: 0x52
	private bool showTime; //Field offset: 0x53
	private bool showScene; //Field offset: 0x54
	private bool showMemory; //Field offset: 0x55
	private bool showFps; //Field offset: 0x56
	private bool showGraph; //Field offset: 0x57
	private bool showLog; //Field offset: 0x58
	private bool showWarning; //Field offset: 0x59
	private bool showError; //Field offset: 0x5A
	private int numOfLogs; //Field offset: 0x5C
	private int numOfLogsWarning; //Field offset: 0x60
	private int numOfLogsError; //Field offset: 0x64
	private int numOfCollapsedLogs; //Field offset: 0x68
	private int numOfCollapsedLogsWarning; //Field offset: 0x6C
	private int numOfCollapsedLogsError; //Field offset: 0x70
	private bool showClearOnNewSceneLoadedButton; //Field offset: 0x74
	private bool showTimeButton; //Field offset: 0x75
	private bool showSceneButton; //Field offset: 0x76
	private bool showMemButton; //Field offset: 0x77
	private bool showFpsButton; //Field offset: 0x78
	private bool showSearchText; //Field offset: 0x79
	private bool showCopyButton; //Field offset: 0x7A
	private bool showSaveButton; //Field offset: 0x7B
	private string buildDate; //Field offset: 0x80
	private string logDate; //Field offset: 0x88
	private float logsMemUsage; //Field offset: 0x90
	private float graphMemUsage; //Field offset: 0x94
	private float gcTotalMemory; //Field offset: 0x98
	public string UserData; //Field offset: 0xA0
	public float fps; //Field offset: 0xA8
	public string fpsText; //Field offset: 0xB0
	private ReportView currentView; //Field offset: 0xB8
	public Images images; //Field offset: 0xC0
	private GUIContent clearContent; //Field offset: 0xC8
	private GUIContent collapseContent; //Field offset: 0xD0
	private GUIContent clearOnNewSceneContent; //Field offset: 0xD8
	private GUIContent showTimeContent; //Field offset: 0xE0
	private GUIContent showSceneContent; //Field offset: 0xE8
	private GUIContent userContent; //Field offset: 0xF0
	private GUIContent showMemoryContent; //Field offset: 0xF8
	private GUIContent softwareContent; //Field offset: 0x100
	private GUIContent dateContent; //Field offset: 0x108
	private GUIContent showFpsContent; //Field offset: 0x110
	private GUIContent infoContent; //Field offset: 0x118
	private GUIContent saveLogsContent; //Field offset: 0x120
	private GUIContent searchContent; //Field offset: 0x128
	private GUIContent copyContent; //Field offset: 0x130
	private GUIContent closeContent; //Field offset: 0x138
	private GUIContent buildFromContent; //Field offset: 0x140
	private GUIContent systemInfoContent; //Field offset: 0x148
	private GUIContent graphicsInfoContent; //Field offset: 0x150
	private GUIContent backContent; //Field offset: 0x158
	private GUIContent logContent; //Field offset: 0x160
	private GUIContent warningContent; //Field offset: 0x168
	private GUIContent errorContent; //Field offset: 0x170
	private GUIStyle barStyle; //Field offset: 0x178
	private GUIStyle buttonActiveStyle; //Field offset: 0x180
	private GUIStyle nonStyle; //Field offset: 0x188
	private GUIStyle lowerLeftFontStyle; //Field offset: 0x190
	private GUIStyle backStyle; //Field offset: 0x198
	private GUIStyle evenLogStyle; //Field offset: 0x1A0
	private GUIStyle oddLogStyle; //Field offset: 0x1A8
	private GUIStyle logButtonStyle; //Field offset: 0x1B0
	private GUIStyle selectedLogStyle; //Field offset: 0x1B8
	private GUIStyle selectedLogFontStyle; //Field offset: 0x1C0
	private GUIStyle stackLabelStyle; //Field offset: 0x1C8
	private GUIStyle scrollerStyle; //Field offset: 0x1D0
	private GUIStyle searchStyle; //Field offset: 0x1D8
	private GUIStyle sliderBackStyle; //Field offset: 0x1E0
	private GUIStyle sliderThumbStyle; //Field offset: 0x1E8
	private GUISkin toolbarScrollerSkin; //Field offset: 0x1F0
	private GUISkin logScrollerSkin; //Field offset: 0x1F8
	private GUISkin graphScrollerSkin; //Field offset: 0x200
	public Vector2 size; //Field offset: 0x208
	public float maxSize; //Field offset: 0x210
	public int numOfCircleToShow; //Field offset: 0x214
	private string currentScene; //Field offset: 0x218
	private string filterText; //Field offset: 0x220
	private string deviceModel; //Field offset: 0x228
	private string deviceType; //Field offset: 0x230
	private string deviceName; //Field offset: 0x238
	private string graphicsMemorySize; //Field offset: 0x240
	private string maxTextureSize; //Field offset: 0x248
	private string systemMemorySize; //Field offset: 0x250
	public bool Initialized; //Field offset: 0x258
	private Rect screenRect; //Field offset: 0x25C
	private Rect toolBarRect; //Field offset: 0x26C
	private Rect logsRect; //Field offset: 0x27C
	private Rect stackRect; //Field offset: 0x28C
	private Rect graphRect; //Field offset: 0x29C
	private Rect graphMinRect; //Field offset: 0x2AC
	private Rect graphMaxRect; //Field offset: 0x2BC
	private Rect buttomRect; //Field offset: 0x2CC
	private Vector2 stackRectTopLeft; //Field offset: 0x2DC
	private Rect detailRect; //Field offset: 0x2E4
	private Vector2 scrollPosition; //Field offset: 0x2F4
	private Vector2 scrollPosition2; //Field offset: 0x2FC
	private Vector2 toolbarScrollPosition; //Field offset: 0x304
	private Log selectedLog; //Field offset: 0x310
	private float toolbarOldDrag; //Field offset: 0x318
	private float oldDrag; //Field offset: 0x31C
	private float oldDrag2; //Field offset: 0x320
	private float oldDrag3; //Field offset: 0x324
	private int startIndex; //Field offset: 0x328
	private Rect countRect; //Field offset: 0x32C
	private Rect timeRect; //Field offset: 0x33C
	private Rect timeLabelRect; //Field offset: 0x34C
	private Rect sceneRect; //Field offset: 0x35C
	private Rect sceneLabelRect; //Field offset: 0x36C
	private Rect memoryRect; //Field offset: 0x37C
	private Rect memoryLabelRect; //Field offset: 0x38C
	private Rect fpsRect; //Field offset: 0x39C
	private Rect fpsLabelRect; //Field offset: 0x3AC
	private GUIContent tempContent; //Field offset: 0x3C0
	private Vector2 infoScrollPosition; //Field offset: 0x3C8
	private Vector2 oldInfoDrag; //Field offset: 0x3D0
	private Rect tempRect; //Field offset: 0x3D8
	private float graphSize; //Field offset: 0x3E8
	private int startFrame; //Field offset: 0x3EC
	private int currentFrame; //Field offset: 0x3F0
	private Vector3 tempVector1; //Field offset: 0x3F4
	private Vector3 tempVector2; //Field offset: 0x400
	private Vector2 graphScrollerPos; //Field offset: 0x40C
	private float maxFpsValue; //Field offset: 0x414
	private float minFpsValue; //Field offset: 0x418
	private float maxMemoryValue; //Field offset: 0x41C
	private float minMemoryValue; //Field offset: 0x420
	private List<Vector2> gestureDetector; //Field offset: 0x428
	private Vector2 gestureSum; //Field offset: 0x430
	private float gestureLength; //Field offset: 0x438
	private int gestureCount; //Field offset: 0x43C
	private float lastClickTime; //Field offset: 0x440
	private Vector2 startPos; //Field offset: 0x444
	private Vector2 downPos; //Field offset: 0x44C
	private Vector2 mousePosition; //Field offset: 0x454
	private int frames; //Field offset: 0x45C
	private bool firstTime; //Field offset: 0x460
	private float lastUpdate; //Field offset: 0x464
	private List<Log> threadedLogs; //Field offset: 0x468

	public float TotalMemUsage
	{
		 get { } //Length: 12
	}

	private void _OnLevelWasLoaded(Scene _null1, LoadSceneMode _null2) { }

	public Reporter() { }

	private void AddLog(string condition, string stacktrace, LogType type) { }

	private void addSample() { }

	private void Awake() { }

	private void calculateCurrentLog() { }

	private void calculateStartIndex() { }

	private void CaptureLog(string condition, string stacktrace, LogType type) { }

	private void CaptureLogThread(string condition, string stacktrace, LogType type) { }

	private void clear() { }

	private void doShow() { }

	private void drawGraph() { }

	private void DrawInfo() { }

	private void drawInfo_enableDisableToolBarButtons() { }

	private void DrawLogs() { }

	private void DrawReport() { }

	private void drawStack() { }

	private void drawToolBar() { }

	public float get_TotalMemUsage() { }

	private Vector2 getDownPos() { }

	private Vector2 getDrag() { }

	public void Initialize() { }

	private void initializeStyle() { }

	private bool isDoubleClickDone() { }

	private bool isGestureDone() { }

	private void OnApplicationQuit() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void OnGUIDraw() { }

	[IteratorStateMachine(typeof(<readInfo>d__188))]
	private IEnumerator readInfo() { }

	private void SaveLogsToDevice() { }

	private void Start() { }

	private void Update() { }

}

