namespace Unity.Services.Relay.Scheduler;

public sealed class TaskSchedulerThreaded : TaskScheduler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public Action task; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal void <ScheduleBackgroundTask>b__0(object state) { }

	}

	private Queue<Action> m_mainThreadTaskQueue; //Field offset: 0x20
	private object m_lock; //Field offset: 0x28
	private Thread m_mainThread; //Field offset: 0x30

	public TaskSchedulerThreaded() { }

	public virtual bool IsMainThread() { }

	public virtual void ScheduleBackgroundTask(Action task) { }

	public virtual void ScheduleMainThreadTask(Action task) { }

	private void Start() { }

	private void Update() { }

}

