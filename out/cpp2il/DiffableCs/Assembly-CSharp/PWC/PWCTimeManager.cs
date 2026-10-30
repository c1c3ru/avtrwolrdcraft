namespace PWC;

public class PWCTimeManager : MonoBehaviour
{
	[CompilerGenerated]
	private static PWCTimeManager <Instance>k__BackingField; //Field offset: 0x0
	private float _unscaledTimeOnLastSync; //Field offset: 0x20
	private long _serverTimeOnLastSync; //Field offset: 0x28
	private long _localTimeOnLastSync; //Field offset: 0x30
	[CompilerGenerated]
	private bool <IsDataValid>k__BackingField; //Field offset: 0x38

	public private static PWCTimeManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private bool IsDataValid
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public PWCTimeManager() { }

	private void Awake() { }

	[CompilerGenerated]
	public static PWCTimeManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsDataValid() { }

	private long GetUnscaledTimeDelta() { }

	private void OnApplicationPause(bool pause) { }

	private void OnDestroy() { }

	private void OnUserSync(SyncType syncType) { }

	[CompilerGenerated]
	private static void set_Instance(PWCTimeManager value) { }

	[CompilerGenerated]
	private void set_IsDataValid(bool value) { }

	public bool TryGetLocalTime(out long serverTime) { }

	public bool TryGetLocalTime(long timeBase, out long serverTime) { }

	public bool TryGetServerTime(out long serverTime) { }

}

