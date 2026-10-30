namespace PazuCore.PazuCoreAddressables.AFC;

public abstract class AFCConditionHandlerBase : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private UnityEvent _onConditionMetEvent; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onConditionNotMetEvent; //Field offset: 0x30

	protected AFCConditionHandlerBase() { }

	public void CallEvents() { }

	public abstract bool IsConditionMet() { }

	public virtual void PerformAction() { }

}

