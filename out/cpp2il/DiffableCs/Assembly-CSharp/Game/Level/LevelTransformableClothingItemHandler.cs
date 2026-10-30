namespace Game.Level;

public class LevelTransformableClothingItemHandler : LevelTransformableItemHandlerBase, ILevelMakerUICountExtraPrefab
{
	[SerializeField]
	protected string _clothingItemName; //Field offset: 0x88
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x90

	public LevelTransformableClothingItemHandler() { }

	public virtual string GetTransformTargetPrefabName() { }

	private override string PWC.Level.ILevelMakerUICountExtraPrefab.GetExtraPrefabGuid() { }

	protected virtual bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

}

