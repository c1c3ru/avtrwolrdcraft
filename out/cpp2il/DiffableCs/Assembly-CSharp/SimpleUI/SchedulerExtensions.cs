namespace SimpleUI;

[Extension]
public static class SchedulerExtensions
{

	[Extension]
	public static Coroutine DelayedForEach(IList<T> enumerable, Action<T> TaskToExecute, float interval = 1, Action OnFinished = null) { }

	[Extension]
	public static Coroutine DelayedForEach(IList<T> enumerable, Action<T> TaskToExecute, AnimationCurve customStagger, float averageInterval = 1, Action OnFinished = null) { }

	[Extension]
	public static void ReplaceOrStartScheduledAction(UniqueCoroutine ur, Coroutine cr) { }

}

