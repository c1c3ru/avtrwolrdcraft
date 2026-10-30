namespace PWC.Level;

public class LevelHangableClothingItem : LevelClothingItem, IMultiplayer_PrepareForDrop
{
	[SerializeField]
	protected LevelTwoStateHangHandler _hangHandler; //Field offset: 0x390
	[SerializeField]
	private bool _keepPrefabPositions; //Field offset: 0x398
	private Material[] _materials; //Field offset: 0x3A0

	public LevelHangableClothingItem() { }

	protected virtual void ApplyColors() { }

	public virtual void InitIfNeeded() { }

	public virtual void Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	private string Multiplayer_GetKey() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	private override void PWC.Multiplayer.IMultiplayer_PrepareForDrop.Multiplayer_PrepareForDrop(MPDataType tiggerFromDataType) { }

	private void SetSprites(SpriteRenderer foldedSpriteRenderer, SpriteRenderer hangedSpriteRenderer, Sprite folded, Sprite hanged, Sprite foldedST, Sprite hangedST) { }

	private void SyncPositions(SpriteRenderer hangedSpriteRenderer) { }

	public virtual bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

}

