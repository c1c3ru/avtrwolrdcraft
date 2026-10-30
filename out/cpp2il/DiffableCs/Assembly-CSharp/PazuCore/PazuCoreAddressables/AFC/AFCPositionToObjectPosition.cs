namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPositionToObjectPosition : AFCUnityMessageDrivenHandlerBase
{
	[SerializeField]
	private Transform _target; //Field offset: 0x28

	public AFCPositionToObjectPosition() { }

	public virtual void PerformAction() { }

	public void SetPostion() { }

}

