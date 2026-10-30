namespace Game.Level;

public class LevelShakingDoor : LevelConsumerAreaBase, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public LevelShakingDoor <>4__this; //Field offset: 0x10
		public GameObject door; //Field offset: 0x18
		public Vector3 initialPosition; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x30

		public <>c__DisplayClass11_0() { }

		internal void <ShakeDoor>b__0() { }

		internal void <ShakeDoor>b__1() { }

	}

	[SerializeField]
	private LevelDoor _levelDoor; //Field offset: 0x58
	[SerializeField]
	private GameObject _leftDoor; //Field offset: 0x60
	[SerializeField]
	private GameObject _rightDoor; //Field offset: 0x68
	[SerializeField]
	private string _soundName; //Field offset: 0x70
	[SerializeField]
	private bool _isOpen; //Field offset: 0x78
	[SerializeField]
	private UnityEvent _onOpenDoorAfterShakeEvent; //Field offset: 0x80
	private Dictionary<GameObject, Int32> _tweenIDs; //Field offset: 0x88
	private int _delayTweenID; //Field offset: 0x90

	public LevelShakingDoor() { }

	[CompilerGenerated]
	private void <ShakeDoor>b__10_0() { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void ShakeDoor(bool shouldOpenAfterShake) { }

	private void ShakeDoor(GameObject door) { }

}

