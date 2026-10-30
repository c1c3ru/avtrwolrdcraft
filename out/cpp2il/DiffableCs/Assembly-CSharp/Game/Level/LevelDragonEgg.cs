namespace Game.Level;

public class LevelDragonEgg : LevelItem
{
	internal enum DragonEggStateType
	{
		None = 0,
		Whole = 1,
		Crack1 = 2,
		Crack2 = 3,
		Open = 4,
		Dragon = 5,
	}

	private const string SPRITE_PATH_PREEFIX = "Level/DragonEgg/DragonEgg_Z2B4L1__"; //Field offset: 0x0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x348
	private DragonEggStateType _stateType; //Field offset: 0x350
	private SpriteRenderer _spriteRenderer; //Field offset: 0x358

	public LevelDragonEgg() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	private void PlaySound() { }

	private void SetNewSpriteFromResources() { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UpdatedStateTypeIfNeeded() { }

}

