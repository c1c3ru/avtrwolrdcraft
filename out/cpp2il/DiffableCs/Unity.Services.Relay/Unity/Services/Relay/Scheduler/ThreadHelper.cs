namespace Unity.Services.Relay.Scheduler;

internal static class ThreadHelper
{
	private static SynchronizationContext _unitySynchronizationContext; //Field offset: 0x0
	private static TaskScheduler _taskScheduler; //Field offset: 0x8
	private static int _mainThreadId; //Field offset: 0x10

	public static int MainThreadId
	{
		 get { } //Length: 72
	}

	public static SynchronizationContext SynchronizationContext
	{
		 get { } //Length: 72
	}

	public static TaskScheduler TaskScheduler
	{
		 get { } //Length: 72
	}

	public static int get_MainThreadId() { }

	public static SynchronizationContext get_SynchronizationContext() { }

	public static TaskScheduler get_TaskScheduler() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	public static void Init() { }

}

