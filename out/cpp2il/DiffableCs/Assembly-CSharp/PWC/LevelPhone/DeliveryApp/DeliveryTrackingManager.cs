namespace PWC.LevelPhone.DeliveryApp;

public class DeliveryTrackingManager : DeliveryPageManagerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public GameObject item; //Field offset: 0x10
		public Vector2 localPosition; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <OnSetActive>b__0() { }

	}

	[SerializeField]
	private DeliveryProgressBar _progressBar; //Field offset: 0x28
	[SerializeField]
	private Color _topBackgroundColor; //Field offset: 0x30
	[SerializeField]
	private Color _bottomBackgroundColor; //Field offset: 0x40
	[SerializeField]
	private GameObject[] _drones; //Field offset: 0x50
	[SerializeField]
	private GameObject[] _objectsToAnimateScale; //Field offset: 0x58
	private readonly Dictionary<GameObject, Int32> _scaleTweenIDs; //Field offset: 0x60
	private readonly Dictionary<GameObject, Int32> _moveTweenIDs; //Field offset: 0x68

	public DeliveryTrackingManager() { }

	public virtual void OnSetActive(bool isActive, Action onCompleteSetActiveAction = null) { }

}

