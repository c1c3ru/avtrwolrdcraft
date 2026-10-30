namespace Game.Level;

public class LevelRunningAreaItemHandler : MonoBehaviour
{
	private LevelItem _levelItem; //Field offset: 0x20
	private bool _didAwake; //Field offset: 0x28
	private Vector2 _prevPosition; //Field offset: 0x2C
	[CompilerGenerated]
	private bool <IgnoreEndLandEvent>k__BackingField; //Field offset: 0x34
	private LevelCharacter _character; //Field offset: 0x38
	private bool _isRunning; //Field offset: 0x40

	public bool IgnoreEndLandEvent
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelRunningAreaItemHandler() { }

	private void Awake() { }

	[CompilerGenerated]
	public bool get_IgnoreEndLandEvent() { }

	private void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnEndLand(LevelDropArea dropArea) { }

	private void OnSyncPosition(DragDropItemBase dragDropItemBase, Vector2 position) { }

	[CompilerGenerated]
	public void set_IgnoreEndLandEvent(bool value) { }

}

