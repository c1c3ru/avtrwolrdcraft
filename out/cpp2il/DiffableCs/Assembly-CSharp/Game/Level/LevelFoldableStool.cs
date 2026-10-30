namespace Game.Level;

public class LevelFoldableStool : LevelSimpleToggleableAudioItem
{
	[SerializeField]
	private Transform _restArea; //Field offset: 0x380
	[SerializeField]
	private Vector2 _restAreaUnfoldedLocalPosition; //Field offset: 0x388
	[SerializeField]
	private Vector2 _restAreaFoldedLocalPosition; //Field offset: 0x390
	[SerializeField]
	private Transform _dropArea; //Field offset: 0x398
	[SerializeField]
	private Vector2 _dropAreaUnfoldedLocalPosition; //Field offset: 0x3A0
	[SerializeField]
	private Vector2 _dropAreaFoldedLocalPosition; //Field offset: 0x3A8

	public LevelFoldableStool() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncAreasPositions() { }

}

