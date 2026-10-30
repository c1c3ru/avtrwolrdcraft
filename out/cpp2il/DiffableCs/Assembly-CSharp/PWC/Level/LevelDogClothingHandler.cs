namespace PWC.Level;

public class LevelDogClothingHandler : LevelAvatarClothingHandler
{

	public LevelDogClothingHandler(SpineType spineType, Transform owner, AvatarSpineSkinsManagerBase avatarSpineSkinsManager, Func<Int32, Vector2, Boolean> canPickUpClothingAction = null, ICATarget ownerCATarget = null) { }

	protected virtual void ThrowExistingClothingItemWhenPutClothing(int clothingType, int parentCategoryType) { }

}

