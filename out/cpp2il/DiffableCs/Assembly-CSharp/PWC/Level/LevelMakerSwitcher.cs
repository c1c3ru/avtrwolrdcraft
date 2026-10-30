namespace PWC.Level;

public class LevelMakerSwitcher : LevelLevelSwitcher
{
	private enum LevelMakerSwitcherDirectionType
	{
		None = 0,
		Up = 1,
		Down = 2,
	}

	[SerializeField]
	private LevelMakerSwitcherDirectionType _directionType; //Field offset: 0x48

	public LevelMakerSwitcher() { }

	protected virtual void Awake() { }

	private void OnBeforeSceneLoadStage3() { }

	protected virtual void OnDestroy() { }

}

