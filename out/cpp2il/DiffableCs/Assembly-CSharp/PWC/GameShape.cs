namespace PWC;

public class GameShape : GameShapeBase
{
	protected readonly CShape _cShape; //Field offset: 0x60

	public GameShape(CShape cShape) { }

	public CShape GetCShape() { }

	protected virtual void OnWorldBoundsRequried() { }

}

