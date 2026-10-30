namespace PWC.LightSystem;

public class LitSpriteRenderer : LitBase
{
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x58
	protected Color _startColor; //Field offset: 0x60

	public LitSpriteRenderer() { }

	public virtual void ApplyIntensity() { }

	protected virtual void Awake() { }

	public virtual Vector2 GetPointForDistanceCheck() { }

	protected virtual bool IsInsideLightArea(LightArea lightArea) { }

	public virtual bool IsVisible() { }

	public void SetEnabled(bool isEnabled) { }

	public void SetStartColor(Color color) { }

}

