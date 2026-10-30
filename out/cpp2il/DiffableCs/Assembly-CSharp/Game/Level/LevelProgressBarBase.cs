namespace Game.Level;

public abstract class LevelProgressBarBase : MonoBehaviour
{
	[Header("Range For Inspector Driven Calls")]
	[SerializeField]
	private float _defaultMinValue; //Field offset: 0x20
	[SerializeField]
	private float _defaultMaxValue; //Field offset: 0x24
	private bool _hasLoggedInvalidRange; //Field offset: 0x28

	protected LevelProgressBarBase() { }

	protected abstract void DrawProgress(float normalizedProgress, bool isInstant) { }

	private void LogInvalidRangeOnce(float minValue, float maxValue) { }

	public void SetNormalizedProgress(float normalizedProgress) { }

	public void SetProgress(float currentValue) { }

	public void UpdateProgress(float currentValue, float minValue, float maxValue, bool isInstant = false) { }

}

