namespace PWC.Level;

public class LevelFreeFormDropArea : LevelDropArea
{
	private Vector2[] _points; //Field offset: 0xD8
	private Vector2[] _worldPoints; //Field offset: 0xE0
	private bool _isFormDirty; //Field offset: 0xE8
	private float _minX; //Field offset: 0xEC
	private float _maxX; //Field offset: 0xF0
	private TransformChangedHandler _transformChangedHandler; //Field offset: 0xF8

	public LevelFreeFormDropArea() { }

	protected virtual void Awake() { }

	private void EnsureWorldPoints() { }

	public virtual Vector2 GetProperPositionToDropOnFromPosition(Vector2 fromPosition, LevelItem levelItem) { }

	protected virtual Bounds1D GetWorldXBoundsForItemPositionCalculation() { }

	private float GetYFromX(Vector2 a, Vector2 b, float x) { }

	public virtual bool HasSpecialItemPosition() { }

	private void InitForm() { }

	protected virtual void OnDestroy() { }

	public virtual void OverrideItemLandDestination(LevelItem levelItem, ref Vector2 destination) { }

	private void SetFormDirty() { }

}

