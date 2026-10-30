namespace Game.Level;

public class LevelCameraScreenFilmRollMergeButton : LevelButton
{
	[Header("Scene References")]
	[Header("Merge Settings")]
	[SerializeField]
	[Space]
	private LevelSingleItemDropArea _firstMergeArea; //Field offset: 0xA0
	[SerializeField]
	private LevelSingleItemDropArea _secondMergeArea; //Field offset: 0xA8
	[SerializeField]
	private LevelSimpleSpawner _multiPictureSpawner; //Field offset: 0xB0
	private LevelCameraScreenFilmRoll _firstFilmRoll; //Field offset: 0xB8
	private LevelCameraScreenFilmRoll _secondFilmRoll; //Field offset: 0xC0

	public LevelCameraScreenFilmRollMergeButton() { }

	public virtual void Awake() { }

	private bool CanMerge(LevelCameraScreenFilmRoll first, LevelCameraScreenFilmRoll second) { }

	private bool HasTwoFilmsAndCanMerge() { }

	private void Merge(LevelCameraScreenFilmRoll from, LevelCameraScreenFilmRoll to) { }

	private int NumberOfAvailableRenderers() { }

	private void OnDestroy() { }

	private void OnItemEndDropOnFirstAreaHandler(LevelItem item) { }

	private void OnItemEndDropOnSecondAreaHandler(LevelItem item) { }

	private void OnItemEndPickUpOnFirstAreaHandler(LevelItem item) { }

	private void OnItemEndPickUpOnSecondAreaHandler(LevelItem item) { }

	protected virtual void OnLevelPostInit() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	private void OnSpawnHandler(LevelSimpleSpawnerBase _, LevelSpawn spawn) { }

}

