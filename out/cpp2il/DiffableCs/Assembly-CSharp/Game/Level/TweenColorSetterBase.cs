namespace Game.Level;

public abstract class TweenColorSetterBase : MonoBehaviour
{
	[SerializeField]
	private float _changeTime; //Field offset: 0x20
	[SerializeField]
	private List<Color> _colors; //Field offset: 0x28

	protected TweenColorSetterBase() { }

	protected abstract Color GetCurrentColor() { }

	protected override Color GetTargetColor(Color newColor, Color currentColor) { }

	protected abstract void StartColorTransition(Color fromColor, Color toColor, float transitionTime) { }

	public void StopTransition() { }

	public void TransitionToNewColor(int index) { }

}

