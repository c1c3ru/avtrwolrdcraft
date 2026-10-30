namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCTimerHandler : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private float _duration; //Field offset: 0x24
	[SerializeField]
	private UnityEvent _onTimerComplete; //Field offset: 0x28
	private Coroutine _timerCoroutine; //Field offset: 0x30

	public AFCTimerHandler() { }

	[CompilerGenerated]
	private void <PerformAction>b__4_0() { }

	public virtual void PerformAction() { }

	public void StartTimer() { }

	public void StopAction() { }

	public void StopTimer() { }

}

