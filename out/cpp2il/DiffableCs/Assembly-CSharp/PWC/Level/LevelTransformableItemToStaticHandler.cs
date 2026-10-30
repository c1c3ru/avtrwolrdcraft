namespace PWC.Level;

[DisallowMultipleComponent]
[RequireComponent(typeof(LevelItem))]
public class LevelTransformableItemToStaticHandler : LevelTransformableItemHandler
{
	[SerializeField]
	private bool isFlippable; //Field offset: 0x91
	[SerializeField]
	private bool forceToStayInPosition; //Field offset: 0x92

	public LevelTransformableItemToStaticHandler() { }

	protected virtual void Awake() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected virtual bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

