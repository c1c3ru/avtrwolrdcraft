namespace Game.Level;

public class TweenWaterColorSetter : TweenColorSetterBase
{
	[SerializeField]
	private LevelWaterArea _waterArea; //Field offset: 0x30
	[SerializeField]
	private bool _keepCurrentAlpha; //Field offset: 0x38

	public TweenWaterColorSetter() { }

	private void Awake() { }

	protected virtual Color GetCurrentColor() { }

	protected virtual Color GetTargetColor(Color newColor, Color currentColor) { }

	private void SetColor(Color color) { }

	protected virtual void StartColorTransition(Color fromColor, Color toColor, float transitionTime) { }

}

