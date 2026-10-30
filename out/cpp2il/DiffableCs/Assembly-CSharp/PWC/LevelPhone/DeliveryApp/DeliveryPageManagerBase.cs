namespace PWC.LevelPhone.DeliveryApp;

public abstract class DeliveryPageManagerBase : MonoBehaviour
{
	public const float ANIMATION_TIME = 0,1; //Field offset: 0x0
	protected bool _isActive; //Field offset: 0x20

	public bool IsActive
	{
		 get { } //Length: 8
	}

	protected DeliveryPageManagerBase() { }

	public bool get_IsActive() { }

	public override void OnSetActive(bool isActive, Action onCompleteSetActiveAction = null) { }

}

