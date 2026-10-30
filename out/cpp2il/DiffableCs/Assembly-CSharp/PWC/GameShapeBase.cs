namespace PWC;

public abstract class GameShapeBase
{
	private Bounds1D _localXBounds; //Field offset: 0x10
	private Vector2[] _pointsForTouchTest; //Field offset: 0x18
	protected Bounds _localBounds; //Field offset: 0x20
	private bool _didCalcualteLocalXBounds; //Field offset: 0x38
	private bool _didCalcualteLocalBounds; //Field offset: 0x39
	private Vector2[] _localBoundsPoints; //Field offset: 0x40
	private float _specialCaseRotation; //Field offset: 0x48
	private Vector2 _specialCaseScale; //Field offset: 0x4C
	private float _specialCaseXSize; //Field offset: 0x54
	protected readonly CShapeModel _cShapeModel; //Field offset: 0x58

	public GameShapeBase(CShapeModel cShapeModel) { }

	protected override void CalculateLocalBoundsIfNeeded() { }

	protected override Vector2[] CreateLocalPointsForTouchTest() { }

	public CShapeModel GetCShapeModel() { }

	public override Bounds GetLocalBounds() { }

	public Vector2[] GetLocalPointsForTouchTest() { }

	public override Bounds1D GetLocalXBounds() { }

	public override Bounds GetWorldBounds() { }

	public Vector2 GetWorldPosition() { }

	public Vector2 GetWorldScale() { }

	public override Bounds1D GetWorldXBounds() { }

	protected abstract void OnWorldBoundsRequried() { }

}

