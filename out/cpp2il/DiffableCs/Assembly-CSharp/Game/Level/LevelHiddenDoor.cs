namespace Game.Level;

public class LevelHiddenDoor : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public Vector3 localPosition; //Field offset: 0x10
		public float aPosition; //Field offset: 0x1C
		public float bPosition; //Field offset: 0x20
		public Vector3 rotation; //Field offset: 0x24
		public float aRotation; //Field offset: 0x30
		public float bRotation; //Field offset: 0x34
		public LevelHiddenDoor <>4__this; //Field offset: 0x38
		public bool value; //Field offset: 0x40

		public <>c__DisplayClass14_0() { }

		internal void <AnimateDoor>b__0(float t) { }

		internal void <AnimateDoor>b__1() { }

	}

	[SerializeField]
	private Transform _door; //Field offset: 0x60
	[SerializeField]
	private GameObject _redLight; //Field offset: 0x68
	[SerializeField]
	private GameObject _yellowLight; //Field offset: 0x70
	[SerializeField]
	private GameObject _purpleLight; //Field offset: 0x78
	[SerializeField]
	private GameObject _blueLight; //Field offset: 0x80
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x88
	[SerializeField]
	private GameObject _inside; //Field offset: 0x90
	[SerializeField]
	private UnityEvent _onDoorOpenAction; //Field offset: 0x98
	private Dictionary<HiddenDoorPlushType, GameObject> _lightsByPlushType; //Field offset: 0xA0
	private bool _isSolved; //Field offset: 0xA8
	private bool _isOpen; //Field offset: 0xA9
	private bool _isShaking; //Field offset: 0xAA

	public LevelHiddenDoor() { }

	[CompilerGenerated]
	private void <ShakeDoor>b__15_0() { }

	private void AnimateDoor(bool value, bool isImmediate = false) { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnDestroy() { }

	private void OnPlushInteraction(HiddenDoorPlushType plushType, bool value) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void ShakeDoor() { }

}

