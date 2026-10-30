namespace Game.Level;

public class LevelPetBowlItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelDropArea _foodDropArea; //Field offset: 0x20
	[SerializeField]
	private LevelFillableItemHandler _drinkableItemHandler; //Field offset: 0x28

	public LevelPetBowlItemHandler() { }

	private void Awake() { }

	private void DisableDrink(LevelItem levelItem) { }

	private void DisableFood(ILevelFillable drinkableWithFillItemHandler) { }

	private void EnableDrink(LevelItem levelItem) { }

	private void EnableFood(ILevelFillable drinkableWithFillItemHandler) { }

	private void OnDestroy() { }

	private void OnPostInitAction() { }

}

