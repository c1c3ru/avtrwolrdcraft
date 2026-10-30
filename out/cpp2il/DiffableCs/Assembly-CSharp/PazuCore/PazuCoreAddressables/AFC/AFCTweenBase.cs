namespace PazuCore.PazuCoreAddressables.AFC;

public abstract class AFCTweenBase : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	protected GameObject _target; //Field offset: 0x28
	[SerializeField]
	protected EaseType _easeType; //Field offset: 0x30
	[SerializeField]
	protected float _duration; //Field offset: 0x34
	[SerializeField]
	protected float _delay; //Field offset: 0x38
	[SerializeField]
	protected LoopType _loopType; //Field offset: 0x3C
	[SerializeField]
	protected UnityEvent _onComplete; //Field offset: 0x40

	public GameObject Target
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	protected AFCTweenBase() { }

	[CompilerGenerated]
	private void <GetBaseHashTable>b__12_0() { }

	public GameObject get_Target() { }

	protected Hashtable GetBaseHashTable() { }

	public virtual void PerformAction() { }

	public abstract void PlayTween() { }

	public void set_Target(GameObject value) { }

	public void StopTween() { }

}

