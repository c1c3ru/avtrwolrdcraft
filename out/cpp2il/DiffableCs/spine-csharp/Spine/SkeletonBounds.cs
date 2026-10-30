namespace Spine;

public class SkeletonBounds
{
	private ExposedList<Polygon> polygonPool; //Field offset: 0x10
	private float minX; //Field offset: 0x18
	private float minY; //Field offset: 0x1C
	private float maxX; //Field offset: 0x20
	private float maxY; //Field offset: 0x24
	[CompilerGenerated]
	private ExposedList<BoundingBoxAttachment> <BoundingBoxes>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private ExposedList<Polygon> <Polygons>k__BackingField; //Field offset: 0x30

	public private ExposedList<BoundingBoxAttachment> BoundingBoxes
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public float Height
	{
		 get { } //Length: 16
	}

	public float MaxX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MaxY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MinX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MinY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public private ExposedList<Polygon> Polygons
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public float Width
	{
		 get { } //Length: 16
	}

	public SkeletonBounds() { }

	private void AabbCompute() { }

	public bool AabbContainsPoint(float x, float y) { }

	public bool AabbIntersectsSegment(float x1, float y1, float x2, float y2) { }

	public bool AabbIntersectsSkeleton(SkeletonBounds bounds) { }

	public BoundingBoxAttachment ContainsPoint(float x, float y) { }

	public bool ContainsPoint(Polygon polygon, float x, float y) { }

	[CompilerGenerated]
	public ExposedList<BoundingBoxAttachment> get_BoundingBoxes() { }

	public float get_Height() { }

	public float get_MaxX() { }

	public float get_MaxY() { }

	public float get_MinX() { }

	public float get_MinY() { }

	[CompilerGenerated]
	public ExposedList<Polygon> get_Polygons() { }

	public float get_Width() { }

	public Polygon GetPolygon(BoundingBoxAttachment attachment) { }

	public BoundingBoxAttachment IntersectsSegment(float x1, float y1, float x2, float y2) { }

	public bool IntersectsSegment(Polygon polygon, float x1, float y1, float x2, float y2) { }

	[CompilerGenerated]
	private void set_BoundingBoxes(ExposedList<BoundingBoxAttachment> value) { }

	public void set_MaxX(float value) { }

	public void set_MaxY(float value) { }

	public void set_MinX(float value) { }

	public void set_MinY(float value) { }

	[CompilerGenerated]
	private void set_Polygons(ExposedList<Polygon> value) { }

	public void Update(Skeleton skeleton, bool updateAabb) { }

}

