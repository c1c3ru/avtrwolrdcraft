namespace System.Threading.Tasks;

[DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}")]
[DebuggerTypeProxy(typeof(SystemThreadingTasks_TaskDebugView))]
public class Task : IThreadPoolWorkItem, IAsyncResult, IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Object> <>9__247_0; //Field offset: 0x8
		public static TimerCallback <>9__247_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal ContingentProperties <.cctor>b__271_0() { }

		internal bool <.cctor>b__271_1(Task t) { }

		internal bool <.cctor>b__271_2(object tc) { }

		internal void <Delay>b__247_0(object state) { }

		internal void <Delay>b__247_1(object state) { }

	}

	public class ContingentProperties
	{
		internal ExecutionContext m_capturedContext; //Field offset: 0x10
		internal ManualResetEventSlim m_completionEvent; //Field offset: 0x18
		internal TaskExceptionHolder m_exceptionsHolder; //Field offset: 0x20
		internal CancellationToken m_cancellationToken; //Field offset: 0x28
		internal object m_cancellationRegistration; //Field offset: 0x30
		internal int m_internalCancellationRequested; //Field offset: 0x38
		internal int m_completionCountdown; //Field offset: 0x3C
		internal LowLevelListWithIList<Task> m_exceptionalChildren; //Field offset: 0x40

		public ContingentProperties() { }

		internal void SetCompleted() { }

		internal void UnregisterCancellationCallback() { }

	}

	private sealed class DelayPromise : Task<VoidTaskResult>
	{
		internal readonly CancellationToken Token; //Field offset: 0x58
		internal CancellationTokenRegistration Registration; //Field offset: 0x60
		internal Timer Timer; //Field offset: 0x78

		internal DelayPromise(CancellationToken token) { }

		internal void Complete() { }

	}

	private sealed class SetOnCountdownMres : ManualResetEventSlim, ITaskCompletionAction
	{
		private int _count; //Field offset: 0x24

		public override bool InvokeMayRunArbitraryCode
		{
			 get { } //Length: 8
		}

		internal SetOnCountdownMres(int count) { }

		public override bool get_InvokeMayRunArbitraryCode() { }

		public override void Invoke(Task completingTask) { }

	}

	private sealed class SetOnInvokeMres : ManualResetEventSlim, ITaskCompletionAction
	{

		public override bool InvokeMayRunArbitraryCode
		{
			 get { } //Length: 8
		}

		internal SetOnInvokeMres() { }

		public override bool get_InvokeMayRunArbitraryCode() { }

		public override void Invoke(Task completingTask) { }

	}

	private sealed class WhenAllPromise : Task<T[]>, ITaskCompletionAction
	{
		private readonly Task<T>[] m_tasks; //Field offset: 0x0
		private int m_count; //Field offset: 0x0

		public override bool InvokeMayRunArbitraryCode
		{
			 get { } //Length: 8
		}

		internal virtual bool ShouldNotifyDebuggerOfWaitCompletion
		{
			internal get { } //Length: 132
		}

		internal WhenAllPromise`1(Task<T>[] tasks) { }

		public override bool get_InvokeMayRunArbitraryCode() { }

		internal virtual bool get_ShouldNotifyDebuggerOfWaitCompletion() { }

		public override void Invoke(Task ignored) { }

	}

	[ThreadStatic]
	internal static Task t_currentTask; //Field offset: 0x80000000
	[ThreadStatic]
	private static StackGuard t_stackGuard; //Field offset: 0x80000008
	internal static int s_taskIdCounter; //Field offset: 0x0
	private const int CANCELLATION_REQUESTED = 1; //Field offset: 0x0
	private const int TASK_STATE_COMPLETED_MASK = 23068672; //Field offset: 0x0
	internal const int TASK_STATE_WAIT_COMPLETION_NOTIFICATION = 268435456; //Field offset: 0x0
	internal const int TASK_STATE_THREAD_WAS_ABORTED = 134217728; //Field offset: 0x0
	internal const int TASK_STATE_WAITINGFORACTIVATION = 33554432; //Field offset: 0x0
	internal const int TASK_STATE_RAN_TO_COMPLETION = 16777216; //Field offset: 0x0
	internal const int TASK_STATE_WAITING_ON_CHILDREN = 8388608; //Field offset: 0x0
	internal const int TASK_STATE_CANCELED = 4194304; //Field offset: 0x0
	internal const int TASK_STATE_FAULTED = 2097152; //Field offset: 0x0
	internal const int TASK_STATE_COMPLETION_RESERVED = 67108864; //Field offset: 0x0
	internal const int TASK_STATE_EXCEPTIONOBSERVEDBYPARENT = 524288; //Field offset: 0x0
	internal const int TASK_STATE_DISPOSED = 262144; //Field offset: 0x0
	internal const int TASK_STATE_DELEGATE_INVOKED = 131072; //Field offset: 0x0
	internal const int TASK_STATE_STARTED = 65536; //Field offset: 0x0
	private const int OptionsMask = 65535; //Field offset: 0x0
	internal const int TASK_STATE_CANCELLATIONACKNOWLEDGED = 1048576; //Field offset: 0x0
	private static readonly object s_taskCompletionSentinel; //Field offset: 0x8
	internal static bool s_asyncDebuggingEnabled; //Field offset: 0x10
	private static readonly Action<Object> s_taskCancelCallback; //Field offset: 0x18
	private static readonly Func<ContingentProperties> s_createContingentProperties; //Field offset: 0x20
	[CompilerGenerated]
	private static readonly TaskFactory <Factory>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private static readonly Task <CompletedTask>k__BackingField; //Field offset: 0x30
	private static readonly Predicate<Task> s_IsExceptionObservedByParentPredicate; //Field offset: 0x38
	private static ContextCallback s_ecCallback; //Field offset: 0x40
	private static readonly Predicate<Object> s_IsTaskContinuationNullPredicate; //Field offset: 0x48
	private static readonly Dictionary<Int32, Task> s_currentActiveTasks; //Field offset: 0x50
	private static readonly object s_activeTasksLock; //Field offset: 0x58
	private int m_taskId; //Field offset: 0x10
	internal Delegate m_action; //Field offset: 0x18
	internal object m_stateObject; //Field offset: 0x20
	internal TaskScheduler m_taskScheduler; //Field offset: 0x28
	internal readonly Task m_parent; //Field offset: 0x30
	internal int m_stateFlags; //Field offset: 0x38
	private object m_continuationObject; //Field offset: 0x40
	internal ContingentProperties m_contingentProperties; //Field offset: 0x48

	public override object AsyncState
	{
		 get { } //Length: 8
	}

	internal CancellationToken CancellationToken
	{
		internal get { } //Length: 36
	}

	internal ExecutionContext CapturedContext
	{
		internal get { } //Length: 112
		internal set { } //Length: 176
	}

	internal ManualResetEventSlim CompletedEvent
	{
		internal get { } //Length: 248
	}

	public static Task CompletedTask
	{
		[CompilerGenerated]
		 get { } //Length: 88
	}

	public TaskCreationOptions CreationOptions
	{
		 get { } //Length: 20
	}

	internal static StackGuard CurrentStackGuard
	{
		internal get { } //Length: 184
	}

	public AggregateException Exception
	{
		 get { } //Length: 60
	}

	internal bool ExceptionRecorded
	{
		internal get { } //Length: 84
	}

	internal TaskScheduler ExecutingTaskScheduler
	{
		internal get { } //Length: 8
	}

	public static TaskFactory Factory
	{
		[CompilerGenerated]
		 get { } //Length: 88
	}

	public int Id
	{
		 get { } //Length: 144
	}

	internal static Task InternalCurrent
	{
		internal get { } //Length: 88
	}

	public bool IsCanceled
	{
		 get { } //Length: 32
	}

	internal bool IsCancellationAcknowledged
	{
		internal get { } //Length: 24
	}

	internal bool IsCancellationRequested
	{
		internal get { } //Length: 144
	}

	public override bool IsCompleted
	{
		 get { } //Length: 100
	}

	public bool IsCompletedSuccessfully
	{
		 get { } //Length: 40
	}

	internal bool IsDelegateInvoked
	{
		internal get { } //Length: 24
	}

	internal bool IsExceptionObservedByParent
	{
		internal get { } //Length: 24
	}

	public bool IsFaulted
	{
		 get { } //Length: 24
	}

	internal bool IsWaitNotificationEnabled
	{
		internal get { } //Length: 24
	}

	internal bool IsWaitNotificationEnabledOrNotRanToCompletion
	{
		internal get { } //Length: 40
	}

	internal TaskCreationOptions Options
	{
		internal get { } //Length: 92
	}

	internal override bool ShouldNotifyDebuggerOfWaitCompletion
	{
		internal get { } //Length: 24
	}

	public TaskStatus Status
	{
		 get { } //Length: 96
	}

	private override WaitHandle System.IAsyncResult.AsyncWaitHandle
	{
		private get { } //Length: 132
	}

	private override bool System.IAsyncResult.CompletedSynchronously
	{
		private get { } //Length: 8
	}

	private static Task() { }

	internal Task(Delegate action, object state, Task parent, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler) { }

	public Task(Action action, CancellationToken cancellationToken) { }

	internal Task(bool canceled, TaskCreationOptions creationOptions, CancellationToken ct) { }

	internal Task(object state, TaskCreationOptions creationOptions, bool promiseStyle) { }

	internal Task() { }

	public Task(Action action) { }

	internal void AddCompletionAction(ITaskCompletionAction action) { }

	private void AddCompletionAction(ITaskCompletionAction action, bool addBeforeOthers) { }

	internal void AddException(object exceptionObject) { }

	internal void AddException(object exceptionObject, bool representsCancellation) { }

	internal static void AddExceptionsForCompletedTask(ref LowLevelListWithIList<Exception>& exceptions, Task t) { }

	internal void AddExceptionsFromChildren() { }

	internal void AddNewChild() { }

	private bool AddTaskContinuation(object tc, bool addBeforeOthers) { }

	private bool AddTaskContinuationComplex(object tc, bool addBeforeOthers) { }

	[FriendAccessAllowed]
	internal static bool AddToActiveTasks(Task task) { }

	private static void AddToList(T item, ref LowLevelListWithIList<T>& list, int initSize) { }

	internal static bool AnyTaskRequiresNotifyDebuggerOfWaitCompletion(Task[] tasks) { }

	private void AssignCancellationToken(CancellationToken cancellationToken, Task antecedent, TaskContinuation continuation) { }

	internal bool AtomicStateUpdate(int newBits, int illegalBits, ref int oldFlags) { }

	internal bool AtomicStateUpdate(int newBits, int illegalBits) { }

	internal void CancellationCleanupLogic() { }

	public ConfiguredTaskAwaitable ConfigureAwait(bool continueOnCapturedContext) { }

	public Task ContinueWith(Action<Task> continuationAction) { }

	private Task ContinueWith(Action<Task> continuationAction, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions) { }

	public Task ContinueWith(Action<Task, Object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler) { }

	private Task ContinueWith(Action<Task, Object> continuationAction, object state, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions) { }

	internal void ContinueWithCore(Task continuationTask, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions options) { }

	internal static void CreationOptionsFromContinuationOptions(TaskContinuationOptions continuationOptions, out TaskCreationOptions creationOptions, out InternalTaskOptions internalOptions) { }

	public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken) { }

	public static Task Delay(int millisecondsDelay) { }

	protected override void Dispose(bool disposing) { }

	public override void Dispose() { }

	internal void DisregardChild() { }

	internal ContingentProperties EnsureContingentPropertiesInitialized(bool needsProtection) { }

	private ContingentProperties EnsureContingentPropertiesInitializedCore(bool needsProtection) { }

	private void Execute() { }

	internal bool ExecuteEntry(bool bPreventDoubleExecution) { }

	private void ExecuteWithThreadLocal(ref Task currentTaskSlot) { }

	private static void ExecutionContextCallback(object obj) { }

	internal void Finish(bool bUserDelegateExecuted) { }

	internal void FinishContinuations() { }

	internal void FinishStageThree() { }

	internal void FinishStageTwo() { }

	public static Task FromCanceled(CancellationToken cancellationToken) { }

	public static Task<TResult> FromCanceled(CancellationToken cancellationToken) { }

	internal static Task FromCancellation(CancellationToken cancellationToken) { }

	internal static Task<TResult> FromCancellation(CancellationToken cancellationToken) { }

	internal static Task<TResult> FromCancellation(OperationCanceledException exception) { }

	public static Task FromException(Exception exception) { }

	public static Task<TResult> FromException(Exception exception) { }

	public static Task<TResult> FromResult(TResult result) { }

	public override object get_AsyncState() { }

	internal CancellationToken get_CancellationToken() { }

	internal ExecutionContext get_CapturedContext() { }

	internal ManualResetEventSlim get_CompletedEvent() { }

	[CompilerGenerated]
	public static Task get_CompletedTask() { }

	public TaskCreationOptions get_CreationOptions() { }

	internal static StackGuard get_CurrentStackGuard() { }

	public AggregateException get_Exception() { }

	internal bool get_ExceptionRecorded() { }

	internal TaskScheduler get_ExecutingTaskScheduler() { }

	[CompilerGenerated]
	public static TaskFactory get_Factory() { }

	public int get_Id() { }

	internal static Task get_InternalCurrent() { }

	public bool get_IsCanceled() { }

	internal bool get_IsCancellationAcknowledged() { }

	internal bool get_IsCancellationRequested() { }

	public override bool get_IsCompleted() { }

	public bool get_IsCompletedSuccessfully() { }

	internal bool get_IsDelegateInvoked() { }

	internal bool get_IsExceptionObservedByParent() { }

	public bool get_IsFaulted() { }

	internal bool get_IsWaitNotificationEnabled() { }

	internal bool get_IsWaitNotificationEnabledOrNotRanToCompletion() { }

	internal TaskCreationOptions get_Options() { }

	internal override bool get_ShouldNotifyDebuggerOfWaitCompletion() { }

	public TaskStatus get_Status() { }

	public TaskAwaiter GetAwaiter() { }

	internal ExceptionDispatchInfo GetCancellationExceptionDispatchInfo() { }

	internal ReadOnlyCollection<ExceptionDispatchInfo> GetExceptionDispatchInfos() { }

	private AggregateException GetExceptions(bool includeTaskCanceledExceptions) { }

	private void HandleException(Exception unhandledException) { }

	internal override void InnerInvoke() { }

	internal bool InternalCancel(bool bCancelNonExecutingOnly) { }

	internal static Task InternalCurrentIfAttached(TaskCreationOptions creationOptions) { }

	internal static Task InternalStartNew(Task creatingTask, Delegate action, object state, CancellationToken cancellationToken, TaskScheduler scheduler, TaskCreationOptions options, InternalTaskOptions internalOptions) { }

	internal bool InternalWait(int millisecondsTimeout, CancellationToken cancellationToken) { }

	private static Task<TResult[]> InternalWhenAll(Task<TResult>[] tasks) { }

	private static bool IsCompletedMethod(int flags) { }

	private void LogFinishCompletionNotification() { }

	public override void MarkAborted(ThreadAbortException e) { }

	internal bool MarkStarted() { }

	private void NotifyDebuggerOfWaitCompletion() { }

	internal bool NotifyDebuggerOfWaitCompletionIfNecessary() { }

	internal static TaskCreationOptions OptionsMethod(int flags) { }

	internal void ProcessChildCompletion(Task childTask) { }

	internal void RecordInternalCancellationRequest(CancellationToken tokenToRecord, object cancellationException) { }

	internal void RecordInternalCancellationRequest(CancellationToken tokenToRecord) { }

	internal void RecordInternalCancellationRequest() { }

	internal void RemoveContinuation(object continuationObject) { }

	[FriendAccessAllowed]
	internal static void RemoveFromActiveTasks(int taskId) { }

	public static Task Run(Action action) { }

	public static Task<TResult> Run(Func<TResult> function) { }

	public static Task Run(Func<Task> function) { }

	public static Task<TResult> Run(Func<Task`1<TResult>> function, CancellationToken cancellationToken) { }

	public static Task<TResult> Run(Func<Task`1<TResult>> function) { }

	public static Task Run(Func<Task> function, CancellationToken cancellationToken) { }

	internal void ScheduleAndStart(bool needsProtection) { }

	internal void set_CapturedContext(ExecutionContext value) { }

	private void SetCancellationAcknowledged() { }

	internal void SetContinuationForAwait(Action continuationAction, bool continueOnCapturedContext, bool flowExecutionContext) { }

	internal void SetNotificationForWaitCompletion(bool enabled) { }

	private bool SpinThenBlockingWait(int millisecondsTimeout, CancellationToken cancellationToken) { }

	private bool SpinWait(int millisecondsTimeout) { }

	public void Start() { }

	public void Start(TaskScheduler scheduler) { }

	private override WaitHandle System.IAsyncResult.get_AsyncWaitHandle() { }

	private override bool System.IAsyncResult.get_CompletedSynchronously() { }

	private override void System.Threading.IThreadPoolWorkItem.ExecuteWorkItem() { }

	private static void TaskCancelCallback(object o) { }

	internal void TaskConstructorCore(Delegate action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler) { }

	internal void ThrowIfExceptional(bool includeTaskCanceledExceptions) { }

	internal bool TrySetCanceled(CancellationToken tokenToRecord, object cancellationException) { }

	internal bool TrySetCanceled(CancellationToken tokenToRecord) { }

	internal bool TrySetException(object exceptionObject) { }

	internal void UpdateExceptionObservedStatus() { }

	public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken) { }

	public void Wait() { }

	public static bool WaitAll(Task[] tasks, int millisecondsTimeout, CancellationToken cancellationToken) { }

	public static void WaitAll(Task[] tasks) { }

	public static bool WaitAll(Task[] tasks, int millisecondsTimeout) { }

	private static bool WaitAllBlockingCore(LowLevelListWithIList<Task> tasks, int millisecondsTimeout, CancellationToken cancellationToken) { }

	public static Task<TResult[]> WhenAll(IEnumerable<Task`1<TResult>> tasks) { }

	public static Task<TResult[]> WhenAll(Task<TResult>[] tasks) { }

	public static Task<Task> WhenAny(Task[] tasks) { }

	public static Task<Task> WhenAny(IEnumerable<Task> tasks) { }

	private bool WrappedTryRunInline() { }

	public static YieldAwaitable Yield() { }

}

