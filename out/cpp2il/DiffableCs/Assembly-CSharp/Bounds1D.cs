//Type is in global namespace

public struct Bounds1D
{
	public float min; //Field offset: 0x0
	public float max; //Field offset: 0x4

	public Bounds1D(float point, float size) { }

	public Bounds1D(Bounds1D source) { }

	public Bounds1D(Bounds source) { }

	public Bounds1D(CShapeModel cShapeModel) { }

	public bool Contains(float point) { }

	public static Bounds1D CreateFromMinMax(float min, float max) { }

	public void Encapsulate(float point) { }

	public void Encapsulate(Bounds1D bounds) { }

	public float GetCenter() { }

	public float GetIntersectRange(Bounds1D bounds) { }

	public float GetSize() { }

	public bool Intersects(Bounds1D bounds) { }

	public void SetCenter(float point) { }

	public void SetSize(float size) { }

}

