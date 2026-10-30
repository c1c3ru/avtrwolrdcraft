namespace PWC.LightSystem;

public class LitRenderer : LitBase
{
	protected Renderer _renderer; //Field offset: 0x58
	private readonly int _shaderColorID; //Field offset: 0x60

	public LitRenderer() { }

	public virtual void ApplyIntensity() { }

	protected virtual void Awake() { }

	public virtual Vector2 GetPointForDistanceCheck() { }

	protected virtual bool IsInsideLightArea(LightArea lightArea) { }

	public virtual bool IsVisible() { }

}

