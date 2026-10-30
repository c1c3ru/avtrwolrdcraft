namespace Game.Level;

public class LevelCafeteriaFoodDisplay : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _menuDisplaySpriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite[] _menuDisplaySprites; //Field offset: 0x28
	[SerializeField]
	private GameObject[] _foodDisplaysPart1; //Field offset: 0x30
	[SerializeField]
	private GameObject[] _foodDisplaysPart2; //Field offset: 0x38

	public LevelCafeteriaFoodDisplay() { }

	private void Awake() { }

	private void ChangeFoodDisplay() { }

	private void OnDestroy() { }

	private void SetFoodDisplay(int foodIndex) { }

}

