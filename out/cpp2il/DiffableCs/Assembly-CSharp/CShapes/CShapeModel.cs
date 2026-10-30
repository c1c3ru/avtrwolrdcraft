namespace CShapes;

public class CShapeModel
{
	internal enum Type
	{
		SpritePhysicsShapePolygon = 0,
		Circle = 1,
		Box = 2,
		Capsule = 3,
		PolygonCollider2DPolygon = 4,
		CustomPolygon = 5,
	}

	public Type type; //Field offset: 0x10
	public float radius; //Field offset: 0x14
	public float width; //Field offset: 0x18
	public float height; //Field offset: 0x1C
	public Vector2 offset; //Field offset: 0x20
	public float rotation; //Field offset: 0x28
	public bool useOnePhysicsShape; //Field offset: 0x2C
	private Vector2[][] _points; //Field offset: 0x30
	private Vector2[][] _worldPoints; //Field offset: 0x38
	private bool _hasMultipleShapes; //Field offset: 0x40
	private Boolean[] _holes; //Field offset: 0x48
	public Vector2 worldPosition; //Field offset: 0x50
	public Vector2 worldScale; //Field offset: 0x58
	public float worldRotation; //Field offset: 0x60
	public Bounds worldBounds; //Field offset: 0x64
	private float _worldRotationSin; //Field offset: 0x7C
	private float _worldRotationCos; //Field offset: 0x80
	private bool _isWorldPointsDirty; //Field offset: 0x84

	public float WorldRotationCos
	{
		 get { } //Length: 8
	}

	public float WorldRotationSin
	{
		 get { } //Length: 8
	}

	public CShapeModel() { }

	public bool AreEdgesIntersecting(ref Vector2 a, ref Vector2 b, ref Vector2 c, ref Vector2 d, ref Vector2 outPosition) { }

	private bool AreEdgesIntersecting(ref Vector2 a, ref Vector2 b, ref Vector2 c, ref Vector2 d) { }

	public bool AreEdgesIntersecting(CShapeModel otherShape) { }

	private void CalculateHitNormal(ref Vector2 rayStart, ref Vector2 rayEnd, ref Vector2 edgeA, ref Vector2 edgeB, ref Vector2 outNormal) { }

	public void CalculateWordPositionsFromPoints(Vector2[] points, Vector2[] wordPoints, bool includePosition = true, bool includeRotation = true, bool includeScale = true) { }

	public void CalculateWorldPointsIfNeeded() { }

	public float get_WorldRotationCos() { }

	public float get_WorldRotationSin() { }

	private Vector2[][] GetBoxPoints() { }

	public Vector2[][] GetCapsulePoints() { }

	public void GetCircleInfo(out Vector2 worldPosition, out float worldRadius) { }

	public Vector2 GetClosesetPoint(Vector2 point) { }

	private Vector2 GetClosesetPointOnCapsule(Vector2 pointToTest) { }

	private Vector2 GetClosesetPointOnCircle(Vector2 pointToTest) { }

	private Vector2 GetClosesetPointOnPolygon(Vector2 pointToTest) { }

	private float GetDistance(ref Vector2 a, ref Vector2 b) { }

	public Vector2 GetFirstWorldPoint() { }

	private int GetOrientation(ref Vector2 a, ref Vector2 b, ref Vector2 c) { }

	private void GetPointOnLine(ref Vector2 a, ref Vector2 b, ref Vector2 p, ref Vector2 outPoint) { }

	public Vector2[][] GetPoints() { }

	private float GetSqrMagnitude(ref Vector2 point1, ref Vector2 point2) { }

	public Vector2[][] GetWorldPoints() { }

	private void HandleMultipleShapes() { }

	public void Init(SpriteRenderer spriteRenderer) { }

	public void Init(PolygonCollider2D polygonCollider) { }

	public void Init() { }

	private void InitWorldPointsArrays() { }

	private bool IsBelowDistance(ref Vector2 point1, ref Vector2 point2, ref float distance) { }

	private bool IsCapsuleTouchingCircle(CShapeModel capsuleShape, CShapeModel circleShape) { }

	private bool IsCapsuleTouchingPolygon(CShapeModel capsuleShape, CShapeModel polygonShape) { }

	private bool IsCircleTouchingPolygon(CShapeModel circleShape, CShapeModel polygonShape) { }

	private bool IsPointInsidePolygon(Vector2 point) { }

	private bool IsPointInsidePolygon(Vector2 point, Vector2[] polygon) { }

	public bool IsPointInsideShape(Vector2 point) { }

	public bool IsTouching(CShapeModel otherShape) { }

	private void NormalizeVector(ref Vector2 vector) { }

	private void NormalizeVectorComponents(ref float x, ref float y) { }

	public bool Raycast(Vector2 start, Vector2 end, bool calculateNormal, ref Vector2 point, ref Vector2 normal, bool returnTrueIfStartInsideShape) { }

	private bool RaycastCapsule(ref Vector2 start, ref Vector2 end, ref bool calculateNormal, ref Vector2 point, ref Vector2 normal, bool returnTrueIfStartInsideShape) { }

	private bool RaycastCircle(ref Vector2 circlePosition, ref float circleRadius, ref Vector2 start, ref Vector2 end, ref bool calculateNormal, ref Vector2 point, ref Vector2 normal, bool returnTrueIfStartInsideShape) { }

	private bool RaycastPolygon(ref Vector2 start, ref Vector2 end, ref bool calculateNormal, ref Vector2 point, ref Vector2 normal, bool returnTrueIfStartInsideShape) { }

	public void SetCustomPolygon(Vector2[][] points) { }

	public void SetDirty() { }

	private void SyncSinAndCosWithWorldRotation() { }

}

