namespace Game.Level;

public class LevelDigTreasureChestArea : LevelDigArea
{
	[SerializeField]
	private SpriteRenderer _vanishEffectHelper; //Field offset: 0x58
	[SerializeField]
	private GameObject[] _xStages; //Field offset: 0x60
	private int _xStagesCounter; //Field offset: 0x68
	private LevelBoxItem _treasureChest; //Field offset: 0x70

	public LevelDigTreasureChestArea() { }

	protected virtual void Awake() { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	public virtual void OnShovelDig() { }

}

