namespace Game.Level;

public class LevelAirplaneExitDoor : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelAirplaneExitDoor <>4__this; //Field offset: 0x10
		public bool shouldEnableCshapeAtEnd; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass9_0() { }

		internal void <ForceClose>b__0() { }

		internal void <ForceClose>b__1() { }

	}

	[SerializeField]
	private GameObject _door; //Field offset: 0x20
	[SerializeField]
	private CShape _cShape; //Field offset: 0x28
	[SerializeField]
	private Vector2 _initialPosition; //Field offset: 0x30
	[SerializeField]
	private Vector2 _endPosition; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onDoorClosedAction; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onDoorOpenAction; //Field offset: 0x48
	private int _tweenID; //Field offset: 0x50
	private bool _isOpen; //Field offset: 0x54

	public LevelAirplaneExitDoor() { }

	[CompilerGenerated]
	private void <ForceOpen>b__10_0() { }

	[CompilerGenerated]
	private void <ForceOpen>b__10_1() { }

	public void ForceClose(bool shouldEnableCshapeAtEnd = true) { }

	public void ForceOpen() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

