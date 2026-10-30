namespace PWC.LightSystem;

public class LitTextMesh : LitBase
{
	private TextMesh _textMesh; //Field offset: 0x58
	private MeshRenderer _meshRenderer; //Field offset: 0x60
	private Color _startColor; //Field offset: 0x68

	public LitTextMesh() { }

	public virtual void ApplyIntensity() { }

	protected virtual void Awake() { }

	public virtual Vector2 GetPointForDistanceCheck() { }

	protected virtual bool IsInsideLightArea(LightArea lightArea) { }

	public virtual bool IsVisible() { }

	public void SetEnabled(bool isEnabled) { }

	public void SetStartColor(Color color) { }

}

