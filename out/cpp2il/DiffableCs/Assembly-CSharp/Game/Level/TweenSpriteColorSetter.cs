namespace Game.Level;

public class TweenSpriteColorSetter : TweenColorSetterBase
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x30

	public TweenSpriteColorSetter() { }

	protected virtual Color GetCurrentColor() { }

	protected virtual void StartColorTransition(Color fromColor, Color toColor, float transitionTime) { }

}

