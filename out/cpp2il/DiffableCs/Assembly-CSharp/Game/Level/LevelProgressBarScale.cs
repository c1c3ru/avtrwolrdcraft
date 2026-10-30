namespace Game.Level;

public class LevelProgressBarScale : LevelProgressBarBase
{
	private enum ScaleAxis
	{
		X = 0,
		Y = 1,
	}

	[Header("Fill")]
	[SerializeField]
	private Transform _fillTransform; //Field offset: 0x30
	[SerializeField]
	private ScaleAxis _scaleAxis; //Field offset: 0x38
	[SerializeField]
	private float _emptyScale; //Field offset: 0x3C
	[SerializeField]
	private float _fullScale; //Field offset: 0x40
	[Header("Tween")]
	[SerializeField]
	private float _tweenTime; //Field offset: 0x44
	[SerializeField]
	private LeanTweenType _easeType; //Field offset: 0x48
	private int _tweenId; //Field offset: 0x4C

	public LevelProgressBarScale() { }

	private void Awake() { }

	private void CancelTween() { }

	protected virtual void DrawProgress(float normalizedProgress, bool isInstant) { }

	private void OnDestroy() { }

	private void OnTweenComplete() { }

	private void SetScale(float targetScale) { }

}

