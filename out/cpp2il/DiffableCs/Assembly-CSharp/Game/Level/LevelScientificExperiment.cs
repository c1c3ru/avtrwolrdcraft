namespace Game.Level;

public class LevelScientificExperiment : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite _onState; //Field offset: 0x28
	[SerializeField]
	private Sprite _offState; //Field offset: 0x30
	[SerializeField]
	private LevelSingleItemFoodOnlyDropArea _foodDropArea; //Field offset: 0x38
	[SerializeField]
	private LevelSingleItemDropArea _bulbDropArea; //Field offset: 0x40
	private Nullable<Color> _currentColor; //Field offset: 0x48
	private LevelScientificExperimentLightBulbItemHandler _currentLightBulb; //Field offset: 0x60

	public LevelScientificExperiment() { }

	private void Awake() { }

	private void OnBulbItemEndDrop(LevelItem levelItem) { }

	private void OnBulbItemPickUp(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnFoodItemEndDrop(LevelItem levelItem) { }

	private void OnFoodItemPickUp(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void SetState(bool value) { }

	private bool TryExperiment() { }

}

