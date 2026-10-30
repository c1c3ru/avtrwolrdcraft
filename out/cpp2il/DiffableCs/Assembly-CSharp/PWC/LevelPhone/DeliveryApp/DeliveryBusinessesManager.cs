namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryBusinessesManager : DeliveryPageManagerBase
{
	[SerializeField]
	private Sprite _logo; //Field offset: 0x28
	[SerializeField]
	private Transform _content; //Field offset: 0x30
	[SerializeField]
	private DeliveryBusinessThumb _prefab; //Field offset: 0x38
	[SerializeField]
	private DeliveryBusinessData[] BusinessesData; //Field offset: 0x40
	private bool _isInited; //Field offset: 0x48
	private readonly List<DeliveryBusinessThumb> _thumbs; //Field offset: 0x50

	public DeliveryBusinessesManager() { }

	private void Animate(Action onCompleteAnimationAction = null) { }

	private void InitBusinessesIfNeeded() { }

	public virtual void OnSetActive(bool isActive, Action onCompleteSetActiveAction = null) { }

}

