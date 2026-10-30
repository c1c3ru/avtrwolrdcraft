namespace Game.Level;

public class LevelFoldableTable : LevelSimpleToggleableAudioItem
{
	[SerializeField]
	private Transform _dropArea; //Field offset: 0x380
	[SerializeField]
	private Vector2 _dropAreaUnfoldedLocalPosition; //Field offset: 0x388
	[SerializeField]
	private Vector2 _dropAreaFoldedLocalPosition; //Field offset: 0x390

	public LevelFoldableTable() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SyncAreasPositions() { }

}

