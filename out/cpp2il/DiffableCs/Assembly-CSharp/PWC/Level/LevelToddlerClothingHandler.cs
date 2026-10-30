namespace PWC.Level;

public class LevelToddlerClothingHandler : LevelAvatarClothingHandler
{
	private LevelToddler _toddler; //Field offset: 0x70

	public LevelToddlerClothingHandler(SpineType spineType, Transform owner, AvatarSpineSkinsManagerBase avatarSpineSkinsManager, Func<Int32, Vector2, Boolean> canPickUpClothingAction = null, ICATarget ownerCATarget = null) { }

	protected virtual void ThrowExistingClothingItemWhenPutClothing(int clothingType, int parentCategoryType) { }

}

