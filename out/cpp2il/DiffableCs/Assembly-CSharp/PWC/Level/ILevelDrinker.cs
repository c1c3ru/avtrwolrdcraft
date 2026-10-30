namespace PWC.Level;

public interface ILevelDrinker
{

	public void Drink(LevelDrinkableItemHandler itemHandler) { }

	public Transform GetMouthTransform() { }

	public bool TryDrink(LevelDrinkableItemHandler itemHandler) { }

}

