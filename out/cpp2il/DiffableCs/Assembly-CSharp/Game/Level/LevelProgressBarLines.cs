namespace Game.Level;

public class LevelProgressBarLines : LevelProgressBarBase
{
	private const float LineCountEpsilon = 0,0001; //Field offset: 0x0
	[SerializeField]
	private List<GameObject> _lineObjects; //Field offset: 0x30

	public LevelProgressBarLines() { }

	private void Awake() { }

	protected virtual void DrawProgress(float normalizedProgress, bool isInstant) { }

	private void ValidateLineObjects() { }

}

