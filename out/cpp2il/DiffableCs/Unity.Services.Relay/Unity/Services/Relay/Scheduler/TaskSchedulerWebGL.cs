namespace Unity.Services.Relay.Scheduler;

public sealed class TaskSchedulerWebGL : TaskScheduler
{
	private Queue<Action> m_mainThreadTaskQueue; //Field offset: 0x20

	public TaskSchedulerWebGL() { }

	public virtual bool IsMainThread() { }

	public virtual void ScheduleBackgroundTask(Action task) { }

	public virtual void ScheduleMainThreadTask(Action task) { }

	private void Update() { }

}

