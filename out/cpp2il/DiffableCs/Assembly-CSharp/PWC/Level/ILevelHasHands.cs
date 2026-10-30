namespace PWC.Level;

public interface ILevelHasHands
{

	public void FreeHand(AvatarHandType handType) { }

	public Vector2 GetDefaultPositionInHand(LevelItem levelItem, Transform parent) { }

	public void PutInHand(LevelItem levelItem, AvatarHandType handType, bool snap = false) { }

	public bool TryGetHandItem(AvatarHandType handType, out LevelItem levelItem) { }

}

