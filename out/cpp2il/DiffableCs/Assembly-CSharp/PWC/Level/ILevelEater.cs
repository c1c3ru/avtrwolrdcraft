namespace PWC.Level;

public interface ILevelEater
{

	public void Eat(LevelEatableItemHandler itemHandler) { }

	public EaterType GetEaterType() { }

	public Transform GetMouthTransform() { }

	public bool TryEat(LevelEatableItemHandler itemHandler) { }

}

