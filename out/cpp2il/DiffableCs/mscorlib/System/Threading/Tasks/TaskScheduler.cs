namespace System.Threading.Tasks;

[DebuggerDisplay("Id={Id}")]
[DebuggerTypeProxy(typeof(SystemThreadingTasks_TaskSchedulerDebugView))]
public abstract class TaskScheduler
{
	public sealed class SystemThreadingTasks_TaskSchedulerDebugView
	{

	}

	private static ConditionalWeakTable<TaskScheduler, Object> s_activeTaskSchedulers; //Field offset: 0x0
	private static readonly TaskScheduler s_defaultTaskScheduler; //Field offset: 0x8
	internal static int s_taskSchedulerIdCounter; //Field offset: 0x10
	private static EventHandler<UnobservedTaskExceptionEventArgs> _unobservedTaskException; //Field offset: 0x18
	private static readonly Lock _unobservedTaskExceptionLockObject; //Field offset: 0x20
	private int m_taskSchedulerId; //Field offset: 0x10

	public static TaskScheduler Current
	{
		 get { } //Length: 160
	}

	public static TaskScheduler Default
	{
		 get { } //Length: 88
	}

	public int Id
	{
		 get { } //Length: 148
	}

	internal static TaskScheduler InternalCurrent
	{
		internal get { } //Length: 164
	}

	internal override bool RequiresAtomicStartTransition
	{
		internal get { } //Length: 8
	}

	private static TaskScheduler() { }

	protected TaskScheduler() { }

	public static TaskScheduler FromCurrentSynchronizationContext() { }

	public static TaskScheduler get_Current() { }

	public static TaskScheduler get_Default() { }

	public int get_Id() { }

	internal static TaskScheduler get_InternalCurrent() { }

	internal override bool get_RequiresAtomicStartTransition() { }

	internal override void NotifyWorkItemProgress() { }

	internal static void PublishUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs ueea) { }

	protected private abstract void QueueTask(Task task) { }

	protected private override bool TryDequeue(Task task) { }

	protected bool TryExecuteTask(Task task) { }

	protected abstract bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) { }

	internal bool TryRunInline(Task task, bool taskWasPreviouslyQueued) { }

}

