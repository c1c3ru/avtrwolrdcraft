namespace Unity.Services.Lobbies.Scheduler;

public abstract class TaskScheduler : MonoBehaviour
{

	protected TaskScheduler() { }

	public abstract bool IsMainThread() { }

	public abstract void ScheduleBackgroundTask(Action task) { }

	public abstract void ScheduleMainThreadTask(Action task) { }

	public void ScheduleOrExecuteOnMain(Action action) { }

}

