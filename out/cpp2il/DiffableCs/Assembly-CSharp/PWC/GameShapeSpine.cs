namespace PWC;

public class GameShapeSpine : GameShape
{
	private readonly Transform _root; //Field offset: 0x68
	private Vector2 _cShapeMin; //Field offset: 0x70
	private Vector2 _cShapeMax; //Field offset: 0x78

	public GameShapeSpine(Transform root, CShape cShape, Vector2 cShapeMin, Vector2 cShapeMax) { }

	protected virtual void CalculateLocalBoundsIfNeeded() { }

	protected virtual Vector2[] CreateLocalPointsForTouchTest() { }

	public virtual Bounds GetLocalBounds() { }

	public virtual Bounds1D GetLocalXBounds() { }

	public virtual Bounds GetWorldBounds() { }

	public virtual Bounds1D GetWorldXBounds() { }

	public void SetCShapeMinMax(Vector2 min, Vector2 max) { }

}

