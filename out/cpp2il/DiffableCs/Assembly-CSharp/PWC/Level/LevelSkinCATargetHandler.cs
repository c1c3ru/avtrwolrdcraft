namespace PWC.Level;

public class LevelSkinCATargetHandler
{
	private GameObject _skinCAHandlersGameObject; //Field offset: 0x10
	private readonly Dictionary<String, LevelCASpineSkinHandlerBase> _skinCAHandlers; //Field offset: 0x18
	private readonly ICATarget _caTarget; //Field offset: 0x20
	private readonly SpineType _spineType; //Field offset: 0x28
	private readonly LevelAvatarClothingHandler _clothingHandler; //Field offset: 0x30

	public LevelSkinCATargetHandler(ICATarget caTarget, SpineType spineType, LevelAvatarClothingHandler clothingHandler) { }

	protected virtual void Finalize() { }

	public void OnCurrentSkinsSynced() { }

	private void OnPutClothing(string skinName) { }

	private void OnRemovedClothing(string skinName) { }

	private bool TryAddCAHandlerFromSkinName(string skinName) { }

	private bool TryRemoveCAHandlerFromSkinName(string skinName) { }

}

