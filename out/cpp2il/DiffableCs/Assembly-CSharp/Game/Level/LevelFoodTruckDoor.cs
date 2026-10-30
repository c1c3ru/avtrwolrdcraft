namespace Game.Level;

public class LevelFoodTruckDoor : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Vector2 size; //Field offset: 0x10
		public LevelFoodTruckDoor <>4__this; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <Animate>b__0(float value) { }

		internal void <Animate>b__1() { }

	}

	[SerializeField]
	private GameObject _closed; //Field offset: 0x60
	[SerializeField]
	private GameObject _opened; //Field offset: 0x68
	[SerializeField]
	private UnityEvent _OnClosed; //Field offset: 0x70
	[SerializeField]
	private UnityEvent _OnOpened; //Field offset: 0x78
	private bool _isInteractable; //Field offset: 0x80
	private bool _isOpen; //Field offset: 0x81

	public LevelFoodTruckDoor() { }

	private void Animate(bool isSnap) { }

	public void ForceClose() { }

	public void ForceOpen() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

