namespace PWC.WobbleEffect;

public class WobbleEffect : WobbleEffectBase
{
	private SpriteRenderer _spriteRenderer; //Field offset: 0x40

	public WobbleEffect() { }

	protected virtual void ApplyWobble(float wobbleAmount) { }

	protected virtual void ApplyWorldPosition(Vector2 worldPosition) { }

	private void Awake() { }

}

