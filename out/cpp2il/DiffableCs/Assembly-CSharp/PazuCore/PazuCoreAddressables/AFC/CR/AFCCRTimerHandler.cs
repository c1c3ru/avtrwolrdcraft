namespace PazuCore.PazuCoreAddressables.AFC.CR;

public class AFCCRTimerHandler : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private string _cloudResponseKey; //Field offset: 0x28
	[SerializeField]
	private String[] _path; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onTimerComplete; //Field offset: 0x38
	private Coroutine _timerCoroutine; //Field offset: 0x40

	public AFCCRTimerHandler() { }

	[CompilerGenerated]
	private void <PerformAction>b__5_0() { }

	public virtual void PerformAction() { }

	public void StartTimer() { }

}

