namespace PWC.Level;

public class LevelObjectWallArea : LevelObjectAreaBase
{
	public static readonly List<LevelObjectAreaBase> List; //Field offset: 0x0
	private LevelMakerItemWithArea _item; //Field offset: 0x40
	private LevelWallArea _wallArea; //Field offset: 0x48

	private static LevelObjectWallArea() { }

	public LevelObjectWallArea() { }

	protected virtual void Awake() { }

	public LevelWallArea GetCurrntWall() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

}

